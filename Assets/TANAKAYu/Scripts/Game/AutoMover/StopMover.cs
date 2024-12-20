using UnityEngine;

/// <summary>
/// 動かないキャラにアタッチする移動処理。
/// アタッチ忘れをエラーで検出るための、停止用のクラス。
/// </summary>
public class StopMover : MonoBehaviour, IAutoMover
{
    public void Move(float delta)
    {
    }

    public void Stop()
    {
    }
}
