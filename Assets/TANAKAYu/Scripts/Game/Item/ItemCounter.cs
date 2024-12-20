using UnityEngine;

/// <summary>
/// アイテムの数を管理するクラス。
/// </summary>
public class ItemCounter
{
    public void CountItem()
    {
        Debug.Log($"アイテムを数える");
    }

    /// <summary>
    /// アイテムを1つ減らす。
    /// </summary>
    /// <returns>全部取り切っていたら、trueを返す。</returns>
    public bool Decrement()
    {
        return false;
    }
}
