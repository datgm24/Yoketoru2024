using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : SceneBehaviourBase
{
    static float UncoverSeconds => 1;

    public override void StartScene(GameSystem gameSystem)
    {
        base.StartScene(gameSystem);

        StartCoroutine(StartTitle());
    }

    IEnumerator StartTitle()
    {
        yield return GameSystem.Fade.Uncover(UncoverSeconds);

        // TODO: Start Title Control
    }
}
