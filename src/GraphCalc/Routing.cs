using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using GraphCalc.Abstractions;
using GraphCalc.Services;

namespace GraphCalc
{
    public class Routing
    {
        public ConcurrentDictionary<Type,IEventHandler<IEvent>> handlers { get; set; }
    }
}
