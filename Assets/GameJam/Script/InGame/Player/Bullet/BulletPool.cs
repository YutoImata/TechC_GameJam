using UnityEngine;
using System.Collections.Generic;

namespace Tech.C
{
    /// <summary>
    /// 弾のオブジェクトプール管理クラス
    /// </summary>

    [System.Serializable]
    public class BulletPoolSet
    {
        [Tooltip("弾の種類")]
        public BulletType type;
        [Tooltip("弾のPrefab（BulletController）")]
        public BulletController prefab;
        [Tooltip("生成した弾の親Transform")]
        public Transform parent;
        [Tooltip("初期生成数（プールサイズ）")]
        public int initialSize = 20;
        [HideInInspector] public ObjectPool<BulletController> pool;
    }

    public class BulletPool : Singleton<BulletPool>
    {
        [SerializeField] private List<BulletPoolSet> poolSets;

        /// <summary>
        /// プールの初期化処理
        /// </summary>
        protected override void Init()
        {
            foreach (var set in poolSets)
            {
                set.pool = new ObjectPool<BulletController>(
                    () => Object.Instantiate(set.prefab, set.parent),
                    set.parent,
                    set.initialSize
                );
            }
        }

        /// <summary>
        /// 指定した弾種のプールから弾を取得し、位置をセットして返す
        /// </summary>
        public BulletController GetBullet(BulletType type, Vector2 position)
        {
            var set = poolSets.Find(s => s.type == type);
            if (set == null) return null;
            var bullet = set.pool.Get();
            bullet.transform.position = position;
            return bullet;
        }

        /// <summary>
        /// 指定した弾種のプールに弾を戻す
        /// </summary>
        public void ReturnBullet(BulletType type, BulletController bullet)
        {
            var set = poolSets.Find(s => s.type == type);
            if (set != null) set.pool.Return(bullet);
        }
    }
}