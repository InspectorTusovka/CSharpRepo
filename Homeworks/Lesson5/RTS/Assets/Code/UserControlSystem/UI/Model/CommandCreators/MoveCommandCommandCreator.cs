using Code.Abstraction;
using Code.UserControlSystem.CommandRealization;
using UnityEngine;

namespace Code.UserControlSystem.UI.Model.CommandCreators
{
    public sealed class MoveCommandCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand CreateCommand(Vector3 argument)
            => new MoveCommand(argument);
    }
}