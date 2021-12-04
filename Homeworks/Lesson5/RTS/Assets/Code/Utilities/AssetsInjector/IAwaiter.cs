using System.Runtime.CompilerServices;

namespace Code.Utilities
{
    public interface IAwaiter<TAwaited> : INotifyCompletion
    {
        bool IsCompleted { get; }
        TAwaited GetResult();
    }
}