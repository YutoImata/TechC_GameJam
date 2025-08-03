using UnityEngine;
using Tech.C.Item;
using Tech.C.Interface;

namespace Tech.C.Item
{
    /// <summary>
    /// ギャンブル系アイテムの挙動を管理するコントローラー
    /// </summary>
    public class GamblingItemController : MonoBehaviour, IFallingItem
    {
        [SerializeField] private GamblingType gamblingType;
        /// <summary>
        /// 外部からタイプをセットする
        /// </summary>
        public void SetType(GamblingType type)
        {
            gamblingType = type;
        }
        [SerializeField] private float fallSpeed = 2f;

        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            // 下方向に移動
            rb.linearVelocity = new Vector2(0, -fallSpeed);
        }

        // 落下時の処理
        public void OnFallen()
        {
            Destroy(gameObject);
        }

        // プレイヤー取得時の処理
        public void OnCollected()
        {
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