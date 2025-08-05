using UnityEngine;
using UnityEngine.InputSystem;

namespace Tech.C.System
{
    /// <summary>
    /// ゲーム全体の入力を管理するクラス
    /// ポーズなどのシステム入力を処理
    /// </summary>
    public class GameInputHandler : MonoBehaviour
    {
        private bool escKeyPressed = false;
        
        private void Update()
        {
            // Time.timeScale = 0の時でもESCキーを検出できるようにする
            if (Input.GetKeyDown(KeyCode.Escape) && !escKeyPressed)
            {
                escKeyPressed = true;
                Debug.Log("[GameInputHandler] ESCキー入力検出（旧Input System）");
                
                if (PauseManager.I != null)
                {
                    Debug.Log("[GameInputHandler] PauseManagerにポーズ切り替えを要求");
                    PauseManager.I.TogglePause();
                }
                else
                {
                    Debug.LogError("[GameInputHandler] PauseManagerが見つかりません");
                }
            }
            
            // キーを離したらフラグをリセット
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                escKeyPressed = false;
            }
        }
        
        /// <summary>
        /// Input System用のポーズ入力
        /// </summary>
        public void OnPause(InputAction.CallbackContext context)
        {
            Debug.Log($"[GameInputHandler] ESCキー入力検出 - phase: {context.phase}");
            
            if (context.performed)
            {
                Debug.Log("[GameInputHandler] ESCキー入力が実行されました");
                
                if (PauseManager.I != null)
                {
                    Debug.Log("[GameInputHandler] PauseManagerにポーズ切り替えを要求");
                    PauseManager.I.TogglePause();
                }
                else
                {
                    Debug.LogError("[GameInputHandler] PauseManagerが見つかりません");
                }
            }
        }
    }
}
