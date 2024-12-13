using UnityEngine;
using UnityEngine.Events;

public class Credits : MonoBehaviour
{
    [SerializeField]
    Animator creditsAnimator = default;

    /// <summary>
    /// クレジットが消えたら、Invoke。
    /// </summary>
    public UnityEvent Hided = new();

    /// <summary>
    /// 操作可能状態
    /// </summary>
    bool canControl;

    private void Update()
    {
        if (!canControl)
        {
            return;
        }
        
        // 閉じるチェック
        if (Input.GetButtonDown("Cancel"))
        {
            Hide();
        }
    }

    /// <summary>
    /// クレジット画面を表示
    /// </summary>
    public void Show()
    {
        creditsAnimator.SetBool("Show", true);
    }

    /// <summary>
    /// クレジット画面を消す。
    /// </summary>
    public void Hide()
    {
        canControl = false;
        creditsAnimator.SetBool("Show", false);
    }

    /// <summary>
    /// 表示が完了したら、アニメから呼ぶ。
    /// </summary>
    public void OnShowed()
    {
        canControl = true;
    }

    /// <summary>
    /// アニメから、表示が消えた時に呼び出す
    /// </summary>
    public void OnHided()
    {
        Hided.Invoke();
    }
}
