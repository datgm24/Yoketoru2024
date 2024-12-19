using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IAttackableからダメージを受けるインターフェース。
/// </summary>
public interface IDamageable
{
    /// <summary>
    /// ダメージを受ける。
    /// </summary>
    void Damage();
}
