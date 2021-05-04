namespace GraphCalc.Abstractions
{
    public interface IEventHandler<T> where T: IEvent
    {
        void When(T @event);
    }
}