using UnityEngine.Events;

public interface IAttackable
{
    /// <summary>
    /// 攻撃が成功したときにInvokeするイベント。
    /// </summary>
    UnityEvent Attacked { get; }
}
