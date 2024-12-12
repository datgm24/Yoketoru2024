using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// シーンを切り替える機能を提供するクラス。
/// </summary>
public class SceneChanger
{
    /// <summary>
    /// シーンの切り替えが完了したら、Invokeするイベント。
    /// </summary>
    public UnityEvent Changed { get; private set; } = new UnityEvent();

    /// <summary>
    /// 読み込みたいシーン名と、解放したいシーン名を受け取って、
    /// 非同期で処理を開始する。
    /// すべての処理が完了したら、ChangedイベントをInvoke。
    /// </summary>
    /// <param name="loadScenes"></param>
    /// <param name="unloadScenes"></param>
    public void ChangeScene(string[] loadScenes, string[] unloadScenes)
    {
        Debug.Log($"シーンの切り替え処理の開始");
    }
}
