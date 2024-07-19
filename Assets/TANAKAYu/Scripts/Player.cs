using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("速さ"), SerializeField]
    float speed = 20;

    float cameraDistance = 0;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraDistance = Vector3.Distance(Camera.main.transform.position, transform.position);
    }

    // FixedUpdate = 物理処理をするための固定更新処理
    void FixedUpdate()
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
}
