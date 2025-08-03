using UnityEngine;
using System.Collections.Generic;

namespace Tech.C.Item
{
    /// <summary>
    /// EntertainmentItem/GamblingItemなどを再利用管理する汎用ItemPool
    /// </summary>
    [System.Serializable]
    public class ItemPoolSet
    {
        [Tooltip("アイテムPrefab")]
        public GameObject prefab;
        [Tooltip("生成したアイテムの親Transform（フォルダ）")]
        public Transform parent;
        [Tooltip("初期生成数（プールサイズ）")]
        public int initialSize = 10;
        [HideInInspector] public Queue<GameObject> pool = new Queue<GameObject>();
    }

    public class ItemPool : MonoBehaviour
    {
        [SerializeField] private List<ItemPoolSet> poolSets;

        void Awake()
        {
            foreach (var set in poolSets)
            {
                for (int j = 0; j < set.initialSize; j++)
                {
                    var obj = Instantiate(set.prefab, set.parent);
                    obj.SetActive(false);
                    set.pool.Enqueue(obj);
                }
            }
        }

        /// <summary>
        /// Poolから指定Prefabのアイテムを取得（生成先フォルダも自動指定）
        /// </summary>
        public GameObject GetItem(Vector3 position, int prefabIndex)
        {
            var set = poolSets[prefabIndex];
            GameObject obj = set.pool.Count > 0 ? set.pool.Dequeue() : Instantiate(set.prefab, set.parent);
            obj.transform.position = position;
            if (set.parent != null) obj.transform.SetParent(set.parent);
            obj.SetActive(true);
            return obj;
        }

        /// <summary>
        /// アイテムをPoolに戻す
        /// </summary>
        public void ReturnItem(GameObject obj, int prefabIndex)
        {
            obj.SetActive(false);
            poolSets[prefabIndex].pool.Enqueue(obj);
        }
    }
}