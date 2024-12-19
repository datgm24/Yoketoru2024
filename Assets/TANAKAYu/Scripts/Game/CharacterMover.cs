using UnityEngine;

public class CharacterMover : MonoBehaviour, IMover
{
    [SerializeField, Tooltip("速さ")]
    float speed = 20;

    Rigidbody rb;
    Transform pivotTransform;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pivotTransform = transform.Find("Pivot");
    }

    public void Move(Vector2 move)
    {
        rb.velocity = speed * move;
        UpdateForward(move);
    }

    /// <summary>
    /// 前方を向く
    /// </summary>
    void UpdateForward(Vector2 move)
    {
        if (move.magnitude < 0.1f)
        {
            return;
        }

        // 移動があったら、その方向を向く
        Vector3 euler = pivotTransform.eulerAngles;
        float angle = Mathf.Atan2(-move.x, move.y) * Mathf.Rad2Deg;
        euler.z = angle;
        pivotTransform.eulerAngles = euler;
    }
}
