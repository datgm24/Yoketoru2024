using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadInputBench : MonoBehaviour
{
    GamePadInput gamePadInput = new();

    void Update()
    {
        gamePadInput.Update();   
    }

    private void FixedUpdate()
    {
        Debug.Log($"{gamePadInput.GetValue()}");
    }
}
