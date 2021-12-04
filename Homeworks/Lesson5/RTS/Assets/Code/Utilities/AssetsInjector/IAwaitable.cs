namespace Code.Utilities
{
    public interface IAwaitable<T>
    {
        IAwaiter<T> GetAwaiter();
    }
}