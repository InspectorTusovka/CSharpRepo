using Code.Abstraction;
using Code.UserControlSystem.CommandRealization;
using Code.Utilities;
using System;
using Zenject;

namespace Code.UserControlSystem.UI.Model.CommandCreators
{
    public class ProduceUnitCommandCommandCreator : CommandCreator<IProduceUnitCommand>
    {
        [Inject] private AssetsContext _context;
        protected override void ClassSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new ProduceUnitCommandHeir()));
        }
    }
}
