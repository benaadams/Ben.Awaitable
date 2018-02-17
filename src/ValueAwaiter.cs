using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ben.Awaitable
{
    public struct ValueAwaiter
    {
        private IAwaitable _awaitable;

        public ValueAwaiter(ITask awaitable)
        {
            _awaitable = awaitable;
        }

        public bool IsCompleted => _awaitable.IsCompleted;

        public bool IsCompletedSuccessfully => _awaitable.IsCompletedSuccessfully;

        public bool IsFaulted => _awaitable.IsFaulted;

        public bool IsCanceled => _awaitable.IsCanceled;

        public AggregateException Exception => _awaitable.Exception;

        public ValueAwaitable GetAwaiter() => new ValueAwaitable(_awaitable);

        // public ConfiguredAwaitable ConfigureAwait(bool continueOnCapturedContext);

        public struct ValueAwaitable : ICriticalNotifyCompletion
        {
            private IAwaitable _awaitable;

            public ValueAwaitable(IAwaitable awaitable)
            {
                _awaitable = awaitable;
            }

            public bool IsCompleted => _awaitable.IsCompleted;

            public void GetResult() => _awaitable.GetResult();

            public void OnCompleted(Action continuation) => _awaitable.OnCompleted(continuation);

            public void UnsafeOnCompleted(Action continuation) => _awaitable.UnsafeOnCompleted(continuation);
        }

        //public static ValueAwaiter WhenAll(ValueAwaiter awaiter1, ValueAwaiter awaiter2) { }
        //public static ValueAwaiter WhenAll(ValueAwaiter awaiter1, ValueAwaiter awaiter2, ValueAwaiter awaiter3) { }
        //public static ValueAwaiter WhenAll(params ValueAwaiter[] awaiters) { }
        //public static ValueAwaiter WhenAll(IEnumerable<ValueAwaiter> awaiters) { }

        //public static ValueAwaiter WhenAny(ValueAwaiter awaiter1, ValueAwaiter awaiter2) { }
        //public static ValueAwaiter WhenAny(ValueAwaiter awaiter1, ValueAwaiter awaiter2, ValueAwaiter awaiter3) { }
        //public static ValueAwaiter WhenAny(params ValueAwaiter[] awaiters) { }
        //public static ValueAwaiter WhenAny(IEnumerable<ValueAwaiter> awaiters) { }
    }
}
