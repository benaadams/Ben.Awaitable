using System;
using System.Runtime.CompilerServices;

namespace Ben.Awaitable
{
    public interface IAwaitable<TResult> : IAwaitable
    {
        new TResult GetResult();
    }
}
