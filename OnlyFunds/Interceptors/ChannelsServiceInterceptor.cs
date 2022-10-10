using System.Diagnostics;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace OnlyFunds.Interceptors;

public class ChannelsServiceInterceptor : IInterceptor
{
    // Não é decorator pattern!
    private readonly ILogger<ChannelsServiceInterceptor> _logger;

    public ChannelsServiceInterceptor(ILogger<ChannelsServiceInterceptor> logger)
    {
        _logger = logger;
    }

    public void Intercept(IInvocation invocation)
    {
        var stopWatch = Stopwatch.StartNew();
        try
        {
            invocation.Proceed();
        }
        finally
        {
            stopWatch.Stop();
            _logger.LogInformation("{MethodName} demorou {Duration} ms", 
                invocation.Method.Name, stopWatch.ElapsedMilliseconds);
        }
    }
}