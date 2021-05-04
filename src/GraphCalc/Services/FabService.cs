using System;
using GraphCalc.Abstractions;
using GraphCalc.Messages;

namespace GraphCalc.Services
{
    public class FabService: IEventHandler<AChanged>, IEventPublisher<FABProcessed>
    {
        public FabService(IMessageBus msgBus)
        {
            MsgBus = msgBus;
        }

        public IMessageBus MsgBus {get;}

        public void When(AChanged @event)
        {
            Console.WriteLine($"Service: {nameof(FabService)} received event {@event}" );
            Publish(new FABProcessed());
        }

        public void Publish(FABProcessed @event)
        {
            Console.WriteLine($"Service: {nameof(FabService)} published event {@event}");
            MsgBus.Publish(@event);
        }
    }
}