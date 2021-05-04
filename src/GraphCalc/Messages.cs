namespace GraphCalc.Messages
{
    public class XChanged : Abstractions.IEvent
    {
        public XChanged(int newX)
        {
            NewX = newX;
        }

        public int NewX { get; }

        public override string ToString()
        {
            return $"Event-{nameof(XChanged)}:{nameof(NewX)}={NewX}";
        }
    }

    public class FXProcessed : Abstractions.IEvent
    {

    }

    public class FEProcessed : Abstractions.IEvent
    {

    }

    public class AChanged : Abstractions.IEvent
    {
        public AChanged(int newA)
        {
            NewA = newA;
        }

        public int NewA { get; }

        public override string ToString()
        {
            return $"Event-{nameof(AChanged)}:{nameof(NewA)}={NewA}";
        }
    }

    public class FABProcessed : Abstractions.IEvent
    {

    }

    public class FCDProcessed : Abstractions.IEvent
    {

    }

    public class CxChanged : Abstractions.IEvent
    {
        public int NewC { get; }
        public int NewX { get; }

        public CxChanged(int newC, int newX)
        {
            NewC = newC;
            NewX = newX;
        }

        public override string ToString()
        {
            return $"Event-{nameof(CxChanged)}:{nameof(NewC)}={NewC},{nameof(NewX)}={NewX}";
        }
    }

    public class ResultProcessed : Abstractions.IEvent
    {

    }
}