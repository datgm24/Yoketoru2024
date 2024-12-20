using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 爆弾の状態などを総合的に管理するクラス。
/// </summary>
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
    IAutoMover autoMover;

    void Start()
    {
        attacker = GetComponent<IAttackable>();
        autoMover = GetComponent<IAutoMover>();
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
            case State.Explosion:
                Explosion();
                break;

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
