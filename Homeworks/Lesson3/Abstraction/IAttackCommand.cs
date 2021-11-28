namespace Code.Abstraction
{
    public interface IAttackCommand : ICommand
    {
        public IAttackable Target { get; }
    }
}