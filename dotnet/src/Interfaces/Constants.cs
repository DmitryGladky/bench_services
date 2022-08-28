using System.Diagnostics.CodeAnalysis;

namespace Talabat.ServiceBench;

[ExcludeFromCodeCoverage]
public static class Constants
{
    public const string ServiceName = "${{values.service_slug}}";
    public const string ConfigKey = "ServiceBench";
    public const string BasePath = "MsBasePath";
    public const string ExternalService = "ExternalService";
    public static readonly string BaseUrl = $"http://{ServiceName}/{BasePath}".TrimEnd('/');
}
