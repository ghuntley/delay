using System;
using System.Reactive;
using System.Reactive.Linq;
using PCLMock;

namespace Delay.Tests
{
    public sealed partial class DelayServiceMock
    {
        partial void ConfigureLooseBehavior()
        {
            When(x => x.Delay(It.IsAny<TimeSpan>()))
                .Return(Observable.Return(Unit.Default));
        }
    }

    public partial class DelayServiceMock : MockBase<IDelayService>, IDelayService
    {
        public DelayServiceMock(MockBehavior behavior = MockBehavior.Strict) : base(behavior)
        {
            if (behavior == MockBehavior.Loose)
            {
                ConfigureLooseBehavior();
            }
        }

        public IObservable<Unit> Delay(TimeSpan duration)
        {
            return Apply(x => x.Delay(duration));
        }

        partial void ConfigureLooseBehavior();
    }
}