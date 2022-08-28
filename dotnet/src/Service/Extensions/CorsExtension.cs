using System.Diagnostics.CodeAnalysis;
using Talabat.${{values.component_id}}.Extensions.Configuration;

namespace Talabat.${{values.component_id}}.Extensions;

[ExcludeFromCodeCoverage]
public static class CorsExtension
{
    public const string AllowCustomOrigins = "AllowCustomOrigins";

    public static void AddCorsSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var corsConfiguration = configuration?.GetSection(nameof(CorsConfiguration))?.Get<CorsConfiguration>();

        services.AddCors(
            options => options.AddPolicy(
                AllowCustomOrigins,
                builder =>
                {
                    builder.AllowCredentials();
                    builder.AllowAnyMethod();
                    builder.WithOrigins(corsConfiguration.Origins.ToArray());
                    builder.WithHeaders("authorization", "content-type");
                }));
    }
}
