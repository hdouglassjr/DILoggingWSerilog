using System.Threading;
using Microsoft.Extensions.Logging;

namespace MyNetServiceLib
{
    public class MyService
    {
        private readonly ILogger<MyService> _logger;

        public MyService(ILogger<MyService> logger = null)
        {
            _logger = logger;
        }

        public void DoSomething(string theParam)
        {
            _logger?.LogInformation($"DoSomething with {theParam}");

            Thread.Sleep(1000);

            // Test logs at each level
            _logger?.LogTrace("DoSometing TRACE message");
            _logger?.LogDebug("DoSometing DEBUG message");
            _logger?.LogInformation("DoSometing INFO message");
            _logger?.LogWarning("DoSometing WARN message");
            _logger?.LogError("DoSometing ERROR message");
            _logger?.LogCritical("DoSometing CRITICAL message");
        }
    }
}