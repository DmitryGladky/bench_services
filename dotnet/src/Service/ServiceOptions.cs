using System.Diagnostics.CodeAnalysis;

namespace Talabat.ServiceBench;

[ExcludeFromCodeCoverage]
public class ServiceOptions
{
    private string basePath;

    public string BasePath
    {
        get => basePath ?? $"/{Constants.BasePath.Trim('/')}";
        set => basePath = string.IsNullOrWhiteSpace(value) ? value : $"{value.Trim('/')}";
    }

    public string BaseUrl { get; set; } = Constants.BaseUrl;
}
