using UnityEngine;

namespace Tech.C
{
     /// <summary>
    /// アイテムが動くパターンを列挙型で定義
    /// </summary>
    public enum ItemMoveType
    {
        StraightDown,
        ZigZag,
        ToPlayer,
    }
}