using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace Talabat.ServiceBench.Controllers;
//TODO The following example was created by Talabat.DotNet.Templates and should be removed.

[ApiController]
[Route("test")]
[Produces("application/json")]
[ApiVersion("1")]
[ExcludeFromCodeCoverage]
public class JsonController : ControllerBase, IExample
{
    private IConfiguration Config { get; }

    public JsonController(IConfiguration config, ILogger<JsonController> logger) : base(logger)
    {
        Config = config ?? throw new ArgumentNullException(nameof(config));
    }


    [HttpGet]
    [Route("test/long_response/{count}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [MapToApiVersion("1")]
    public Task<LongResponse> LongResponse(int count)
    {
        Logger.LogInformation("Testing CQRS Get Cart");
        var array = new int[count];
        for (int i = 0; i < count; ++i)
        {
            array[i] = i;
        }


        return Task.FromResult(new LongResponse() { Id = array });
    }

}
