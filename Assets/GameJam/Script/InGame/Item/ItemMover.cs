using UnityEngine;

namespace Tech.C.Item
{
    public class ItemMover : MonoBehaviour
    {
        [SerializeField] private MoveType moveType;
        [SerializeField] private float fallSpeed = 2f;

        /// <summary>
        /// アイテムを動かす処理
        /// </summary>
        public void MoveItem()
        {
            switch (moveType)
            {
                case MoveType.StraightDown:
                    transform.position += Vector3.down * fallSpeed * Time.deltaTime;
                    break;
                case MoveType.ZigZag:
                    // ジグザグ移動処理を書く
                    break;
                case MoveType.ToPlayer:
                    // プレイヤー方向への移動処理を書く
                    break;
            }
        }
    }
}