using System;
using System.Reactive.Concurrency;
using PCLMock;

namespace Delay.Tests
{
    public sealed class SchedulerMock : MockBase<IScheduler>, IScheduler
    {
        public SchedulerMock(MockBehavior behavior = MockBehavior.Strict)
            : base(behavior)
        {
            if (behavior == MockBehavior.Loose)
            {
                When(x => x.Now).Return(() => DateTimeOffset.UtcNow);
            }
        }

        public DateTimeOffset Now
        {
            get { return Apply(x => x.Now); }
        }

        public IDisposable Schedule<TState>(TState state, Func<IScheduler, TState, IDisposable> action)
        {
            return Apply(x => x.Schedule(state, action));
        }

        public IDisposable Schedule<TState>(TState state, TimeSpan dueTime, Func<IScheduler, TState, IDisposable> action)
        {
            return Apply(x => x.Schedule(state, dueTime, action));
        }

        public IDisposable Schedule<TState>(TState state, DateTimeOffset dueTime,
            Func<IScheduler, TState, IDisposable> action)
        {
            return Apply(x => x.Schedule(state, dueTime, action));
        }
    }
}