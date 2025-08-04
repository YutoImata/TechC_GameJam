using UnityEngine;

namespace Tech.C.Item
{
    [System.Serializable]
    public class ItemSpawner
    {
        [Header("生成範囲左端")] public Transform spawnLeft;
        [Header("生成範囲右端")] public Transform spawnRight;

        public Vector3 GetRandomSpawnPosition()
        {
            if (spawnLeft == null || spawnRight == null) return Vector3.zero;
            float minX = spawnLeft.position.x;
            float maxX = spawnRight.position.x;
            float y = spawnLeft.position.y;
            return new Vector3(UnityEngine.Random.Range(minX, maxX), y, 0);
        }
    }
}