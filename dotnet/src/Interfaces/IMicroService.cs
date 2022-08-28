using System;
using System.Threading.Tasks;

namespace Talabat.ServiceBench;

public interface IServiceBench : IHealth, IExample
{
}

public interface IHealth
{
    Task<bool> IsHealthy();
}

// !!The following example was created by Talabat.DotNet.Templates and should be removed.

public interface IExample
{
    Task<AdviceResponse> RelayMessageAsync(int adviceId);
    Task<CartResponse> GetCart(string id);
    Task<CartCreateResponse> CreateCart(CartCreateRequest request);
}
