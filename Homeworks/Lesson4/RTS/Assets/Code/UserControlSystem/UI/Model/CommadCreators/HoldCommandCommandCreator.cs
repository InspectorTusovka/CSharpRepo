using System;
using Code.Abstraction;
using Code.UserControlSystem.CommandRealization;
using Code.Utilities;
using Zenject;

namespace Code.UserControlSystem.UI.Model.CommandCreators
{
    public  class HoldCommandCommandCreator : CommandCreator<IHoldCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void ClassSpecificCommandCreation(Action<IHoldCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new HoldCommand()));
        }
    }
}