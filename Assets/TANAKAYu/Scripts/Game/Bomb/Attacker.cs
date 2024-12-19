using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 接触相手からIDamageableを取り出して、
/// 取り出せたらDamageを呼び出すクラス。
/// </summary>
public class Attacker : MonoBehaviour, IAttackable
{
    public UnityEvent Attacked { get; private set; } = new();

    private void OnTriggerEnter(Collider other)
    {
        var damager = other.GetComponent<IDamageable>();
        if (damager != null)
        {
            damager.Damage();
            Attacked.Invoke();
        }
    }
}
