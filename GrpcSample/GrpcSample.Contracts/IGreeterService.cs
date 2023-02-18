using Grpc.Core;
using ProtoBuf;
using ProtoBuf.Grpc;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace GrpcSample.Contracts
{
    //[ServiceContract(Name = "GrpcSample.Services.GreeterService")]
    [ServiceContract(Name = "greet.Greeter")]
    //
    public interface IGreeterService
    {
        [OperationContract]
        Task<HelloReply> SayHello(HelloRequest request, CallContext context = default);


    }

    [ProtoContract]
    public class HelloRequest
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public string LastName { get; set; }
    }

    [ProtoContract]
    public class HelloReply
    {
        [ProtoMember(1)]
        public string Message { get; set; }

        [ProtoMember(2)]
        public int Count { get; set; }
    }
}