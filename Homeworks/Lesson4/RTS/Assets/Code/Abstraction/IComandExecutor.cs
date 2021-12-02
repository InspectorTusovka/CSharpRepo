namespace Code.Abstraction
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(object command);
    }
}