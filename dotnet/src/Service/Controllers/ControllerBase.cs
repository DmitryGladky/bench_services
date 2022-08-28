using System.Diagnostics.CodeAnalysis;

namespace Talabat.ServiceBench.Controllers;

[ExcludeFromCodeCoverage]
public abstract class ControllerBase : IDisposable
{
    protected ControllerBase(ILogger logger) => Logger = logger ?? throw new ArgumentNullException(nameof(logger));

    protected ILogger Logger { get; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~ControllerBase() => Dispose(false);

    protected virtual void Dispose(bool disposing) { }
}
