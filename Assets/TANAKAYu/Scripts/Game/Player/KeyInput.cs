using UnityEngine;

/// <summary>
/// キー入力を読み取って、返すクラス。
/// </summary>
public class KeyInput : IInput
{
    /// <summary>
    /// 入力値を記録しておく変数
    /// </summary>
    Vector2 inputValue;

    public Vector2 GetValue()
    {
        return inputValue;
    }

    public void Update()
    {
        inputValue.x = Input.GetAxisRaw("Horizontal");
        inputValue.y = Input.GetAxisRaw("Vertical");
        inputValue = 1.0f * inputValue.normalized;
    }
}
