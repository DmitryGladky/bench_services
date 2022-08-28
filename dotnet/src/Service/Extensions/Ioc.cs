using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Refit;

namespace Talabat.${{values.component_id}}.Extensions;

[ExcludeFromCodeCoverage]
public static class Ioc
{
    public static void ConfigureRefitClientWithRetryPolicy<T>(this IServiceCollection services,
        IConfigurationSection configuration) where T : class
    {
        var baseAddress = new Uri(configuration["BaseUrl"]);
        var timeout = TimeSpan.Parse(configuration["Timeout"] ?? "00:00:00.000", CultureInfo.InvariantCulture);
        var retryCount = Convert.ToInt32(configuration["RetriesCount"]);
        var handledEventsBeforeBreakingCount = Convert.ToInt32(configuration["CircuitBreaker.RetriesBeforeBreakingCount"]);
        var breakDuration = TimeSpan.Parse(configuration["CircuitBreaker.BreakDuration"], CultureInfo.InvariantCulture);

        services
            .AddRefitClient<T>()
            .ConfigureHttpClient(hc =>
            {
                hc.BaseAddress = baseAddress;
                if (timeout.Ticks > 0)
                    hc.Timeout = timeout;
            })
            .AddTransientHttpErrorPolicy(
                p => p.RetryAsync(retryCount))
            .AddTransientHttpErrorPolicy(
                p => p.CircuitBreakerAsync(
                    handledEventsBeforeBreakingCount,
                    breakDuration));
    }
}
