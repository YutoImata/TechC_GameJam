using UnityEngine;

namespace Tech.C.Bullet
{
    /// <summary>
    /// 弾の生成を担当するファクトリークラス
    /// </summary>
    public class BulletFactory : Singleton<BulletFactory>
    {
        [SerializeField] private BulletController bulletPrefab;

        protected override bool UseDontDestroyOnLoad => false;
        /// <summary>
        /// 指定位置に弾を生成して返す
        /// </summary>
        public BulletController CreateBullet(Vector2 position)
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
