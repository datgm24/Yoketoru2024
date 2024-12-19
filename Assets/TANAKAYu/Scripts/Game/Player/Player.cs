using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    enum State
    {
        None = -1,
        Play,
        Restart,
        Miss,
        Clear,
    }

    Rigidbody rb;
    SimpleState<State> state = new(State.None);
    Vector3 startPosition;
    Vector3 startEuler;
    IInput mouseInput = new MouseInput();
    IInput controllerInput = new ControllerInput();
    IMover mover;
    Game gameInstance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mover = GetComponent<IMover>();
        startPosition = transform.position;
        startEuler = transform.eulerAngles;
    }

    private void Update()
    {
        UpdateState();
    }

    // FixedUpdate = 物理処理をするための固定更新処理
    void FixedUpdate()
    {
        InitState();
        FixedUpdateState();
    }

    /// <summary>
    /// ゲームが開始して、操作可能になったら、Gameから呼び出す。
    /// </summary>
    public void GameStart(Game game)
    {
        gameInstance = game;
        state.SetNextState(State.Play);
    }

    /// <summary>
    /// リスタート
    /// </summary>
    public void Restart()
    {
        state.SetNextState(State.Restart);
    }

    public void Damage()
    {
        if (state.CurrentState == State.Play)
        {
            state.SetNextState(State.Miss);
        }
    }

    void InitState()
    {
        if (!state.ChangeState())
        {
            return;
        }

        switch(state.CurrentState)
        {
            case State.Restart:
                transform.position = startPosition;
                transform.eulerAngles = startEuler;
                rb.position = startPosition;
                mover.Move(Vector2.zero);
                break;

            case State.Miss:
                gameInstance.RequestGameOver();
                mover.Move(Vector2.zero);
                break;

            case State.Clear:
                mover.Move(Vector2.zero);
                break;
        }
    }

    void UpdateState()
    {
        switch(state.CurrentState)
        {
            case State.Play:
                mouseInput.Update();
                controllerInput.Update();
                break;
        }
    }

    void FixedUpdateState()
    {
        switch(state.CurrentState)
        {
            case State.Play:
                FixedUpdatePlay();
                break;
        }
    }

    void FixedUpdatePlay()
    {
        Vector2 moveInput = controllerInput.MoveInput;
        if (Mathf.Approximately(moveInput.magnitude, 0f))
        {
            // キーやコントローラーの入力がない場合、マウスの入力を使う
            moveInput = mouseInput.MoveInput;
        }
        controllerInput.Clear();
        mouseInput.Clear();

        // 移動
        mover.Move(moveInput);
    }
}
