using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ben.Awaitable
{

    [AsyncMethodBuilder(typeof(TaskLikeMethodBuilder))]
    public struct TaskLike
    {
        private ITask _awaitable;

        public TaskLike(ITask awaitable)
        {
            _awaitable = awaitable;
        }

        public bool IsCompleted => _awaitable.IsCompleted;

        public bool IsCompletedSuccessfully => _awaitable.IsCompletedSuccessfully;

        public bool IsFaulted => _awaitable.IsFaulted;

        public bool IsCanceled => _awaitable.IsCanceled;

        public AggregateException Exception => _awaitable.Exception;

        public TaskLikeAwaitable GetAwaiter() => new TaskLikeAwaitable(_awaitable);

        // public ConfiguredAwaitable ConfigureAwait(bool continueOnCapturedContext);

        public struct TaskLikeAwaitable : ICriticalNotifyCompletion
        {
            private ITask _awaitable;

            public TaskLikeAwaitable(ITask awaitable)
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
