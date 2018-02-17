using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Ben.Awaitable
{
    public struct TaskLikeMethodBuilder
    {
        public static TaskLikeMethodBuilder Create() => default;

        public void Start<TStateMachine>(ref TStateMachine stateMachine)
            where TStateMachine : IAsyncStateMachine => 
                default(AsyncTaskMethodBuilder).Start(ref stateMachine);

        public void SetStateMachine(IAsyncStateMachine stateMachine);
        public void SetException(Exception exception);
        public void SetResult();

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(
            ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine;

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(
            ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine;

        public TaskLike Task { get; }
    }

    public struct TaskLikeMethodBuilder<TResult>
    {
        public static TaskLikeMethodBuilder<TResult> Create() => default;

        public void Start<TStateMachine>(ref TStateMachine stateMachine)
            where TStateMachine : IAsyncStateMachine =>
                default(AsyncTaskMethodBuilder).Start(ref stateMachine);

        public void SetStateMachine(IAsyncStateMachine stateMachine);
        public void SetException(Exception exception);
        public void SetResult(TResult result);

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(
            ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine;
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(
            ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine;

        public TaskLike<TResult> Task { get; }
    }
}