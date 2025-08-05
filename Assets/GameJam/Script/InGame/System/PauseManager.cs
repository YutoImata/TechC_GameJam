using UnityEngine;
using UnityEngine.InputSystem;

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
        [SerializeField] private GameObject pauseUI; // ポーズ時に表示するUI
        
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
                pauseUI.SetActive(false);
            }
        }
        
        /// <summary>
        /// ポーズの切り替え（Input System用）
        /// </summary>
        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                TogglePause();
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
                pauseUI.SetActive(true);
            }
            
            Debug.Log("Game Paused");
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
                pauseUI.SetActive(false);
            }
            
            Debug.Log("Game Resumed");
        }
        
        /// <summary>
        /// 強制的にポーズを解除（シーン切り替え時など）
        /// </summary>
        public void ForceResume()
        {
            isPaused = false;
            Time.timeScale = originalTimeScale;
            
            if (pauseUI != null)
            {
                pauseUI.SetActive(false);
            }
        }
        
        void OnApplicationFocus(bool hasFocus)
        {
            // アプリケーションがフォーカスを失った時に自動ポーズ
            if (!hasFocus && canPause && !isPaused)
            {
                Pause();
            }
        }
        
        void OnApplicationPause(bool pauseStatus)
        {
            // アプリケーションが一時停止された時の処理（モバイル用）
            if (pauseStatus && canPause && !isPaused)
            {
                Pause();
            }
        }
    }
}
