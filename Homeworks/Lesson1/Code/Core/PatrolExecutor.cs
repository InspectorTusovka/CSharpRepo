using UnityEngine;
using Code.Abstraction;

namespace Code.Core
{
    public class PatrolExecutor : CommandExecutor<IPatrolCommand>
    {
        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"Patrolling");
        }
    }

}
