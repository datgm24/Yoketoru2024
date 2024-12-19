using UnityEngine;

public class CharacterMover : MonoBehaviour, IMover
{
    [SerializeField, Tooltip("速さ")]
    float speed = 20;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 move)
    {
        rb.velocity = speed * move;
    }
}
