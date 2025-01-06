using UnityEngine;

public class InputControllerBench : MonoBehaviour
{
    InputController inputController = new();

    void Update()
    {
        inputController.Update();
    }

    void FixedUpdate()
    {
        var move = inputController.GetAndClear();
        Debug.Log($"{move}");
    }
}
