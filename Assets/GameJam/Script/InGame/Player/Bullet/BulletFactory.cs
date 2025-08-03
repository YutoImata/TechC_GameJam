using UnityEngine;

namespace Tech.C
{
    public class BulletFactory : Singleton<BulletFactory>
    {
        [SerializeField] private GameObject bulletPrefab;

        public GameObject CreateBullet(Vector2 position)
        {
            if (bulletPrefab == null)
            {
                Debug.LogError("bulletPrefabがセットされていません");
                return null;
            }
            return Instantiate(bulletPrefab, position, Quaternion.identity);
        }
    }
}
