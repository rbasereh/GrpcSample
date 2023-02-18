using Grpc.Net.Client;
using GrpcSample;
using Microsoft.AspNetCore.Mvc;

namespace GrpcSampleClient.Controllers
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
            using var channel = GrpcChannel.ForAddress("https://localhost:7106");

            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient", LastName = "lastName" });

            return reply;
        }

      
    }
}