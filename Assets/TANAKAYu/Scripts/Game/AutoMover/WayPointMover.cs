using UnityEngine;

/// <summary>
/// ウェイポイントを設定して、そのルートを巡回する。
/// </summary>
public class WayPointMover : MonoBehaviour, IAutoMover
{
    static float GizmoRadius => 0.1f;
    static readonly Vector3 GizmoOffset = 0.5f * Vector3.back;

    public enum Type
    {
        /// <summary>
        /// 行ったり来たり
        /// </summary>
        PingPong,
        /// <summary>
        /// 端についたら、スタートから
        /// </summary>
        Loop,
    }

    [SerializeField, Tooltip("移動速度")]
    float speed = 2f;
    [SerializeField, Tooltip("通過点")]
    Vector3[] wayPoints = default;
    [SerializeField, Tooltip("終端についた時の動作")]
    Type type = Type.PingPong;
    [SerializeField, Tooltip("スタートしたら、目指す先のインデックス")]
    int startNextIndex = 0;

    int nextIndex;
    Rigidbody rb;
    Vector3 moveVector;

    /// <summary>
    /// インデックスの加算、減算方向
    /// </summary>
    int indexStep = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        nextIndex = startNextIndex;
        moveVector = wayPoints[nextIndex] - transform.position;
    }

    public void Move(float delta)
    {
        Vector3 toTarget = wayPoints[nextIndex] - transform.position;
        float toDistance = toTarget.magnitude;
        float moveStep = delta * speed;
        Vector3 moveVector = Vector3.zero;

        // 次の移動で到着する
        if (toDistance < moveStep)
        {
            NextIndex();
            if (toDistance > 0)
            {
                moveVector = toDistance * toTarget.normalized;
            }
        }
        else
        {
            // 移動継続
            moveVector = moveStep * toTarget.normalized;
        }

        rb.velocity = moveVector / delta;
    }

    /// <summary>
    /// インデックスを次の目的地へ移動
    /// </summary>
    void NextIndex()
    {
        nextIndex += indexStep;
        if (nextIndex < 0)
        {
            if (type == Type.PingPong)
            {
                indexStep = -indexStep;
                nextIndex += indexStep * 2;
            }
            else
            {
                nextIndex = wayPoints.Length - 1;
            }
        }
        else if (nextIndex >= wayPoints.Length)
        {
            if (type == Type.PingPong)
            {
                indexStep = -indexStep;
                nextIndex += indexStep * 2;
            }
            else
            {
                nextIndex = 0;
            }
        }
    }

    public void Stop()
    {
        rb.velocity = Vector3.zero;
    }

    void OnDrawGizmosSelected()
    {
        if (wayPoints == null) { return; }

        Gizmos.color = Color.red;
        for (int i = 0; i < wayPoints.Length; i++)
        {
            Gizmos.DrawSphere(wayPoints[i] + GizmoOffset, GizmoRadius);
        }
    }
}
