using GrpcSample.Services;
using System.IO.Compression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Server;
namespace GrpcSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddCodeFirstGrpc(config => { config.ResponseCompressionLevel = CompressionLevel.Optimal; });

            //builder.Services.AddGrpc();
            builder.Services.AddSingleton(typeof(Counter),typeof(Counter));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //app.MapGrpcService<GreeterService>();
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapGrpcService<GreeterService>(); });

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
    public class Counter
    {
        public int Count { get; set; } = 0;
    }
}