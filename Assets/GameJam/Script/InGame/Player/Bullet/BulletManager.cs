using UnityEngine;

namespace Tech.C
{
    public class BulletManager : Singleton<BulletManager>
    {
        [SerializeField] private GameObject bulletPrefab;

        /// <summary>
        /// 弾を生成する処理を呼ぶ
        /// </summary>
        /// <param name="position"></param>
        public void SpawnBullet(Vector2 position)
        {
            var bullet = BulletPool.I.GetBullet(position);
            if (bullet != null)
            {
                bullet.Fire(Vector2.up);
            }
        }
    }
}