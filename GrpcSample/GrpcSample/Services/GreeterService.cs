using Grpc.Core;
using GrpcSample;

namespace GrpcSample.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly Counter counter;

        public GreeterService(ILogger<GreeterService> logger, Counter counter)
        {
            _logger = logger;
            counter.Count++;
            this.counter = counter;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = $"Hello {request.Name} {request.LastName} - {counter.Count}"
            });
        }
    }
}