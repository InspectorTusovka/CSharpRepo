using Code.Abstraction;
using Code.UserControlSystem.CommandRealization;
using UnityEngine;

namespace Code.UserControlSystem.UI.Model.CommandCreators
{
    public  class PatrolCommandCommandCreator : CancellableCommandCreatorBase<IPatrolCommand, Vector3>
    {
        protected override IPatrolCommand CreateCommand(Vector3 argument)
            => new PatrolCommand(argument);
    }
}