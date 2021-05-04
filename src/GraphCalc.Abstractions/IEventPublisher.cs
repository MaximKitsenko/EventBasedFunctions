namespace GraphCalc.Abstractions
{
    public interface IEventPublisher< T> where T : IEvent
    {
        void Publish(T @event);
    }
}