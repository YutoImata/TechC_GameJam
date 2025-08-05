using UnityEngine;
using System.Collections;

namespace Tech.C.Bullet
{
    /// <summary>
    /// 弾の挙動を制御するコンポーネント
    /// </summary>
    public class BulletController : MonoBehaviour
    {
        /// <summary>
        /// この弾の種類
        /// </summary>
        public BulletType type { get; private set; }

        [SerializeField] private float speed = 10f;
        [SerializeField] private float lifeTime = 2f;
        private float timer;
        private Rigidbody2D rb;
        private bool isPaused = false;
        private Vector2 pausedVelocity; // ポーズ時に速度を保存

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// 弾の寿命管理とプールへの返却処理
        /// </summary>
        void Update()
        {
            // ポーズ中は時間経過を停止
            if (!isPaused)
            {
                timer += Time.deltaTime;
                if (timer >= lifeTime)
                {
                    BulletPool.I.ReturnBullet(type, this);
                }
            }
        }

        /// <summary>
        /// 弾を指定方向・種類で発射する
        /// </summary>
        public void Fire(Vector2 direction, BulletType type)
        {
            this.type = type;
            timer = 0f;
            
            // Playerの移動速度の影響を受けないよう、速度を完全にリセットしてから設定
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero; // まず速度をゼロにリセット
                rb.angularVelocity = 0f; // 回転速度もリセット
                
                // 1フレーム待ってから速度を設定（物理的相互作用を防ぐため）
                StartCoroutine(SetVelocityNextFrame(direction.normalized * speed));
            }
        }
        
        /// <summary>
        /// 次のフレームで速度を設定する（物理的相互作用を避けるため）
        /// </summary>
        private IEnumerator SetVelocityNextFrame(Vector2 velocity)
        {
            yield return null; // 1フレーム待機
            if (rb != null)
            {
                rb.linearVelocity = velocity;
            }
        }

        public void ReturnToPool()
        {
            BulletPool.I.ReturnBullet(type, this);
        }
        
        // ポーズ機能
        public void OnPause()
        {
            isPaused = true;
            if (rb != null)
            {
                pausedVelocity = rb.linearVelocity;
                rb.linearVelocity = Vector2.zero;
                Debug.Log($"[BulletController] 弾をポーズ - 保存された速度: {pausedVelocity}");
            }
        }
        
        public void OnResume()
        {
            isPaused = false;
            if (rb != null)
            {
                rb.linearVelocity = pausedVelocity;
                Debug.Log($"[BulletController] 弾のポーズ解除 - 復元された速度: {pausedVelocity}");
            }
        }
        
        public bool IsPaused => isPaused;

    }
}