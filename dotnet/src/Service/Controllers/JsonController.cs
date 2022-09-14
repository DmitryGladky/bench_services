using Microsoft.AspNetCore.Mvc;

namespace Talabat.ServiceBench.Controllers;
//TODO The following example was created by Talabat.DotNet.Templates and should be removed.

public class LongResponse
{
    public int[] Ids { get; set; }
}

[ApiController]
[Produces("application/json")]
public class JsonController
{
    private IConfiguration Config { get; }

    public JsonController(IConfiguration config)
    {
        Config = config ?? throw new ArgumentNullException(nameof(config));
    }


    [HttpGet]
    [Route("test/long_response/{count}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<LongResponse> LongResponse(int count)
    {
        var array = new int[count];
        for (int i = 0; i < count; ++i)
        {
            array[i] = i;
        }


        return Task.FromResult(new LongResponse() { Ids = array });
    }
}
