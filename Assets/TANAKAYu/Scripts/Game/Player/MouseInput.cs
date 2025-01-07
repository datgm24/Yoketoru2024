using UnityEngine;

/// <summary>
/// マウスの入力を記録して、移動量を返す。
/// </summary>
public class MouseInput : IInput
{
    static float MagnitudeMax => 1f;

    Vector2 move = Vector2.zero;

    public void Update()
    {
        move.x += Input.GetAxis("Mouse X");
        move.y += Input.GetAxis("Mouse Y");
        if (move.magnitude > MagnitudeMax)
        {
            move = move.normalized * MagnitudeMax;
        }
    }

    public Vector2 GetValue()
    {
        Vector2 res = move;
        move = Vector2.zero;
        return res;
    }
}
