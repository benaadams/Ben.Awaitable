using System;
using System.Runtime.CompilerServices;

namespace Ben.Awaitable
{
    public interface ITask<TResult> : IAwaitable<TResult>, ITask
    {
        void SetResult(TResult result);
    }
}
