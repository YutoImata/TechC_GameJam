using UnityEngine;
using Tech.C.Interface;

namespace Tech.C.Item
{
    /// <summary>
    /// 娯楽系アイテムの挙動を管理するコントローラー
    /// </summary>
    public class EntertainmentItemController : MonoBehaviour, IFallingItem
    {
        [SerializeField] private EntertainmentType entertainmentType;
        private ItemMoveType moveType;

        [Header("設定")]
        [SerializeField] private float fallSpeed = 2f;
        [SerializeField] private int entertainmentValue = 10;

        private Rigidbody2D rb;

        private ItemPool itemPool;
        private int poolIndex;

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
        /// <summary>
        /// 外部からタイプをセットする
        /// </summary>
        public void SetType(EntertainmentType type)
        {
            entertainmentType = type;
        }

        // Pool参照をセットするメソッド
        public void SetPool(ItemPool pool, int index)
        {
            itemPool = pool;
            poolIndex = index;
        }

        // 共通返却処理
        private void ReturnToPool()
        {
            if (itemPool != null)
            {
                itemPool.ReturnItem(gameObject, poolIndex);
            }
            else
                Debug.LogError("ItemPoolに返却できません");
        }

        // 落下時の処理
        public void OnFallen()
        {
            ReturnToPool();
        }

        // プレイヤー取得時の処理
        public void OnCollected()
        {
            ReturnToPool();
        }

        // 弾との衝突判定
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet"))
            {
                GaugeController.I.AddEntertainment(entertainmentValue); // 仮の加算量。必要に応じて調整
            }
            OnCollected();
        }

        public void SetFallSpeed(float speed)
        {
            fallSpeed = speed;
        }
    }
}