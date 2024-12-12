using System.Collections;
using UnityEngine;

public class Fade : MonoBehaviour
{
    /// <summary>
    /// 画面を隠す処理のコルーチン。
    /// </summary>
    /// <param name="color">色</param>
    /// <param name="time">隠す秒数。0のときは即時</param>
    public IEnumerator Cover(Color color, float time = 0)
    {
        Debug.Log($"画面を隠す処理を開始。");
        yield return null;
    }

    /// <summary>
    /// 画面を表示。
    /// </summary>
    /// <param name="time">演出秒数。0や省略で即時</param>
    public IEnumerator Uncover(float time = 0)
    {
        Debug.Log($"画面を表示する処理を開始。");
        yield return null;
    }
}
