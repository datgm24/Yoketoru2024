using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IGameStateListener
{
    [SerializeField]
    Explosion explosionPrefab = default(Explosion);

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
            attacker.Attacked.AddListener(OnExplosion);
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

        switch(state.CurrentState)
        {
            case State.Explosion:
                Explosion();
                break;
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
    /// 爆発処理
    /// </summary>
    void Explosion()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    /// <summary>
    /// 爆発設定
    /// </summary>
    void OnExplosion()
    {
        if (state.CurrentState == State.Play)
        {
            state.SetNextStateForce(State.Explosion);
        }
    }
}
