using Code.Abstraction;
using UnityEngine;

namespace Code.UserControlSystem.UI.Model
{
    public  class ValueBase<T> : ScriptableObject
    {
        public T Currentvalue { get; private set; }

        public virtual void SetValue(T value)
        {
            Currentvalue = value;
        }
    }
}