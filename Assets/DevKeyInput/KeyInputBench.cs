using UnityEngine;

public class KeyInputBench : MonoBehaviour
{
    KeyInput keyInput = new();

    void Update()
    {
        keyInput.Update();
    }

    private void FixedUpdate()
    {
        Debug.Log($"{keyInput.GetValue()}");
    }
}
