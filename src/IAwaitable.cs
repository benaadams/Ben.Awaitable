using System;
using System.Runtime.CompilerServices;

namespace Ben.Awaitable
{
    public interface IAwaitable
    {
        bool IsCompleted { get; }
        void GetResult();

        bool IsCanceled { get; }
        bool IsCompletedSuccessfully { get; }
        bool IsFaulted { get; }
        AggregateException Exception { get; }

        void OnCompleted(Action continuation);
        void UnsafeOnCompleted(Action continuation);
    }
}
