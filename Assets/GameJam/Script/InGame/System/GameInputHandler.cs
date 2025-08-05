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
        /// <summary>
        /// Input System用のポーズ入力
        /// </summary>
        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (PauseManager.I != null)
                {
                    PauseManager.I.TogglePause();
                }
            }
        }
    }
}
