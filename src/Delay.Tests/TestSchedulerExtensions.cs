﻿using System;
using System.Reactive.Concurrency;
using Microsoft.Reactive.Testing;

namespace Delay.Tests
{
    public static class TestSchedulerExtensions
    {
        public static void AdvanceBy(this TestScheduler @this, TimeSpan time)
        {
            Ensure.ArgumentNotNull(@this, nameof(@this));
            @this.AdvanceBy(time.Ticks);
        }

        public static void AdvanceTo(this TestScheduler @this, DateTime dateTime)
        {
            Ensure.ArgumentNotNull(@this, nameof(@this));
            @this.AdvanceTo(dateTime.Ticks);
        }

        public static void AdvanceMinimal(this TestScheduler @this) =>
            // not technically minimal, but advancing by a single tick doesn't always work as expected (a bug in Rx?)
            @this.AdvanceBy(TimeSpan.FromMilliseconds(1));

        // because "Start" is an awfully misleading name. See http://kent-boogaart.com/blog/the-peril-of-virtualtimescheduler.start/
        public static void AdvanceUntilEmpty(this TestScheduler @this) =>
            @this.Start();

        public static void ScheduleRelative(this TestScheduler @this, TimeSpan dueTime, Action action)
        {
            Ensure.ArgumentNotNull(@this, nameof(@this));
            @this.ScheduleRelative(dueTime.Ticks, action);
        }

        public static void ScheduleRelative<TState>(this TestScheduler @this, TState state, TimeSpan dueTime,
            Func<IScheduler, TState, IDisposable> action)
        {
            Ensure.ArgumentNotNull(@this, nameof(@this));
            @this.ScheduleRelative(state, dueTime.Ticks, action);
        }
    }
}