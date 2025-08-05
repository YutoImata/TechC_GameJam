using UnityEngine;

namespace Tech.C.Item
{
    /// <summary>
    /// アイテム全体の生成・管理を行うマネージャー
    /// 今後確率調整やFactory連携も拡張可能
    /// </summary>
    public class ItemManager : MonoBehaviour
    {
        [Header("生成位置")]
        [SerializeField] private ItemSpawner itemSpawner;
        
        [Header("生成する間隔")]
        [SerializeField] private float spawnInterval = 2f;
        [Header("アイテム落下速度ランダム設定")]
        [SerializeField] private float defaultFallSpeed = 2f;
        [SerializeField] private bool useRandomFallSpeed = false;
        [SerializeField] private float minFallSpeed = 2f;
        [SerializeField] private float maxFallSpeed = 6f;

        [Header("Factory参照")]
        [SerializeField] private ItemFactory itemFactory;


        private float timer;
        private bool isSpawning = false;

        void Start()
        {
            StartSpawning();
        }

        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnRandomItem();
                timer = 0f;
            }
        }

        /// <summary>
        /// ゲーム開始時に生成開始
        /// </summary>
        public void StartSpawning()
        {
            isSpawning = true;
        }

        /// <summary>
        /// ランダムでアイテムを生成（ItemFactory経由）
        /// </summary>
        private void SpawnRandomItem()
        {
            if (itemFactory != null && itemSpawner != null)
            {
                Vector3 spawnPos = itemSpawner.GetRandomSpawnPosition();
                GameObject item = itemFactory.GetRandomItem(spawnPos);

                // 娯楽アイテム
                var entertainmentCtrl = item.GetComponent<EntertainmentItemController>();
                if (entertainmentCtrl != null)
                {
                    entertainmentCtrl.SetFallSpeed(GetFallSpeed());
                }

                // ギャンブルアイテム
                var gamblingCtrl = item.GetComponent<GamblingItemController>();
                if (gamblingCtrl != null)
                {
                    gamblingCtrl.SetFallSpeed(GetFallSpeed());
                }
            }
        }

        // アイテム生成時に呼び出す例
        public void SetupItemMover(ItemMover mover)
        {
            if (useRandomFallSpeed)
            {
                mover.fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
            }
            // useRandomFallSpeedがfalseならPrefabの値をそのまま使う
        }

        public float GetFallSpeed()
        {
            return useRandomFallSpeed ? Random.Range(minFallSpeed, maxFallSpeed) : defaultFallSpeed;
        }
    }
}