using UnityEngine;
using Tech.C;

namespace Tech.C
{
    public class BulletPool : Singleton<BulletPool>
    {
        [SerializeField] private BulletController bulletPrefab;
        [SerializeField] private Transform bulletParent;
        [SerializeField] private int initialSize = 20;

        private ObjectPool<BulletController> pool;

        protected override void Init()
        {
            pool = new ObjectPool<BulletController>(bulletPrefab, bulletParent, initialSize);
        }

        public BulletController GetBullet(Vector2 position)
        {
            var bullet = pool.Get();
            bullet.transform.position = position;
            return bullet;
        }

        public void ReturnBullet(BulletController bullet)
        {
            pool.Return(bullet);
        }
    }
}