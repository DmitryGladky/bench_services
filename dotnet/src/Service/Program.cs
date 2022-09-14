using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Talabat.ServiceBench;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args).Build().Run();
        }
#pragma warning disable CA1031 // Do not catch general exception types
        catch (Exception e)
        {
            Console.WriteLine("Failed to start host");
            Console.WriteLine(e);
            Console.WriteLine("Press Enter to close");
            Console.ReadLine();
        }
#pragma warning restore CA1031 // Do not catch general exception types
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 5001, listenOptions =>
                        {
                            listenOptions.Protocols = HttpProtocols.Http2;
                        });
                        options.Listen(IPAddress.Any, 5002, listenOptions =>
                        {
                            listenOptions.Protocols = HttpProtocols.Http1;
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureLogging(
                builder => builder.ClearProviders())
            .ConfigureAppConfiguration(
                (hostingContext, config) => config.AddEnvironmentVariables());
}
