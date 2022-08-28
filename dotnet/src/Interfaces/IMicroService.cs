using System;
using System.Threading.Tasks;

namespace Talabat.${{values.component_id}};

public interface I${{values.component_id}} : IHealth, IExample
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
