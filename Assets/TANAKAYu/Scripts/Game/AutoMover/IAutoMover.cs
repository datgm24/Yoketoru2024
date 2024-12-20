/// <summary>
/// 爆弾やアイテムなどの移動処理に実装するインターフェース
/// </summary>
public interface IAutoMover
{
    /// <summary>
    /// 物理更新時に呼び出して、移動処理。
    /// </summary>
    /// <param name="delta">経過秒数</param>
    void Move(float delta);

    /// <summary>
    /// 移動停止。
    /// </summary>
    void Stop();
}
