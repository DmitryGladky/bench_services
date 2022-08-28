using System.Diagnostics.CodeAnalysis;
using Serilog;

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
                webBuilder => webBuilder.UseStartup<Startup>())
            .ConfigureLogging(
                builder => builder.ClearProviders().AddSerilog())
            .ConfigureAppConfiguration(
                (hostingContext, config) => config.AddEnvironmentVariables());
}
