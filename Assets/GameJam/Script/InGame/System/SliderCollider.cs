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
            
            // プレイヤーからSliderへの方向を計算
            Vector2 direction = (playerPos - sliderPos).normalized;
            
            // 方向がゼロの場合はデフォルトで左に押し出す
            if (direction.magnitude < 0.1f)
            {
                direction = Vector2.left;
            }
            
            // プレイヤーのRigidbody2Dを取得
            Rigidbody2D playerRb = playerCollider.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Velocityを使って押し出す
                playerRb.linearVelocity = direction * pushBackForce;
            }
            else
            {
                // Rigidbody2Dがない場合はTransformで直接移動
                Vector2 pushDistance = direction * pushBackForce * Time.deltaTime;
                playerCollider.transform.Translate(pushDistance);
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