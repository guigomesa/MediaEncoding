using System;
using System.Collections.Generic;
using System.Text;
using MediaEncoding.WorkerConsumer.ServiceModel;
using ServiceStack;

namespace MediaEncoding.WorkerConsumer
{
    public class MyService : Service
    {
        public object Any(Hello request) => new HelloResponse
        {
            Result = $"Hello, {request.Name}!"
        };
    }
}
