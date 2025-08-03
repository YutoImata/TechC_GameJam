using UnityEngine;

namespace Tech.C.Bullet
{
    /// <summary>
    /// 弾の生成管理を担当するクラス
    /// </summary>
    public class BulletManager : Singleton<BulletManager>
    {
        protected override bool UseDontDestroyOnLoad => false;
        
        /// <summary>
        /// 指定した種類の弾を生成する処理を呼ぶ
        /// </summary>
        /// <param name="type">弾の種類</param>
        /// <param name="position">生成位置</param>
        public void SpawnBullet(BulletType type, Vector2 position)
        {
            var bullet = BulletPool.I.GetBullet(type, position);
            if (bullet != null)
            {
                bullet.Fire(Vector2.up, type);
            }
        }
    }
}