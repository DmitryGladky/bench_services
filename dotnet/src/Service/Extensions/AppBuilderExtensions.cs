using System.Diagnostics.CodeAnalysis;

namespace Talabat.ServiceBench.Extensions;

[ExcludeFromCodeCoverage]
public static class AppBuilderExtensions
{
    public static IApplicationBuilder UseSwagger(this IApplicationBuilder self, ServiceOptions serviceOptions)
    {
        var pathBase = string.IsNullOrWhiteSpace(serviceOptions.BasePath.Trim('/'))
            ? string.Empty
            : $"{serviceOptions.BasePath}";
        self.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json")
            .UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"{pathBase}/swagger/v1/swagger.json", $"{Constants.ServiceName} API v1");
                options.RoutePrefix = "help";
            });
        return self;
    }
}
