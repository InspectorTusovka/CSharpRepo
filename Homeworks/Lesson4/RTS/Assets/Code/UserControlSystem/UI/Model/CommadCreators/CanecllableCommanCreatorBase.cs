using System;
using System.Threading;
using Code.Abstraction;
using Code.Utilities;
using Zenject;

namespace Code.UserControlSystem.UI.Model.CommandCreators
{
    public abstract class CancellableCommandCreatorBase<TCommand, TArgument> : CommandCreator<TCommand>
        where TCommand : ICommand
    {
        [Inject] private AssetsContext _context;
        [Inject] private IAwaitable<TArgument> _awaitableArgument;

        private CancellationTokenSource _cTokenSource;

        protected override async void ClassSpecificCommandCreation(Action<TCommand> creationCallback)
        {
            _cTokenSource = new CancellationTokenSource();
            try
            {
                var argument = await _awaitableArgument.WithCancellation(_cTokenSource.Token);
                creationCallback?.Invoke(_context.Inject(CreateCommand(argument)));
            }
            catch{ }
        }

        protected abstract TCommand CreateCommand(TArgument argument);

        public override void ProcessCancel()
        {
            base.ProcessCancel();

            if (_cTokenSource != null)
            {
                _cTokenSource.Cancel();
                _cTokenSource.Dispose();
                _cTokenSource = null;
            }
        }
    }
}