using UnityEngine;

namespace Tech.C
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

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// 弾の寿命管理とプールへの返却処理
        /// </summary>
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= lifeTime)
            {
                BulletPool.I.ReturnBullet(type, this);
            }
        }

        /// <summary>
        /// 弾を指定方向・種類で発射する
        /// </summary>
        public void Fire(Vector2 direction, BulletType type)
        {
            this.type = type;
            timer = 0f;
            rb.linearVelocity = direction.normalized * speed;
        }

    }
}