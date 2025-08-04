using UnityEngine;
using Tech.C.Interface;

namespace Tech.C.Item
{
    /// <summary>
    /// ギャンブル系アイテムの挙動を管理するコントローラー
    /// </summary>
    public class GamblingItemController : MonoBehaviour, IFallingItem
    {
        [SerializeField] private GamblingType gamblingType;
        [SerializeField] private GaugeController gaugeController;

        [Header("設定")]
        [SerializeField] private int gambleValueValue = 10;
        [SerializeField] private float fallSpeed = 2f;

        private Rigidbody2D rb;

        // Pool参照を保持
        private ItemPool itemPool;
        private int poolIndex;

        private ItemMoveType moveType;
        /// <summary>
        /// 外部からタイプをセットする
        /// </summary>
        public void SetType(GamblingType type)
        {
            gamblingType = type;
        }

        // Pool参照をセットするメソッド
        public void SetPool(ItemPool pool, int index)
        {
            itemPool = pool;
            poolIndex = index;
        }

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Fall();
        }

        public void Fall()
        {
            if (rb != null)
                rb.linearVelocity = new Vector2(0, -fallSpeed);
        }


        // アイテムをPoolに返却
        public void ReturnToPool()
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
                gaugeController.AddGamble(gambleValueValue); // 仮の加算量。必要に応じて調整
            }
            OnCollected();
        }
    }
}