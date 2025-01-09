using System.Collections;
using UnityEngine;

public class CharacterMoverBench : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        Vector2[] moveVectors =
        {
            Vector2.right,
            new Vector2(1,-1).normalized,
            Vector2.down,
            new Vector2(-1,-1).normalized,
            Vector2.left,
            new Vector2(-1,1).normalized,
            Vector2.up,
            new Vector2(1,1).normalized,
        };

        var mover = GetComponent<IMover>();
        var wait = new WaitForFixedUpdate();

        while(true)
        {
            for (int i = 0; i < moveVectors.Length;i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    mover.Move(moveVectors[i]);
                    yield return wait;
                }
            }
        }
    }
}
