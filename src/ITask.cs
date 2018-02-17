using System;
using System.Runtime.CompilerServices;

namespace Ben.Awaitable
{
    public interface ITask : IAwaitable
    {
        void SetException(Exception exception);
        void SetResult();
    }
}
