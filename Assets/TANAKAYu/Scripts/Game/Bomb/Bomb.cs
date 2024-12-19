using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IGameStateListener
{
    public void OnClear()
    {
        Debug.Log($"Clear {name}");
    }

    public void OnGameOver()
    {
        Debug.Log($"GameOver {name}");
    }

    public void OnGameStart()
    {
        Debug.Log($"GameStart {name}");
    }
}
