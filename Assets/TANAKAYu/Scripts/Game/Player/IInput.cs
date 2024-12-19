using UnityEngine;

public interface IInput
{
    /// <summary>
    /// 前回から記録した移動量。
    /// 長さ0-1の範囲の移動方向ベクトル。
    /// </summary>
    Vector2 MoveInput { get; }

    /// <summary>
    /// 記録していた移動量をクリアする。
    /// </summary>
    void Clear();

    /// <summary>
    /// Updateから呼び出して、入力を記録する。
    /// </summary>
    void Update();
}
