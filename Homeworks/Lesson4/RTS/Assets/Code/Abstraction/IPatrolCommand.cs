using UnityEngine;

namespace Code.Abstraction
{
    public interface IPatrolCommand : ICommand
    {
        public Vector3 TargetPosition { get; }
    }

}