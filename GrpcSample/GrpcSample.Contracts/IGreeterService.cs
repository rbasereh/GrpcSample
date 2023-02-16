using Grpc.Core;
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

    [DataContract]
    public class HelloRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public string LastName { get; set; }
    }

    [DataContract]
    public class HelloReply
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}