using System;
using System.Runtime.CompilerServices;

namespace Ben.Awaitable
{
    [AsyncMethodBuilder(typeof(TaskLikeMethodBuilder<>))]
    public struct TaskLike<TResult>
    {
        private ITask<TResult> _awaitable;

        public TaskLike(ITask<TResult> awaitable)
        {
            _awaitable = awaitable;
        }

        public bool IsCompleted => _awaitable.IsCompleted;

        public bool IsCompletedSuccessfully => _awaitable.IsCompletedSuccessfully;

        public bool IsFaulted => _awaitable.IsFaulted;

        public bool IsCanceled => _awaitable.IsCanceled;

        public AggregateException Exception => _awaitable.Exception;

        public TaskLikeAwaitable GetAwaiter() => new TaskLikeAwaitable(_awaitable);

        // public ConfiguredAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext);

        public static implicit operator ValueAwaiter(TaskLike<TResult> awaiter)
        {
            return new ValueAwaiter(awaiter._awaitable);
        }

        public struct TaskLikeAwaitable : ICriticalNotifyCompletion
        {
            private ITask<TResult> _awaitable;

            public TaskLikeAwaitable(ITask<TResult> awaitable)
            {
                _awaitable = awaitable;
            }

            public bool IsCompleted => _awaitable.IsCompleted;

            public TResult GetResult() => _awaitable.GetResult();

            public void OnCompleted(Action continuation) => _awaitable.OnCompleted(continuation);

            public void UnsafeOnCompleted(Action continuation) => _awaitable.UnsafeOnCompleted(continuation);
        }
    }
}
