using System;
using System.Reactive;

namespace Delay
{
    public interface IDelayService
    {
        IObservable<Unit> Delay(TimeSpan duration);
    }
}