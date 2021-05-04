using System;
using GraphCalc.Abstractions;
using GraphCalc.Messages;

namespace GraphCalc.Services
{
    public class FeService: IEventHandler<FXProcessed>, IEventHandler<FCDProcessed>, IEventPublisher<FEProcessed>
    {
        public FeService(IMessageBus msgBus)
        {
            MsgBus = msgBus;
        }

        public IMessageBus MsgBus {get;}

        public void When(FXProcessed @event)
        {
            Console.WriteLine($"Service: {nameof(FeService)} received event {@event}" );
            Publish(new FEProcessed());
        }

        public void Publish(FEProcessed @event)
        {
            Console.WriteLine($"Service: {nameof(FeService)} published event {@event}");
            MsgBus.Publish(@event);
        }

        public void When(FCDProcessed @event)
        {
            Console.WriteLine($"Service: {nameof(FeService)} received event {@event}");
            Publish(new FEProcessed());
        }
    }
}