using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using GraphCalc.Abstractions;

namespace GraphCalc
{
    class FakeMessageBus:IMessageBus
	{
        private readonly Dictionary<Type, List<Action<IMessage>>> _routes = new Dictionary<Type, List<Action<IMessage>>>();

        public void RegisterHandler<T>(Action<T> handler) where T : IMessage
        {
            List<Action<IMessage>> handlers;

            // get handlers list for type
            if (!_routes.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<IMessage>>();
                _routes.Add(typeof(T), handlers);
            }

            handlers.Add((x => handler((T)x)));
        }

        //public void Send<T>(T command) where T : ICommand
        //{
        //    List<Action<IMessage>> handlers;

        //    if (_routes.TryGetValue(typeof(T), out handlers))
        //    {
        //        if (handlers.Count != 1) throw new InvalidOperationException("cannot send command to more than one handler");
        //        handlers[0](command);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("no handler registered");
        //    }
        //}

        public void Publish<T>(T @event) where T : IEvent
        {
            List<Action<IMessage>> handlers;

            if (!_routes.TryGetValue(@event.GetType(), out handlers)) return;

            foreach (var handler in handlers)
            {
                //dispatch on thread pool for added awesomeness
                var handler1 = handler;
                ThreadPool.QueueUserWorkItem(x => handler1(@event));
            }
        }
	}
}
