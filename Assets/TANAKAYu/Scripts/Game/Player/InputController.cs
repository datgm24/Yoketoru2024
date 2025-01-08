using UnityEngine;

public class InputController
{
    IInput[] inputs =
    {
        new KeyInput(),
        new GamePadInput(),
        new MouseInput(),
    };

    public void Update()
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i].Update();
        }
    }

    public Vector2 GetValue()
    {
        Vector2 move = Vector2.zero;

        for (int i = 0;i<inputs.Length;i++)
        {
            var this_move = inputs[i].GetValue();
            if (this_move.magnitude > move.magnitude)
            {
                move = this_move;
            }
        }
        return move;
    }
}
