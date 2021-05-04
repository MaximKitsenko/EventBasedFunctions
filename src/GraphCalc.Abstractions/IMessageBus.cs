using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCalc.Abstractions
{
    public interface IMessageBus
    {
        //void Push(IMessage message);
        //void SubscribeOn(IMessage message);
        void RegisterHandler<T>(Action<T> handler) where T : IMessage;
        void Publish<T>(T @event) where T : IEvent;
    }
}
