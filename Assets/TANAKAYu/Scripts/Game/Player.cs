using System.Collections;
using System.Collections.Generic;
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
    }

    float cameraDistance = 0;
    Rigidbody rb;
    SimpleState<State> state = new(State.None);
    Vector3 startPosition;
    Vector3 startEuler;

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

    // FixedUpdate = 物理処理をするための固定更新処理
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
                //UpdatePlay();
                break;
        }
    }

    void UpdatePlay()
    {
        var mp = Input.mousePosition;
        mp.z = cameraDistance;
        var wp = Camera.main.ScreenToWorldPoint(mp);

        var to = wp - rb.position;
        if (to.magnitude < 0.01f)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            float step = speed * Time.deltaTime;
            float dist = Mathf.Min(to.magnitude, step);
            float v = dist / Time.deltaTime;
            rb.velocity = v * to.normalized;
        }

        //transform.position = wp;
        //Debug.Log(wp);
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
