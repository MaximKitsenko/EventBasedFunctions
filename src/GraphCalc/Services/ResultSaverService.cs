using System;
using System.Threading.Tasks;
using GraphCalc.Abstractions;
using GraphCalc.Messages;

namespace GraphCalc.Services
{
    public class ResultSaverService: IEventHandler<FEProcessed>, IEventPublisher<ResultProcessed>
    {
        public ResultSaverService(IMessageBus msgBus)
        {
            MsgBus = msgBus;
        }

        public IMessageBus MsgBus {get;}

        public void When(FEProcessed @event)
        {
            Task.Delay(15).Wait();
            Console.WriteLine($"Service: {nameof(ResultSaverService)} received event {@event}" );
            Publish(new ResultProcessed());
        }

        public void Publish(ResultProcessed @event)
        {
            Console.WriteLine($"Service: {nameof(ResultSaverService)} published event {@event}");
            MsgBus.Publish(@event);
        }
    }
}