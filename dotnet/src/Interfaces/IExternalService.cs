using System;
using System.Threading.Tasks;

namespace Talabat.${{values.component_id}};

public interface IExternalService
{
    Task<string> EchoMessageAsync(DateTime date, string message);

    Task<EchoResponse> EchoMessageAsync(EchoRequest request);
}