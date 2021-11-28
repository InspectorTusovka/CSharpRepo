using Code.Abstraction;

namespace Code.UserControlSystem.CommandRealization
{
    public class AttackCommand : IAttackCommand
    {
            public IAttackable Target { get; }
            public AttackCommand(IAttackable target)
            {
                Target = target;
            }
    }

}
