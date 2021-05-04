using System;
using GraphCalc.Messages;
using GraphCalc.Services;

namespace GraphCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var msgBus = new FakeMessageBus();

            var fabService = new FabService(msgBus);
            var fcdService = new FcdService(msgBus);
            var fxService = new FxService(msgBus);
            var feService = new FeService(msgBus);
            var resultService = new ResultSaverService(msgBus);

            msgBus.RegisterHandler<XChanged>(fxService.When);
            msgBus.RegisterHandler<FXProcessed>(feService.When);
            msgBus.RegisterHandler<FEProcessed>(resultService.When);
            msgBus.RegisterHandler<AChanged>(fabService.When);
            msgBus.RegisterHandler<FABProcessed>(fcdService.When);
            msgBus.RegisterHandler<FCDProcessed>(feService.When);
            msgBus.RegisterHandler<CxChanged>(fcdService.When);
            msgBus.RegisterHandler<CxChanged>(fxService.When);

            msgBus.Publish(new XChanged(1));
            msgBus.Publish(new AChanged(2));
            msgBus.Publish(new CxChanged(5,7));

            Console.ReadLine();
        }
    }
}
