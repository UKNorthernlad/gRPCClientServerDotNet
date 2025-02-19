using Grpc.Core;
using GrpcMessageService;

namespace GrpcMessageService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private int stockcount { get; set; }

        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            Random rnd = new Random();
            stockcount = rnd.Next(1, 100);

            if (request.Name == "drones")
            {
                return Task.FromResult(new HelloReply
                {
                    Message = "There are " + stockcount.ToString() + " of those in stock"
                }) ;

            } else
            {
                return Task.FromResult(new HelloReply
                {
                    Message = "We don't have any of those in stock"
                }) ;

            }


        }
    }
}