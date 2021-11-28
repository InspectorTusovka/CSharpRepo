using Code.Abstraction;
using UnityEngine;

namespace Code.UserControlSystem.CommandRealization
{
    public class PatrolCommand : IPatrolCommand
    {
        public Vector3 TargetPosition { get; }
        public PatrolCommand(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
        }
    }
}