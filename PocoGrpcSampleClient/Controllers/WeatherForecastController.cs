using Grpc.Net.Client;
using GrpcSample.Contracts;
using Microsoft.AspNetCore.Mvc;
using ProtoBuf.Grpc.Client;
using System.Threading.Channels;

namespace PocoGrpcSampleClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<HelloReply> Get()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("https://localhost:7106");
            var client = channel.CreateGrpcService<IGreeterService>();
            var reply = await client.SayHello(new HelloRequest { Name = "GreeterClient", LastName = "lastName" });

            return reply;
        }
    }
}