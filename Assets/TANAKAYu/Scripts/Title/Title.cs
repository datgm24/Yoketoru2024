using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : SceneBehaviourBase
{
    static float UncoverSeconds => 1;

    enum State
    {
        None = -1,
        /// <summary>
        /// 操作受付中
        /// </summary>
        CanControl,
        /// <summary>
        /// クレジット画面表示中
        /// </summary>
        Credits,
        /// <summary>
        /// ゲーム開始
        /// </summary>
        GameStart,
    }

    SimpleState<State> state = new();
    Credits credits;

    public override void StartScene(GameSystem gameSystem)
    {
        base.StartScene(gameSystem);

        StartCoroutine(StartTitle());
    }

    IEnumerator StartTitle()
    {
        yield return GameSystem.Fade.Uncover(UncoverSeconds);

        // TODO: Start Title Control
        state.SetNextState(State.CanControl);
    }

    private void Update()
    {
        InitState();
        UpdateState();
    }

    /// <summary>
    /// クレジットボタンが押された
    /// </summary>
    public void OnCreditsClicked()
    {
        if (state.CurrentState == State.CanControl)
        {
            state.SetNextState(State.Credits);
        }
    }

    void InitState()
    {
        if (!state.ChangeState())
        {
            return;
        }

        switch (state.CurrentState)
        {
            case State.Credits:
                InitCredits();
                break;

            case State.GameStart:
                Debug.Log("GameStart");
                break;
        }
    }

    void UpdateState()
    {
        switch (state.CurrentState)
        {
            case State.CanControl:
                UpdateControl();
                break;
        }
    }

    void InitCredits()
    {
        Debug.Log($"Show Credits");
    }

    void UpdateControl()
    {
        if (Input.GetButtonDown("Submit"))
        {
            state.SetNextState(State.GameStart);
        }
        else if (Input.GetButtonDown("Credits"))
        {
            state.SetNextState(State.Credits);
        }
    }
}
