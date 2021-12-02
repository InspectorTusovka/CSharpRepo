using Code.Abstraction;
using UnityEngine;

namespace Code.Core
{
    public class AttackExecutor : CommandExecutor<IAttackCommand>
    {
        public override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"{name} attacks {command.Target}!");
        }
    }
}