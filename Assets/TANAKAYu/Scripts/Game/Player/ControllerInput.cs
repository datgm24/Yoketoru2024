using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キーボードやゲームパッドの入力を受け取るクラス。
/// </summary>
public class ControllerInput : IInput
{
    public Vector2 MoveInput { get; private set; }

    public void Clear()
    {
        MoveInput = Vector2.zero;
    }

    public void Update()
    {
        MoveInput.Set(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));
    }
}
