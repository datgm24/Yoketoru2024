using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IGameStateListener
{
    enum State
    {
        None = -1,
        Play,
        Explosion,
        End,
    }

    SimpleState<State> state = new(State.None);
    IAttackable attacker;

    void Start()
    {
        attacker = GetComponent<IAttackable>();
        if (attacker != null)
        {
            attacker.Attacked.AddListener(Explosion);
        }
    }

    void OnDestroy()
    {
        if (attacker != null)
        {
            attacker.Attacked.RemoveAllListeners();
            attacker = null;
        }
    }

    void FixedUpdate()
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
    }

    void UpdateState()
    {
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

    /// <summary>
    /// 爆発設定
    /// </summary>
    void Explosion()
    {
        if (state.CurrentState == State.Play)
        {
            state.SetNextStateForce(State.Explosion);
        }
    }


}
