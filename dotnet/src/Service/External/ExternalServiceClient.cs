using Refit;
using System.Threading.Tasks;

namespace Talabat.ServiceBench.External;

public interface IExternalServiceClient
{
    [Get("/advice/{adviceId}")]
    Task<AdviceResponse> Advice(int adviceId);
}
