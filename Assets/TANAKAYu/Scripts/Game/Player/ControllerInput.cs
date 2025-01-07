using UnityEngine;

/// <summary>
/// キーボードやゲームパッドの入力を受け取るクラス。
/// </summary>
public class ControllerInput : IInput
{
    Vector2 move;

    float normalSpeed = 4f;
    float highSpeed = 8f;
    float maxSpeed = 20f;
    float currentSpeed = 0;

    public Vector2 GetValue()
    {
        Vector2 res = currentSpeed * move / maxSpeed;
        move = Vector2.zero;
        currentSpeed = normalSpeed;
        return res;
    }

    public void Update()
    {
        Vector2 digitalInput = Vector2.zero;
        digitalInput.Set(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
        digitalInput = digitalInput.normalized;

        Vector2 analogInput = Vector2.zero;
        analogInput.Set(
            Input.GetAxis("HorizontalAnalog"),
            Input.GetAxis("VerticalAnalog"));

        Vector2 newInput = (digitalInput.magnitude > analogInput.magnitude) ? digitalInput : analogInput;
        if (newInput.magnitude > move.magnitude)
        {
            move = newInput;
        }

        // スピードチェック
        if (Input.GetButton("SpeedUp"))
        {
            currentSpeed = highSpeed;
        }
    }

}
