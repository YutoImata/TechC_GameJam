using UnityEngine;

namespace Tech.C.Item
{
    public class ItemMover : MonoBehaviour
    {
        [SerializeField] private ItemMoveType moveType;
        public float fallSpeed = 2f;

        [SerializeField] private Vector2 zigzagDirection = Vector2.right; // Inspectorで向き調整可
        [SerializeField] private float zigzagAmplitude = 1.5f;            // 振幅
        [SerializeField] private float zigzagFrequency = 2f;              // 周波数

        [SerializeField] private GameObject playerObject;

        private float zigzagTime = 0f;

        /// <summary>
        /// アイテムを動かす処理
        /// </summary>
        public void MoveItem()
        {
            switch (moveType)
            {
                case ItemMoveType.StraightDown:
                    transform.position += Vector3.down * fallSpeed * Time.deltaTime;
                    break;
                case ItemMoveType.ZigZag:
                    zigzagTime += Time.deltaTime;
                    float offset = Mathf.Sin(zigzagTime * zigzagFrequency) * zigzagAmplitude;
                    // Vector2 → Vector3 に変換して加算
                    Vector3 zigzagMove = Vector3.down * fallSpeed * Time.deltaTime + new Vector3(zigzagDirection.x, zigzagDirection.y, 0f) * offset * Time.deltaTime;
                    transform.position += zigzagMove;
                    break;
                case ItemMoveType.ToPlayer:
                    if (playerObject != null)
                    {
                        Vector3 dir = (playerObject.transform.position - transform.position).normalized;
                        transform.position += dir * fallSpeed * Time.deltaTime;
                    }
                    else
                    {
                        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
                    }
                    break;
            }
        }
    }
}