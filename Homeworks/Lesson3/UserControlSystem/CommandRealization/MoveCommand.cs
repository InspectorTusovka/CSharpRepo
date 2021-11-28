using Code.Abstraction;
using UnityEngine;

namespace Code.UserControlSystem.CommandRealization
{
    public class MoveCommand : IMoveCommand
    {
        public Vector3 Target { get; }
        
        public MoveCommand(Vector3 target)
        {
            Target = target;
        }
    }
}