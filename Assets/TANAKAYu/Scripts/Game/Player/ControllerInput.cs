using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キーボードやゲームパッドの入力を受け取るクラス。
/// </summary>
public class ControllerInput : IInput
{
    Vector2 move;
    public Vector2 MoveInput => currentSpeed * move.normalized / maxSpeed;

    float normalSpeed = 4f;
    float highSpeed = 8f;
    float maxSpeed = 20f;
    float currentSpeed = 0;

    public void Clear()
    {
        move = Vector2.zero;
        currentSpeed = normalSpeed;
    }

    public void Update()
    {
        Vector2 currentInput = Vector2.zero;
        currentInput.Set(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
        if (currentInput.magnitude > move.magnitude)
        {
            move = currentInput;
        }

        // スピードチェック
        if (Input.GetButton("SpeedUp"))
        {
            currentSpeed = highSpeed;
        }
    }
}
