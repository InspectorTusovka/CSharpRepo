using System;
using Code.Utilities;
using UnityEngine;

namespace Code.UserControlSystem.UI.Model
{
    public abstract class ValueBase<T> : ScriptableObject, IAwaitable<T>
    {
        public Action<T> OnNewValue;
        public T Currentvalue { get; private set; }

        public virtual void SetValue(T value)
        {
            Currentvalue = value;
            OnNewValue?.Invoke(value);
        }

        public IAwaiter<T> GetAwaiter() => new NewValueNotifier<T>(this);

    }
}