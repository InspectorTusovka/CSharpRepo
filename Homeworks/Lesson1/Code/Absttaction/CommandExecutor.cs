using UnityEngine;

namespace Code.Abstraction
{
    public abstract class CommandExecutor<T> : MonoBehaviour, ICommandExecutor where T : ICommand
    {
        public void ExecuteCommand(object command) => ExecuteSpecificCommand((T)command);

        public abstract void ExecuteSpecificCommand(T command);

    }
}