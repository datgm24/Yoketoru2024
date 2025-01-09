using UnityEngine;

/// <summary>
/// キャラクターを移動させる。
/// </summary>
public class CharacterMover : MonoBehaviour, IMover
{
    [SerializeField, Tooltip("最高速度")]
    float maxSpeed = 4f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 move)
    {
        rb.velocity = maxSpeed * move;

        if (move.magnitude > 0)
        {
            float angle = Vector2.SignedAngle(Vector3.up, rb.velocity);
            transform.Find("Pivot").eulerAngles = new Vector3(0, 0, angle);
            //transform.Find("Pivot").rotation = Quaternion.LookRotation(move, Vector3.back);
        }
    }
}
