using Refit;
using System.Threading.Tasks;

namespace Talabat.${{values.component_id}}.External;

public interface IExternalServiceClient
{
    [Get("/advice/{adviceId}")]
    Task<AdviceResponse> Advice(int adviceId);
}
