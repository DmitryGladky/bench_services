using System.Diagnostics.CodeAnalysis;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Talabat.ServiceBench.CQRS.Cart.Commands;
using Talabat.ServiceBench.CQRS.Cart.Queries;
using Talabat.ServiceBench.External;

namespace Talabat.ServiceBench.Controllers;
//TODO The following example was created by Talabat.DotNet.Templates and should be removed.

[ApiController]
[Route("test")]
[Produces("application/json")]
[ApiVersion("1")]
[ExcludeFromCodeCoverage]
public class ExampleController : ControllerBase, IExample
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IMediator mediator;
    private readonly IExternalServiceClient externalService;
    private IConfiguration Config { get; }

    public ExampleController(IConfiguration config, IHttpContextAccessor httpContextAccessor, IMediator mediator, ILogger<ExampleController> logger, IExternalServiceClient externalService) : base(logger)
    {
        this.externalService = externalService;
        this.httpContextAccessor = httpContextAccessor;
        this.mediator = mediator;
        Config = config ?? throw new ArgumentNullException(nameof(config));
    }

    [HttpGet]
    [Route("relay")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [MapToApiVersion("1")]
    public Task<AdviceResponse> RelayMessageAsync(int adviceId)
    {
        Logger.LogInformation("Testing relay string");
        return externalService.Advice(adviceId);
    }

    [HttpGet]
    [Route("cart/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [MapToApiVersion("1")]
    public async Task<CartResponse> GetCart(string id)
    {
        Logger.LogInformation("Testing CQRS Get Cart");
        return await mediator.Send(new GetCartQuery { Id = id });
    }

    [HttpPost]
    [Route("cart")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [MapToApiVersion("1")]
    public async Task<CartCreateResponse> CreateCart(CartCreateRequest request)
    {
        Logger.LogInformation("Testing CQRS Post Cart");
        var cart = await mediator.Send(new CreateCartCommand { VendorId = request.VendorId });

        httpContextAccessor.HttpContext!.Response.StatusCode = StatusCodes.Status201Created;

        return new CartCreateResponse { Id = cart.Id, VendorId = cart.VendorId };
    }
}
