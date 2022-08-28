using System.Diagnostics.CodeAnalysis;

namespace Talabat.${{values.component_id}};

[ExcludeFromCodeCoverage]
public static class Constants
{
    public const string ServiceName = "${{values.service_slug}}";
    public const string ConfigKey = "${{values.component_id}}";
    public const string BasePath = "MsBasePath";
    public const string ExternalService = "ExternalService";
    public static readonly string BaseUrl = $"http://{ServiceName}/{BasePath}".TrimEnd('/');
}
