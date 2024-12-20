using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 得点機能を提供
/// </summary>
public class Scoreable : MonoBehaviour
{
    [Tooltip("得点"), SerializeField]
    int point = 100;

    private void OnTriggerEnter(Collider other)
    {
        var getter = other.GetComponent<IGetter>();
        if (getter == null) { return; }

        // プレイ中でなければ、発動しない
        var character = GetComponent<CharacterBehaviour>();
        if (!character.IsPlaying) { return; }

        // 相手が取れるやつなので、得点を渡す。
        getter.Get(point);
        character.GameStateListenerDestroyed.Invoke(character);
        Destroy(gameObject);
    }
}
