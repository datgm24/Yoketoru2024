using UnityEngine;

public class GamePadInput : IInput
{
    Vector2 inputValue;

    public Vector2 GetValue()
    {
        return inputValue;
    }

    public void Update()
    {
        inputValue.x = Input.GetAxis("HorizontalAnalog");
        inputValue.y = Input.GetAxis("VerticalAnalog");
    }
}
