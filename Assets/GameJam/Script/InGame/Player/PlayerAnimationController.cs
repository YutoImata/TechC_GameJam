using UnityEngine;

namespace Tech.C
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        /// <summary>
        /// Idle状態にする
        /// </summary>
        public void SetIdle()
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingRight", false);
        }

        /// <summary>
        /// 右移動状態にする
        /// </summary>
        public void SetMoveRight()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingRight", true);
        }

        /// <summary>
        /// 左移動状態にする
        /// </summary>
        public void SetMoveLeft()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isMovingLeft", true);
            animator.SetBool("isMovingRight", false);
        }
    }
}