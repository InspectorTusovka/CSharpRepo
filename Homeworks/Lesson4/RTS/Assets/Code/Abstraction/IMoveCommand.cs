using UnityEngine;

namespace Code.Abstraction
{
    public interface IMoveCommand : ICommand
    {
        public Vector3 Target { get; }
    }
}