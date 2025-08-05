using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tech.C
{
    /// <summary>
    /// ジェネリックなオブジェクトプール基盤クラス
    /// </summary>
    public class ObjectPool<T> where T : Component
    {
        private readonly Func<T> createFunc;
        private readonly Transform parent;
        private readonly Queue<T> pool = new Queue<T>();

        /// <summary>
        /// プールの初期化処理
        /// </summary>
        public ObjectPool(Func<T> createFunc, Transform parent = null, int initialSize = 10)
        {
            this.createFunc = createFunc;
            this.parent = parent;
            for (int i = 0; i < initialSize; i++)
            {
                var obj = createFunc();
                if (parent != null) obj.transform.SetParent(parent);
                obj.gameObject.SetActive(false);
                pool.Enqueue(obj);
            }
        }

        /// <summary>
        /// プールからオブジェクトを取得して返す
        /// </summary>
        public T Get()
        {
            if (pool.Count > 0)
            {
                var obj = pool.Dequeue();
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                var obj = createFunc();
                if (parent != null) obj.transform.SetParent(parent);
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        /// <summary>
        /// オブジェクトをプールに戻す
        /// </summary>
        public void Return(T obj)
        {
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }
}