namespace Tech.C.Interface
{
    /// <summary>
    /// ポーズ機能に対応するオブジェクトが実装するインターフェース
    /// </summary>
    public interface IPausable
    {
        /// <summary>
        /// ポーズ時に呼ばれる処理
        /// </summary>
        void OnPause();
        
        /// <summary>
        /// ポーズ解除時に呼ばれる処理
        /// </summary>
        void OnResume();
        
        /// <summary>
        /// ポーズ状態かどうかを取得
        /// </summary>
        bool IsPaused { get; }
    }
}
