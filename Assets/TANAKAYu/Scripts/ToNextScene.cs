using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    [Tooltip("切り替えたいシーン名"), SerializeField]
    string nextScene = default;

    bool sceneChanged;

    public void ChangeScene()
    {
        if (sceneChanged)
        {
            return;
        }

        sceneChanged = true;
        TinyAudio.PlaySE(TinyAudio.SE.Start);
        SceneManager.LoadScene(nextScene);
    }
}
