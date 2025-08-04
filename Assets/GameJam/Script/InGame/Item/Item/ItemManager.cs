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
                var mover = item.GetComponent<ItemMover>();
                mover.MoveItem();
            }
        }
    }
}