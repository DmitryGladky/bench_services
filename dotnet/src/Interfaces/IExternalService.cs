using System;
using System.Threading.Tasks;

namespace Talabat.ServiceBench;

public interface IExternalService
{
    Task<string> EchoMessageAsync(DateTime date, string message);

    Task<EchoResponse> EchoMessageAsync(EchoRequest request);
}