using Code.Abstraction;
using Code.UserControlSystem.CommandRealization;

namespace Code.UserControlSystem.UI.Model.CommandCreators
{
    public  class  AttackCommandCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand CreateCommand(IAttackable argument)
            => new AttackCommand(argument);
    }
}