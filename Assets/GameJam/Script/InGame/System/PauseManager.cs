using UnityEngine;
using Tech.C.UI;

namespace Tech.C.System
{
    /// <summary>
    /// ゲーム全体のポーズ機能を管理するシングルトンクラス
    /// </summary>
    public class PauseManager : Singleton<PauseManager>
    {
        [Header("ポーズ設定")]
        [SerializeField] private bool canPause = true; // ポーズ可能かどうか
        
        [Header("ポーズUI")]
        [SerializeField] private PauseUI pauseUI; // ポーズUI管理クラス
        
        private bool isPaused = false;
        private float originalTimeScale = 1f;
        
        protected override bool UseDontDestroyOnLoad => false;
        
        /// <summary>
        /// 現在のポーズ状態を取得
        /// </summary>
        public bool IsPaused => isPaused;
        
        /// <summary>
        /// ポーズ可能状態を設定
        /// </summary>
        public bool CanPause 
        { 
            get => canPause; 
            set => canPause = value; 
        }
        
        protected override void Init()
        {
            originalTimeScale = Time.timeScale;
            
            // ポーズUIは最初は非表示
            if (pauseUI != null)
            {
                pauseUI.HidePauseUI();
            }
        }
        
        /// <summary>
        /// ポーズの切り替え
        /// </summary>
        public void TogglePause()
        {
            if (!canPause) return;
            
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
        /// <summary>
        /// ポーズする
        /// </summary>
        public void Pause()
        {
            if (!canPause || isPaused) return;
            
            isPaused = true;
            Time.timeScale = 0f;
            
            // ポーズUIを表示
            if (pauseUI != null)
            {
                pauseUI.ShowPauseUI();
            }
        }
        
        /// <summary>
        /// ポーズを解除する
        /// </summary>
        public void Resume()
        {
            if (!isPaused) return;
            
            isPaused = false;
            Time.timeScale = originalTimeScale;
            
            // ポーズUIを非表示
            if (pauseUI != null)
            {
                pauseUI.HidePauseUI();
            }
        }
    }
}
