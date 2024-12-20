/// <summary>
/// アイテムなどを拾う機能を提供する。
/// </summary>
public interface IGetter
{
    /// <summary>
    /// 基準点を渡す。
    /// </summary>
    /// <param name="point">基準点</param>
    void Get(int point);
}
