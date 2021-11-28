using UnityEngine;
using Code.Abstraction;

namespace Code.Core
{
    public class PatrolExecutor : CommandExecutor<IPatrolCommand>
    {
        /// <summary>
        /// Реализуем метод патрулирования как передвижение юнита (в дальнейшем) между точкой-целью
        /// полученной кликом ПКМ и текущей позицией юнита
        /// </summary>
        /// <param name="command"></param>
        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} patrols area between {command.TargetPosition} and {gameObject.transform.position}");
        }
    }

}
