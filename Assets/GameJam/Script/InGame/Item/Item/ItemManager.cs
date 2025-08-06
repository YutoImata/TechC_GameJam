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
        
        [Header("アイテム落下速度制御（全アイテム共通）")]
        [Tooltip("固定速度として使用する値")]
        [SerializeField] private float defaultFallSpeed = 2f;
        
        [Space]
        [Header("ランダム速度設定")]
        [Tooltip("ONにすると、アイテムごとにランダムな落下速度が設定されます")]
        [SerializeField] private bool useRandomFallSpeed = false;
        [Tooltip("ランダム速度の最小値")]
        [SerializeField] private float minFallSpeed = 2f;
        [Tooltip("ランダム速度の最大値")]
        [SerializeField] private float maxFallSpeed = 6f;

        [Header("Factory参照")]
        [SerializeField] private ItemFactory itemFactory;


        private float timer;
        private bool isPaused = false;

        void Update()
        {
            // ポーズ中はアイテム生成を停止
            if (isPaused) 
            {
                return;
            }
            
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnRandomItem();
                timer = 0f;
            }
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

                if (item != null)
                {
                    // 境界チェッカーがない場合は追加（プレハブに追加し忘れの対策）
                    if (item.GetComponent<ItemBoundaryChecker>() == null)
                    {
                        Debug.LogWarning($"アイテム {item.name} にItemBoundaryCheckerがありません。自動追加します。");
                        item.AddComponent<ItemBoundaryChecker>();
                    }

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
        }

        public float GetFallSpeed()
        {
            return useRandomFallSpeed ? Random.Range(minFallSpeed, maxFallSpeed) : defaultFallSpeed;
        }
        
        // ポーズ機能
        public void OnPause()
        {
            isPaused = true;
        }
        
        public void OnResume()
        {
            isPaused = false;
        }
        
        public bool IsPaused => isPaused;
    }
}