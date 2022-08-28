using Google.Protobuf.Collections;
using Grpc.Core;

namespace Talabat.ServiceBench.Controllers;

public class GrpcService : Test.TestBase
{
    private readonly ILogger<GrpcService> _logger;

    public GrpcService(ILogger<GrpcService> logger)
    {
        _logger = logger;
    }

    public override Task<LongReply> Long(LongRequest request, ServerCallContext context)
    {
        // Logger.LogInformation("Testing CQRS Get Cart");
        var array = new int[request.Count];
        for (int i = 0; i < request.Count; ++i)
        {
            array[i] = i;
        }

        var result = new LongReply();
        result.Id.Add(array);

        return Task.FromResult(result);
    }

    public override async Task LongStream(LongRequest request, IServerStreamWriter<StreamReply> responseStream,
        ServerCallContext context)
    {
        for (int i = 0; i < request.Count; ++i)
        {
            if (context.CancellationToken.IsCancellationRequested)
            {
                break;
            }

            await responseStream.WriteAsync(new StreamReply() { Id = i });
        }
    }
}
