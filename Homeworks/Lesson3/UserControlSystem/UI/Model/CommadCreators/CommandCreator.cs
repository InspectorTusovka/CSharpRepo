using Code.Abstraction;
using System;

namespace Code.UserControlSystem.UI.Model.CommandCreators
{
    public abstract class CommandCreator<T> where T : ICommand
    {
        public ICommandExecutor ProcessCommandExecutor(ICommandExecutor executor, Action<T> callback)
        {
            var classSpecificExecutor = executor as CommandExecutor<T>;
            if (classSpecificExecutor != null)
                ClassSpecificCommandCreation(callback);

            return executor;
        }

        protected abstract void ClassSpecificCommandCreation(Action<T> creationCallback);

        public virtual void ProcessCancel() { }
    }
}
