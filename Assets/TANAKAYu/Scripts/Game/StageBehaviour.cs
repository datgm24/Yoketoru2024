using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ全体を管理するスクリプト
/// </summary>
public class StageBehaviour : MonoBehaviour
{
    List<IGameStateListener> gameStateListeners = new List<IGameStateListener>();

    void Start()
    {
        FindGameStateListeners();
    }

    /// <summary>
    /// ゲームスタートを通知する。
    /// </summary>
    public void CallGameStart()
    {
        for (int i = 0; i < gameStateListeners.Count; i++)
        {
            gameStateListeners[i].OnGameStart();
        }
    }

    /// <summary>
    /// ゲームオーバーを通知
    /// </summary>
    public void CallGameOver()
    {
        for (int i = 0; i < gameStateListeners.Count; i++)
        {
            gameStateListeners[i].OnGameOver();
        }
    }

    /// <summary>
    /// クリアを通知
    /// </summary>
    public void CallClear()
    {
        for (int i = 0; i < gameStateListeners.Count; i++)
        {
            gameStateListeners[i].OnClear();
        }
    }

    void FindGameStateListeners()
    {
        gameStateListeners.Clear();
        var rootObejcts = gameObject.scene.GetRootGameObjects();
        for (int i = 0; i < rootObejcts.Length; i++)
        {
            var listeners = rootObejcts[i].GetComponentsInChildren<IGameStateListener>();
            for (int j=0; j<listeners.Length; j++)
            {
                gameStateListeners.Add(listeners[j]);
            }
        }
    }
}
