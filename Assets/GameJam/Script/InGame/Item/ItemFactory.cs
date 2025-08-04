using UnityEngine;
using Tech.C.Item;

namespace Tech.C.Item
{
    /// <summary>
    /// ItemSpawnRateDataとItemPoolを使い、確率に応じてPoolからアイテムを取得して返すFactory
    /// </summary>
    public class ItemFactory : MonoBehaviour
    {
        [Header("出現確率データ")]
        [SerializeField] private ItemSpawnRateData spawnRateData;

        [Header("Pool参照")]
        [SerializeField] private ItemPool itemPool;
        [Header("PrefabIndex")]
        [SerializeField] private int chip = 0;
        [SerializeField] private int playingCards = 1;
        [SerializeField] private int game = 2;
        [SerializeField] private int bed = 3;

        private int GetEntertainmentPrefabIndex(EntertainmentType type)
        {
            switch (type)
            {
                case EntertainmentType.Game: return game;
                case EntertainmentType.Bed: return bed;
                // 他のタイプも追加
                default: return chip;
            }
        }

        private int GetGamblingPrefabIndex(GamblingType type)
        {
            switch (type)
            {
                case GamblingType.Chip: return chip;
                case GamblingType.PlayingCards: return playingCards;
                
                default: return chip;
            }
        }

        /// <summary>
        /// 確率に応じてアイテムをPoolから取得
        /// </summary>
        public GameObject GetRandomItem(Vector3 position)
        {
            // Entertainment or Gamblingを確率で抽選
            int totalEntertainment = 0;
            foreach (var rate in spawnRateData.entertainmentRates) totalEntertainment += rate.rate;
            int totalGambling = 0;
            foreach (var rate in spawnRateData.gamblingRates) totalGambling += rate.rate;
            int total = totalEntertainment + totalGambling;
            int rand = Random.Range(0, total);

            if (rand < totalEntertainment)
            {
                // EntertainmentTypeをさらに確率抽選
                int eRand = Random.Range(0, totalEntertainment);
                int sum = 0;
                foreach (var rate in spawnRateData.entertainmentRates)
                {
                    sum += rate.rate;
                    if (eRand < sum)
                    {
                        GameObject item = itemPool.GetItem(position, GetEntertainmentPrefabIndex(rate.type));
                        // 生成直後に大きさをリセット
                        item.transform.localScale = Vector3.one;

                        var ctrl = item.GetComponent<EntertainmentItemController>();
                        if (ctrl != null)
                        {
                            ctrl.SetPool(itemPool, GetEntertainmentPrefabIndex(rate.type));
                            ctrl.SetType(rate.type);
                        }
                        return item;
                    }
                }
            }
            else
            {
                // GamblingTypeをさらに確率抽選
                int gRand = Random.Range(0, totalGambling);
                int sum = 0;
                foreach (var rate in spawnRateData.gamblingRates)
                {
                    sum += rate.rate;
                    if (gRand < sum)
                    {
                        GameObject item = itemPool.GetItem(position, GetGamblingPrefabIndex(rate.type));
                        // 生成直後に大きさをリセット
                        item.transform.localScale = Vector3.one;

                        var ctrl = item.GetComponent<GamblingItemController>();
                        if (ctrl != null)
                        {
                            ctrl.SetPool(itemPool, GetGamblingPrefabIndex(rate.type));
                            ctrl.SetType(rate.type);
                        }
                        return item;
                    }
                }
            }
            return null;
        }
    }
}