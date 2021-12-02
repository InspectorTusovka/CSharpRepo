using Code.Abstraction;
using UnityEngine;

namespace Code.UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "RTS/" + nameof(AttackableValue))]
    public sealed class AttackableValue : ValueBase<IAttackable> { }
}