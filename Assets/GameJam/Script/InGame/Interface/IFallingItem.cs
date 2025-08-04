namespace Tech.C.Interface
{
    /// <summary>
    /// 落下アイテムの共通インターフェース
    /// </summary>
    public interface IFallingItem
    {
        void Fall(); // 毎フレームの落下・移動処理
        void OnFallen(); // 落下時の処理
        void OnCollected(); // プレイヤー取得時の処理
    }
}