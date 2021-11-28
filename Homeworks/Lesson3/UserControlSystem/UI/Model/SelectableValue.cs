using Code.Abstraction;
using System;
using UnityEngine;

namespace Code.UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "RTS/" + nameof(SelectableValue))]
    public sealed class SelectableValue : ValueBase<ISelectable>
    {
        public event Action<ISelectable> OnSelected;
        public override void SetValue(ISelectable value)
        {
            base.SetValue(value);
            OnSelected?.Invoke(value);
        }
    }
}