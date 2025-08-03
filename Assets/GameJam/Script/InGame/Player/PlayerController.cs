using UnityEngine;
using UnityEngine.InputSystem;
using Tech.C.Bullet;

namespace Tech.C.Player
{
    /// <summary>
    /// 入力を受けて、プレイヤーを移動させる処理
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private BulletType bulletType = BulletType.Normal;
        private Vector2 moveInput;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// 入力を取得して移動の方向を決める
        /// </summary>
        /// <param name="context"></param>
        public void OnMove(InputAction.CallbackContext context)
        {
            // 横方向のみ取得
            float x = context.ReadValue<Vector2>().x;
            moveInput = new Vector2(x, 0);
        }


        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                BulletManager.I.SpawnBullet(bulletType, transform.position);
            }
        }

        void FixedUpdate()
        {
            MovePlayer();
        }

        /// <summary>
        /// プレイヤーの移動を行う
        /// </summary>
        private void MovePlayer()
        {
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        }
    }
}