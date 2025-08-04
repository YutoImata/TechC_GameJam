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
