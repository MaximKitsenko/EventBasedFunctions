using System;
using System.Threading.Tasks;
using GraphCalc.Abstractions;
using GraphCalc.Messages;

namespace GraphCalc.Services
{
    public class FcdService: IEventHandler<FABProcessed>, IEventHandler<CxChanged>, IEventPublisher<FCDProcessed>
    {
        public FcdService(IMessageBus msgBus)
        {
            MsgBus = msgBus;
        }

        public IMessageBus MsgBus {get;}

        public void When(FABProcessed @event)
        {
            Task.Delay(100).Wait();
            Console.WriteLine($"Service: {nameof(FcdService)} received event {@event}" );
            Publish(new FCDProcessed());
        }

        public void When(CxChanged @event)
        {
            Task.Delay(50).Wait();
            Console.WriteLine($"Service: {nameof(FcdService)} received event {@event}");
            Publish(new FCDProcessed());
        }

        public void Publish(FCDProcessed @event)
        {
            Console.WriteLine($"Service: {nameof(FcdService)} published event {@event}");
            MsgBus.Publish(@event);
        }
    }
}