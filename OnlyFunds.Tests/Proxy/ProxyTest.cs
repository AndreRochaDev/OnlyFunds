using Castle.DynamicProxy;
using FluentAssertions;
using Newtonsoft.Json;
using OnlyFunds._1___Models.Domain;
using OnlyFunds.Proxy;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OnlyFunds.Tests.Proxy;

public class ProxyTest
{
    [Fact]
    public void Proxy()
    {
        var proxyGenerator = new ProxyGenerator();
        var proxy = proxyGenerator.CreateInterfaceProxyWithoutTarget<IVideoRepository>(new MoqInterceptor());
        var result = proxy.AddVideo(new Video("Video da Maria Leal"));

        result.Should().BeTrue();
    }

    [Fact]
    public void BatotaMapping()
    {
        var testInt = TryParse<int>("3");
        
        Assert.True(true);
    }

    private static T TryParse<T>(string valor) where T : new()
    {
        var foo = new T();
        return foo switch
        {
            int => (T)(object)Convert.ToInt32(valor),
            string => (T)(object)valor,
            _ => throw new Exception("Blow up")
        };
    }
}