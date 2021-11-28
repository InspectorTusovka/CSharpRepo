using System;
using Code.Abstraction;
using Code.Utilities;
using Zenject;

namespace Code.UserControlSystem.UI.Model.CommandCreators
{
    public  class HoldCommandCommandCreator : CommandCreator<IHoldCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IHoldCommand> creationCallback)
        {
            
        }
    }
}