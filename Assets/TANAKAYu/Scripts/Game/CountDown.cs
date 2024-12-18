using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

/// <summary>
/// カウントダウンを制御
/// </summary>
public class CountDown : MonoBehaviour
{
    public UnityEvent GameStarted = new();

    TextMeshProUGUI countDownText;
    Animator animator;

    int count = 3;
    TinyAudio tinyAudio;

    private void Awake()
    {
        countDownText = GetComponent<TextMeshProUGUI>();
        countDownText.text = $"{count}";
    }

    /// <summary>
    /// カウントダウンを開始するときに呼び出す。
    /// </summary>
    public void StartCountDown(TinyAudio audio)
    {
        GetComponent<Animator>().SetTrigger("CountDown");
        tinyAudio = audio;
    }

    /// <summary>
    /// アニメから、テキストを入れ替える
    /// </summary>
    public void ChangeText()
    {
        count--;
        if (count > 0)
        {
            countDownText.text = $"{count}";
        }
        else
        {
            countDownText.text = "START!!";
        }
    }

    /// <summary>
    /// カウントダウンの効果音
    /// </summary>
    public void CountDownSE()
    {
        tinyAudio.PlaySE(TinyAudio.SE.CountDown);
    }

    /// <summary>
    /// ゲーム開始
    /// </summary>
    public void GameStart()
    {
        tinyAudio.PlaySE(TinyAudio.SE.StartPlay);
        GameStarted.Invoke();
    }
}
