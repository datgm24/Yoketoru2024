using UnityEngine;

public class ReflectionMover : MonoBehaviour, IAutoMover
{
    static float MinimumSpeed => 0.01f;

    [Tooltip("移動方向"), SerializeField]
    Vector3 firstDirection = Vector3.right;
    [Tooltip("移動速度"), SerializeField]
    float speed = 2;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.velocity = speed * firstDirection.normalized;
    }

    public void Move(float delta)
    {
        if (rb.velocity.magnitude < MinimumSpeed)
        {
            //rb.velocity = speed * firstDirection.normalized;
        }
        /*
        else
        {
            // 速度を維持
            rb.velocity = speed * rb.velocity.normalized;
        }
        */
    }

    public void Stop()
    {
        rb.velocity = Vector3.zero;
    }
}
