using System;
using System.Threading.Tasks;
using GraphCalc.Abstractions;
using GraphCalc.Messages;

namespace GraphCalc.Services
{
    public class FxService: IEventHandler<XChanged>, IEventHandler<CxChanged>, IEventPublisher<FXProcessed>
    {
        public FxService(IMessageBus msgBus)
        {
            _msgBus = msgBus;
        }

        public IMessageBus _msgBus {get;}

        public void When(XChanged @event)
        {
            Task.Delay(35).Wait();
            Console.WriteLine($"Service: {nameof(FxService)} received event {@event}" );
            Publish(new FXProcessed());
        }

        public void When(CxChanged @event)
        {
            Task.Delay(30).Wait();
            Console.WriteLine($"Service: {nameof(FxService)} received event {@event}");
            Publish(new FXProcessed());
        }

        public void Publish(FXProcessed @event)
        {
            Console.WriteLine($"Service: {nameof(FxService)} published event {@event}");
            _msgBus.Publish(@event);
        }
    }
}