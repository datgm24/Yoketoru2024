using UnityEngine;

/// <summary>
/// マウス入力を読み取って、返すクラス。
/// </summary>
public class MouseInput : IInput
{
    /// <summary>
    /// 入力値を記録しておく変数
    /// </summary>
    Vector2 inputValue;

    public Vector2 GetValue()
    {
        Vector2 value = inputValue;
        inputValue = Vector2.zero;
        return value;
        
    }

    public void Update()
    {
        inputValue.x += Input.GetAxis("Mouse X");
        inputValue.y += Input.GetAxis("Mouse Y");
    }
}
