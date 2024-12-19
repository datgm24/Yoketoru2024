using UnityEngine;

/// <summary>
/// マウスの入力を記録して、移動量を返す。
/// </summary>
public class MouseInput : IInput
{
    [SerializeField, Tooltip("最大移動距離")]
    float magnitudeMax = 100;

    Vector2 move = Vector2.zero;
    public Vector2 MoveInput { get; private set; } = Vector2.zero;

    public void Clear()
    {
        move = Vector2.zero;
    }

    public void Update()
    {
        move.x += Input.GetAxis("Mouse X");
        move.y += Input.GetAxis("Mouse Y");
        if (move.magnitude > magnitudeMax)
        {
            move = move.normalized * magnitudeMax;
        }
    }
}
