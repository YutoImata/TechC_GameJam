using UnityEngine;

namespace Tech.C
{
    public class BulletManager : Singleton<BulletManager>
    {
        [SerializeField] private GameObject bulletPrefab;

        public void SpawnBullet(Vector2 position)
        {
            if (bulletPrefab == null)
            {
                Debug.LogError("bulletPrefabがセットされていません");
                return;
            }
            var obj = Instantiate(bulletPrefab, position, Quaternion.identity);
            var bullet = obj.GetComponent<BulletController>();
            if (bullet != null)
            {
                bullet.Fire(Vector2.up); // 上方向に発射
            }
        }
    }
}