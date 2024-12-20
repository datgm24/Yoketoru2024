using UnityEngine;

/// <summary>
/// 接触相手からIDamageableを取り出して、
/// 取り出せたらDamageを呼び出すクラス。
/// </summary>
public class Attacker : MonoBehaviour
{
    [SerializeField]
    Explosion explosionPrefab = default(Explosion);

    private void OnTriggerEnter(Collider other)
    {
        var damager = other.GetComponent<IDamageable>();
        if (damager != null)
        {
            var character = GetComponent<CharacterBehaviour>();
            if (!character.IsPlaying)
            {
                // プレイ中でなければなにもしない
                return;
            }

            // 相手にダメージを与える
            damager.Damage();

            // 爆発
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            var listner = GetComponent<IGameStateListener>();
            listner?.GameStateListenerDestroyed.Invoke(listner);
            Destroy(gameObject);
        }
    }
}
