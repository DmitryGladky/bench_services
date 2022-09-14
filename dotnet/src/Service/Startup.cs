using System.Diagnostics.CodeAnalysis;
using Talabat.ServiceBench.Controllers;

namespace Talabat.ServiceBench;

[ExcludeFromCodeCoverage]
public class Startup
{
    public Startup(IConfiguration configuration) => Configuration = configuration;

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddGrpc();
        services.AddGrpcReflection();

        //services.AddMediatR(typeof(Startup));

        services.AddHttpContextAccessor();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<GrpcService>();
                endpoints.MapGrpcReflectionService();
            });
    }
}
