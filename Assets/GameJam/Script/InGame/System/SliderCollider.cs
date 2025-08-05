using UnityEngine;

namespace Tech.C
{
    /// <summary>
    /// Sliderに専用のコライダー機能を提供
    /// PlayerがSlider領域に侵入しないように制御
    /// </summary>
    public class SliderCollider : MonoBehaviour
    {
        [Header("設定")]
        [SerializeField] private bool blockPlayer = true; // プレイヤーをブロックするか
        [SerializeField] private float pushBackForce = 5f; // 押し返す力

        private void Start()
        {
            // Box Collider 2Dがない場合は自動追加
            if (GetComponent<BoxCollider2D>() == null)
            {
                BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
                collider.isTrigger = true; // Triggerとして設定
                
                // RectTransformのサイズに合わせる
                RectTransform rectTransform = GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    collider.size = rectTransform.sizeDelta;
                }
            }
        }

        /// <summary>
        /// プレイヤーがSlider領域に侵入した時の処理
        /// </summary>
        private void OnTriggerStay2D(Collider2D other)
        {
            if (!blockPlayer) return;
            
            if (other.CompareTag("Player"))
            {
                PushPlayerOut(other);
            }
        }

        /// <summary>
        /// プレイヤーをSlider領域から押し出す
        /// </summary>
        private void PushPlayerOut(Collider2D playerCollider)
        {
            // プレイヤーの位置とSliderの位置を取得
            Vector2 playerPos = playerCollider.transform.position;
            Vector2 sliderPos = transform.position;
            
            // SliderのBoxCollider2Dのサイズを取得
            BoxCollider2D sliderCollider = GetComponent<BoxCollider2D>();
            if (sliderCollider == null) return;
            
            // Slider領域の境界を計算
            Vector2 sliderSize = sliderCollider.size;
            Vector2 sliderMin = sliderPos - sliderSize * 0.5f;
            Vector2 sliderMax = sliderPos + sliderSize * 0.5f;
            
            // プレイヤーのRigidbody2Dを取得
            Rigidbody2D playerRb = playerCollider.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 currentVelocity = playerRb.linearVelocity;
                
                // Playerが境界を超えようとしている場合のみ制限
                if (playerPos.x < sliderMin.x && currentVelocity.x > 0) // 左境界を右に移動しようとしている
                {
                    // X方向の速度をキャンセル
                    playerRb.linearVelocity = new Vector2(0, currentVelocity.y);
                }
                else if (playerPos.x > sliderMax.x && currentVelocity.x < 0) // 右境界を左に移動しようとしている
                {
                    // X方向の速度をキャンセル
                    playerRb.linearVelocity = new Vector2(0, currentVelocity.y);
                }
            }
        }

        /// <summary>
        /// ブロック機能のON/OFF切り替え
        /// </summary>
        public void SetBlockPlayer(bool block)
        {
            blockPlayer = block;
        }
    }
}