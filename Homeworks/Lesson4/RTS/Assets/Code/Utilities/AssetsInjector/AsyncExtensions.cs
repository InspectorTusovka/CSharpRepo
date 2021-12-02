using System.Threading;
using System.Threading.Tasks;

namespace Code.Utilities
{
    public static class AsyncExtensions
    {
        public struct Void { }

        public static async Task<TResult> WithCancellation<TResult>(this Task<TResult> originalTask,
            CancellationToken cToken)
        {
            var cancelTask = new TaskCompletionSource<Void>();
            using (cToken.Register(t => ((TaskCompletionSource<Void>)t).TrySetResult(new Void()), cancelTask))
            {
                var any = await Task.WhenAny(originalTask, cancelTask.Task);
                if (any == cancelTask.Task) 
                    cToken.ThrowIfCancellationRequested();
            }
            return await originalTask;
        }

        public static Task<TResult> AsTask<TResult>(this IAwaitable<TResult> awaitable) =>
            Task.Run(async () => await awaitable);

        public static async Task<TResult> WithCancellation<TResult>(this IAwaitable<TResult> originalTask,
            CancellationToken cToken) => await WithCancellation(originalTask.AsTask(), cToken);
    }
}