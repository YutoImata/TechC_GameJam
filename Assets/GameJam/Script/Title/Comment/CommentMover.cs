using UnityEngine;

namespace Tech.C
{
    [System.Serializable]
    public class CommentMover
    {
        [Header("移動速度")]
        public float moveSpeed = 2f;
        [Header("中心座標（ターゲット）")]
        public Vector3 targetPosition = Vector3.zero;
        [Header("開始位置（Inspectorで調整可）")]
        public Vector3 startPosition = Vector3.zero;
    }
}