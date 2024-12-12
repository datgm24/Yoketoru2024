using UnityEngine;
public class SETest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TinyAudio.PlaySE(TinyAudio.SE.Click);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TinyAudio.PlaySE(TinyAudio.SE.Start);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TinyAudio.PlaySE(TinyAudio.SE.Item);
        }
    }
}