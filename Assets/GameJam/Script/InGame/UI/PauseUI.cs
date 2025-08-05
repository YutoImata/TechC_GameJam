using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tech.C.UI
{
    /// <summary>
    /// ポーズ画面のUIを管理するクラス
    /// </summary>
    public class PauseUI : MonoBehaviour
    {
        [Header("UI要素")]
        [SerializeField] private GameObject pausePanel; // ポーズ画面全体のパネル
        [SerializeField] private TextMeshProUGUI pauseText; // "PAUSED"テキスト
        [SerializeField] private Button resumeButton; // 再開ボタン
        [SerializeField] private Button settingsButton; // 設定ボタン（オプション）
        [SerializeField] private Button mainMenuButton; // メインメニューボタン（オプション）
        
        [Header("設定")]
        [SerializeField] private string pauseMessage = "PAUSED"; // ポーズ時のメッセージ
        [SerializeField] private bool showButtons = true; // ボタンを表示するか
        
        private void Start()
        {
            // 初期化
            if (pausePanel != null)
            {
                pausePanel.SetActive(false);
            }
            
            // ボタンのイベント設定
            SetupButtons();
            
            // ポーズテキストの設定
            if (pauseText != null)
            {
                pauseText.text = pauseMessage;
            }
        }
        
        /// <summary>
        /// ボタンのイベントを設定
        /// </summary>
        private void SetupButtons()
        {
            if (resumeButton != null)
            {
                resumeButton.onClick.AddListener(OnResumeButtonClicked);
                resumeButton.gameObject.SetActive(showButtons);
            }
            
            if (settingsButton != null)
            {
                settingsButton.onClick.AddListener(OnSettingsButtonClicked);
                settingsButton.gameObject.SetActive(showButtons);
            }
            
            if (mainMenuButton != null)
            {
                mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
                mainMenuButton.gameObject.SetActive(showButtons);
            }
        }
        
        /// <summary>
        /// ポーズUIを表示
        /// </summary>
        public void ShowPauseUI()
        {
            if (pausePanel != null)
            {
                pausePanel.SetActive(true);
            }
        }
        
        /// <summary>
        /// ポーズUIを非表示
        /// </summary>
        public void HidePauseUI()
        {
            if (pausePanel != null)
            {
                pausePanel.SetActive(false);
            }
        }
        
        /// <summary>
        /// 再開ボタンがクリックされた時の処理
        /// </summary>
        private void OnResumeButtonClicked()
        {
            if (Tech.C.System.PauseManager.I != null)
            {
                Tech.C.System.PauseManager.I.Resume();
            }
        }
        
        /// <summary>
        /// 設定ボタンがクリックされた時の処理
        /// </summary>
        private void OnSettingsButtonClicked()
        {
            Debug.Log("Settings button clicked - implement settings menu");
            // 設定画面を開く処理をここに実装
        }
        
        /// <summary>
        /// メインメニューボタンがクリックされた時の処理
        /// </summary>
        private void OnMainMenuButtonClicked()
        {
            Debug.Log("Main menu button clicked - implement scene transition");
            // メインメニューに戻る処理をここに実装
            // 例: SceneManager.LoadScene("MainMenu");
        }
        
        /// <summary>
        /// ポーズメッセージを変更
        /// </summary>
        public void SetPauseMessage(string message)
        {
            pauseMessage = message;
            if (pauseText != null)
            {
                pauseText.text = message;
            }
        }
    }
}
