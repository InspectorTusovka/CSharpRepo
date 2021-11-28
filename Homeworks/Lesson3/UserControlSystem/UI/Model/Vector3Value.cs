using System;
using UnityEngine;

namespace Code.UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "RTS/"+nameof(Vector3Value),order = 0)]
    public class Vector3Value : ValueBase<Vector3>
    {
        public Action<Vector3> OnNewValue;
        public override void SetValue(Vector3 value)
        {
            base.SetValue(value);
            OnNewValue?.Invoke(value);
        }
    }
}