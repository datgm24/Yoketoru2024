#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : SceneBehaviourBase
{
    static float StartUncoverSeconds => 1f;

    enum State
    {
        None = -1,
        CountDown,
        Play,
        GameOver,
        Clear,
        Retry,
        ToTitle,
        NextStage,
        SceneDone,
    }

    SimpleState<State> state = new(State.None);

    public override void StartScene(GameSystem gameSystem)
    {
        base.StartScene(gameSystem);

        StartCoroutine(GameStartCoroutine());
    }

    IEnumerator GameStartCoroutine()
    {
        yield return GameSystem.Fade.Uncover(StartUncoverSeconds);
        state.SetNextStateForce(State.CountDown);
    }

    private void Update()
    {
        InitState();
        UpdateState();
    }

    void InitState()
    {
        if (!state.ChangeState())
        {
            return;
        }

        switch (state.CurrentState)
        {
            case State.CountDown:
                Debug.Log($"カウントダウン");
                state.SetNextState(State.Play);
                break;

            case State.GameOver:
                StartCoroutine(ShowOverlapScene("GameOver"));
                break;

            case State.Clear:
                StartCoroutine(ShowOverlapScene("Clear"));
                break;

            case State.Retry:
                Debug.Log($"Retry");
                break;

            case State.ToTitle:
                Debug.Log($"ToTitle");
                break;

            case State.NextStage:
                Debug.Log($"NextStage");
                break;
        }
    }

    /// <summary>
    /// タイトル切り替えを要求する。
    /// </summary>
    public void RequestToTitle()
    {
        state.SetNextState(State.ToTitle);
    }

    /// <summary>
    /// リトライを要求する。
    /// </summary>
    public void RequestRetry()
    {
        state.SetNextState(State.Retry);
    }

    /// <summary>
    /// 次のステージへの切り替えを要求する。
    /// </summary>
    public void RequestNextStage()
    {
        state.SetNextState(State.NextStage);
    }

    /// <summary>
    /// ゲームオーバー表示
    /// </summary>
    IEnumerator ShowOverlapScene(string sceneName)
    {
        var async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        yield return async;
        yield return null;

        var overlap = FindObjectOfType<OverlapScene>();
        overlap.SetGameInstance(this);
        overlap.Show();
    }

    void UpdateState()
    {
        switch (state.CurrentState)
        {
            case State.Play:
                UpdatePlay();
                break;
        }
    }

    void UpdatePlay()
    {
        UpdateDebugKey();
    }

    [System.Diagnostics.Conditional("DEBUG_KEY")]
    void UpdateDebugKey()
    {
        if (Input.GetButtonDown("DebugGameOver"))
        {
            state.SetNextState(State.GameOver);
        }
        else if (Input.GetButtonDown("DebugClear"))
        {
            state.SetNextState(State.Clear);
        }
    }
}
