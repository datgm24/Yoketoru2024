/// <summary>
/// ゲームの状態変化を受け取るリスナー。
/// </summary>
public interface IGameStateListener
{
    /// <summary>
    /// ゲームが開始されたときに呼び出される。
    /// </summary>
    void OnGameStart();

    /// <summary>
    /// ゲームオーバーになったときに呼び出される。
    /// </summary>
    void OnGameOver();

    /// <summary>
    /// クリアしたときに呼び出される。
    /// </summary>
    void OnClear();
}
