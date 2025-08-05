using UnityEngine;

namespace Tech.C.Item
{
    public class ItemMover : MonoBehaviour
    {
        [SerializeField] private ItemMoveType moveType;
        public float fallSpeed = 2f;

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
                    // ジグザグ移動処理を書く
                    break;
                case ItemMoveType.ToPlayer:
                    // プレイヤー方向への移動処理を書く
                    break;
            }
        }
    }
}