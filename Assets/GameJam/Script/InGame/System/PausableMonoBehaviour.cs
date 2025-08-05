using UnityEngine;
using Tech.C.Interface;
using Tech.C.System;

namespace Tech.C.System
{
    /// <summary>
    /// ポーズ機能に対応したMonoBehaviourのベースクラス
    /// </summary>
    public abstract class PausableMonoBehaviour : MonoBehaviour, IPausable
    {
        protected bool isPaused = false;
        
        protected virtual void Start()
        {
            // PauseManagerが存在する場合はポーズ状態を同期
            if (PauseManager.I != null)
            {
                isPaused = PauseManager.I.IsPaused;
            }
        }
        
        protected virtual void Update()
        {
            // PauseManagerの状態をチェック
            if (PauseManager.I != null)
            {
                bool pauseManagerPaused = PauseManager.I.IsPaused;
                
                // ポーズ状態が変わった場合
                if (isPaused != pauseManagerPaused)
                {
                    if (pauseManagerPaused)
                    {
                        OnPause();
                    }
                    else
                    {
                        OnResume();
                    }
                    isPaused = pauseManagerPaused;
                }
            }
            
            // ポーズ中でなければ通常のUpdate処理
            if (!isPaused)
            {
                PausableUpdate();
            }
        }
        
        /// <summary>
        /// ポーズ中でない時のUpdate処理（継承先で実装）
        /// </summary>
        protected virtual void PausableUpdate() { }
        
        /// <summary>
        /// ポーズ時の処理（継承先でオーバーライド可能）
        /// </summary>
        public virtual void OnPause()
        {
            isPaused = true;
        }
        
        /// <summary>
        /// ポーズ解除時の処理（継承先でオーバーライド可能）
        /// </summary>
        public virtual void OnResume()
        {
            isPaused = false;
        }
        
        /// <summary>
        /// ポーズ状態を取得
        /// </summary>
        public bool IsPaused => isPaused;
    }
}
