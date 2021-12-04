using System;

namespace Code.Utilities
{
    public abstract class AwaiterBase<TAwaited> : IAwaiter<TAwaited>
    {
        public bool _isCompleted;
        public Action _continuation;
        
        public virtual void OnCompleted(Action continuation)
        {
            if (_isCompleted)
                continuation.Invoke();
            else
                _continuation = continuation;
        }
        public bool IsCompleted => _isCompleted;
        public abstract TAwaited GetResult();
    }
}