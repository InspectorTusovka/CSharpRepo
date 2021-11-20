using Code.Abstraction;
using System;
using UnityEngine;

namespace Code.UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "RTS/" + nameof(SelectableValue))]
    public sealed class SelectableValue : ScriptableObject
    {
        public ISelectable CurrentValue { get; private set; }
        public event Action<ISelectable> OnSelected;

        public void SetValue(ISelectable value)
        {
            CurrentValue = value;
            OnSelected?.Invoke(value);
        }
    }

}