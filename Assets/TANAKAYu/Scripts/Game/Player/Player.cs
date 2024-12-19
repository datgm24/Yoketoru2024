using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("速さ"), SerializeField]
    float speed = 20;

    enum State
    {
        None = -1,
        Play,
        Restart,
        Miss,
        Clear,
    }

    float cameraDistance = 0;
    Rigidbody rb;
    SimpleState<State> state = new(State.None);
    Vector3 startPosition;
    Vector3 startEuler;
    IInput mouseInput = new MouseInput();
    IInput controllerInput = new ControllerInput();

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startEuler = transform.eulerAngles;
    }

    void Start()
    {
        cameraDistance = Vector3.Distance(Camera.main.transform.position, transform.position);
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

        // TODO 移動

    }

    /// <summary>
    /// ゲームが開始して、操作可能になったら、Gameから呼び出す。
    /// </summary>
    public void GameStart()
    {
        state.SetNextState(State.Play);
    }

    /// <summary>
    /// リスタート
    /// </summary>
    public void Restart()
    {
        state.SetNextState(State.Restart);
    }
}
