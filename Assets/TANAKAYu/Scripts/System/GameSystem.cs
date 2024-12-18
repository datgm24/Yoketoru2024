using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    [SerializeField]
    Fade fade = default;
    [SerializeField]
    SceneChanger sceneChanger = default;

    /// <summary>
    /// フェードを制御するインスタンス。
    /// </summary>
    public Fade Fade => fade;

    /// <summary>
    /// シーン切り替え処理を提供するクラス。
    /// </summary>
    public SceneChanger SceneChanger => sceneChanger;

    /// <summary>
    /// ステージ数
    /// </summary>
    public Stage Stage { get; private set; } = new();

    TinyAudio tinyAudio;
    /// <summary>
    /// 効果音再生クラス
    /// </summary>
    public TinyAudio TinyAudio
    {
        get
        {
            if (tinyAudio == null)
            {
                tinyAudio = FindObjectOfType<TinyAudio>();
            }
            return tinyAudio;
        }
    }

    readonly string[] loadTitleScene =
    {
        "Title",
    };

    private void Start()
    {
        string[] unloadScenes = new string[0];

#if UNITY_EDITOR
        // GameSystem以外のシーンを解放する
        unloadScenes = new string[SceneManager.sceneCount - 1];
        int index = 0;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            if (scene.name != gameObject.scene.name)
            {
                unloadScenes[index] = scene.name;
                index++;
            }
        }
#endif

        SceneChanger.Changed.AddListener(SetInstanceToSceneBehaviour);

        // 起動処理
        StartCoroutine(Fade.Cover(Color.black));
        SceneChanger.ChangeScene(loadTitleScene, unloadScenes);
    }

    /// <summary>
    /// シーンの管理クラスに、GameSystemのインスタンスを渡す。
    /// </summary>
    void SetInstanceToSceneBehaviour()
    {
        var sceneBehaviours = GameObject.FindObjectsOfType<SceneBehaviourBase>();
        for (int i = 0; i < sceneBehaviours.Length; i++)
        {
            sceneBehaviours[i].StartScene(this);
        }
    }
}
