using System;
using Code.Abstraction;
using Code.UserControlSystem.UI.Model.CommandCreators;
using Zenject;

namespace Code.UserControlSystem.UI.Model
{
    public class CommandButtonsModel
    {
        public event Action<ICommandExecutor> OnCommandAccepted;
        public event Action OnCommandSent;
        public event Action OnCommandCancel;

        [Inject] private CommandCreator<IProduceUnitCommand> _unitProducer;
        [Inject] private CommandCreator<IMoveCommand> _mover;
        [Inject] private CommandCreator<IAttackCommand> _attacker;
        [Inject] private CommandCreator<IPatrolCommand> _patroller;
        [Inject] private CommandCreator<IHoldCommand> _positionHolder;

        private bool _commandIsPending;

        public void OnCommandButtonClicked(ICommandExecutor executor)
        {
            if (_commandIsPending) 
                processOnCancel();
            _commandIsPending = true;
            OnCommandAccepted?.Invoke(executor);

            _unitProducer
                .ProcessCommandExecutor(executor, command => ExecuteCommandWrapper(executor, command));
            _attacker
                .ProcessCommandExecutor(executor, command => ExecuteCommandWrapper(executor, command));
            _positionHolder
                .ProcessCommandExecutor(executor, command => ExecuteCommandWrapper(executor, command));
            _mover
                .ProcessCommandExecutor(executor, command => ExecuteCommandWrapper(executor, command));
            _patroller
                .ProcessCommandExecutor(executor, command => ExecuteCommandWrapper(executor, command));
        }

        private void ExecuteCommandWrapper(ICommandExecutor executor, object command)
        {
            executor.ExecuteCommand(command);
            _commandIsPending = false;
            OnCommandSent?.Invoke();
        }

        public void OnSelectionChanged()
        {
            _commandIsPending = false;
            processOnCancel();
        }

        private void processOnCancel()
        {
            _unitProducer.ProcessCancel();
            _attacker.ProcessCancel();
            _positionHolder.ProcessCancel();
            _mover.ProcessCancel();
            _patroller.ProcessCancel();
            
            OnCommandCancel?.Invoke();
        }
    }
}