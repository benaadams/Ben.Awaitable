using System;
using System.Runtime.CompilerServices;

namespace Ben.Awaitable
{
    public struct ValueAwaiter<TResult>
    {
        private IAwaitable<TResult> _awaitable;

        public ValueAwaiter(IAwaitable<TResult> awaitable)
        {
            _awaitable = awaitable;
        }

        public bool IsCompleted => _awaitable.IsCompleted;

        public bool IsCompletedSuccessfully => _awaitable.IsCompletedSuccessfully;

        public bool IsFaulted => _awaitable.IsFaulted;

        public bool IsCanceled => _awaitable.IsCanceled;

        public AggregateException Exception => _awaitable.Exception;

        public ValueAwaitable GetAwaiter() => new ValueAwaitable(_awaitable);

        // public ConfiguredAwaitable<TResult> ConfigureAwait(bool continueOnCapturedContext);

        public static implicit operator ValueAwaiter(ValueAwaiter<TResult> awaiter)
        {
            return new ValueAwaiter(awaiter._awaitable);
        }

        public struct ValueAwaitable : ICriticalNotifyCompletion
        {
            private IAwaitable<TResult> _awaitable;

            public ValueAwaitable(IAwaitable<TResult> awaitable)
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
