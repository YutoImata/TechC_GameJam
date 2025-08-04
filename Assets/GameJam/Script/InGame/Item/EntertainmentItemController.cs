using UnityEngine;
using Tech.C.Item;
using Tech.C.Interface;

namespace Tech.C.Item
{
    /// <summary>
    /// 娯楽系アイテムの挙動を管理するコントローラー
    /// </summary>
    public class EntertainmentItemController : MonoBehaviour, IFallingItem
    {
        [SerializeField] private EntertainmentType entertainmentType;
        private MoveType moveType;

        /// <summary>
        /// 外部からタイプをセットする
        /// </summary>
        public void SetType(EntertainmentType type)
        {
            entertainmentType = type;
        }
        [SerializeField] private float fallSpeed = 2f;

        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Fall();
        }

        // 毎フレームの落下・移動処理
        public void Fall()
        {
            rb.linearVelocity = new Vector2(0, -fallSpeed);
        }

        // 落下時の処理
        public void OnFallen()
        {
            // 画面外などで呼ばれる想定
            Destroy(gameObject);
        }

        // プレイヤー取得時の処理
        public void OnCollected()
        {
            // ゲージ加算など（GaugeManager呼び出し等）
            Destroy(gameObject);
        }

        // 弾との衝突判定
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet"))
            {
                OnCollected();
            }
        }
    }
}