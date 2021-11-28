using Code.Abstraction;
using UnityEngine;

namespace Code.Core
{
    public class MoveExecutor : CommandExecutor<IMoveCommand>
    {
        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"{name} is moving to {command.Target}");
        }
    }

}
