using UnityEngine;

/// <summary>
/// アイテムの数を管理するクラス。
/// </summary>
public class ItemCounter
{
    int count;

    /// <summary>
    /// アイテムタグのオブジェクトを数える。
    /// </summary>
    public void CountItem()
    {
        var items = GameObject.FindGameObjectsWithTag("Item");
        count = items.Length;
    }

    /// <summary>
    /// アイテムを1つ減らす。
    /// </summary>
    /// <returns>全部取り切っていたら、trueを返す。</returns>
    public bool Decrement()
    {
        count--;
        return (count <= 0);
    }
}