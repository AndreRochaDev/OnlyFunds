using Castle.DynamicProxy;

namespace OnlyFunds.Proxy;

public interface IVideoRepository
{
    bool AddVideo(Video video);
}

public record Video(string VideoName);

public class MoqInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        invocation.ReturnValue = true;
    }
}