using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 爆弾やアイテムなどの状態を総合的に管理するクラス。
/// </summary>
public class CharacterBehaviour : MonoBehaviour, IGameStateListener
{
    enum State
    {
        None = -1,
        Play,
        End,
    }

    public UnityEvent<IGameStateListener> GameStateListenerDestroyed { get; private set; } = new();

    /// <summary>
    /// プレイ状態ならtrueを返す。
    /// </summary>
    public bool IsPlaying => state.CurrentState == State.Play;

    SimpleState<State> state = new(State.None);
    IAutoMover autoMover;

    void Start()
    {
        autoMover = GetComponent<IAutoMover>();
    }

    void FixedUpdate()
    {
        InitState();
        FixedUpdateState();
    }

    void InitState()
    {
        if (!state.ChangeState())
        {
            return;
        }

        switch(state.CurrentState)
        {
            case State.End:
                autoMover.Stop();
                break;
        }
    }

    void FixedUpdateState()
    {
        switch (state.CurrentState)
        {
            case State.Play:
                autoMover.Move(Time.deltaTime);
                break;
        }
    }

    public void OnClear()
    {
        state.SetNextState(State.End);
    }

    public void OnGameOver()
    {
        state.SetNextState(State.End);
    }

    public void OnGameStart()
    {
        state.SetNextState(State.Play);
    }

    public void OnReset()
    {
    }
}
