using System;
using System.Diagnostics.CodeAnalysis;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Refit;
using Talabat.ServiceBench.Extensions;
using Talabat.ServiceBench.External;

namespace Talabat.ServiceBench;

[ExcludeFromCodeCoverage]
public class Startup
{
    public Startup(IConfiguration configuration) => Configuration = configuration;

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // NOTE: Required by Net5.0 for comparable behaviour to NetCore 3.X (and earlier)
        // see: https://github.com/aspnet/Announcements/issues/434
        services.PostConfigure<ExceptionHandlerOptions>(options => options.AllowStatusCode404Response = true);

        services
            .AddHeaderPropagation()
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddHealthChecks();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = Constants.ServiceName, Version = "v1" });
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Service.xml"));
        });

        services.AddControllers();

        // Service configuration section
        services.Configure<ServiceOptions>(Configuration.GetSection(Constants.ConfigKey));

        services.AddMediatR(typeof(Startup));

        services.AddHttpContextAccessor();

        services.ConfigureRefitClientWithRetryPolicy<IExternalServiceClient>(Configuration.GetSection(Constants.ExternalService));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        var serviceOptions = app.ApplicationServices.GetRequiredService<IOptions<ServiceOptions>>().Value;
        app.UsePathBase(serviceOptions.BasePath);

        app.UseHeaderPropagation();
        app.UseRouting();
        app.UseSwagger(serviceOptions);
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors(CorsExtension.AllowCustomOrigins);
        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
                endpoints.MapHealthChecks("/health");
            });
    }
}
