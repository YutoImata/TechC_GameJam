using UnityEngine;
using System.Collections.Generic;

namespace Tech.C.Item
{
    /// <summary>
    /// アイテム出現確率を管理するScriptableObject
    /// </summary>
    [CreateAssetMenu(menuName = "Tech.C/ItemSpawnRateData")]
    public class ItemSpawnRateData : ScriptableObject
    {
        [Header("娯楽アイテムの出現確率（合計100になるように）")]
        public List<EntertainmentRate> entertainmentRates;

        [Header("ギャンブルアイテムの出現確率（合計100になるように）")]
        public List<GamblingRate> gamblingRates;

        [ContextMenu("全rateを0にする")]
        public void ResetAllRatesToZero()
        {
            if (entertainmentRates != null)
            {
                foreach (var rate in entertainmentRates)
                {
                    rate.rate = 0;
                }
            }
            if (gamblingRates != null)
            {
                foreach (var rate in gamblingRates)
                {
                    rate.rate = 0;
                }
            }
        }

        [ContextMenu("全rateを100にする")]
        public void SetAllRatesToHundred()
        {
            if (entertainmentRates != null)
            {
                foreach (var rate in entertainmentRates)
                {
                    rate.rate = 100;
                }
            }
            if (gamblingRates != null)
            {
                foreach (var rate in gamblingRates)
                {
                    rate.rate = 100;
                }
            }
        }

    }

    [System.Serializable]
    public class EntertainmentRate
    {
        public EntertainmentType type;
        [Range(0, 100)] public int rate;
    }

    [System.Serializable]
    public class GamblingRate
    {
        public GamblingType type;
        [Range(0, 100)] public int rate;
    }
}
