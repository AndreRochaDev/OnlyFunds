using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OnlyFunds._1___Models.Domain;
using OnlyFunds._1___Models.Responses;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OnlyFunds.Services;

public interface IChannelsService
{
    // Apenas tem estes requests/responses como parametros para ser mais rapida a apresentação
    // Mapster
    Task<Channel> CreateChannel(Channel channel);
    Task<GetChannelsResponse> GetChannels();
    Task<Channel> GetChannel(string channelName);
}

public class ChannelsService : IChannelsService
{
    private List<Channel> _channels = new();
    private readonly ILogger<ChannelsService> _logger;

    public ChannelsService(ILogger<ChannelsService> logger)
    {
        _logger = logger;
    }

    public async Task<Channel> CreateChannel(Channel channel)
    {
        _channels.Add(channel);
        return channel;
    }

    // É boa pratica evitar referencias aos requests/responses aqui
    public async Task<GetChannelsResponse> GetChannels()
    {
        return new GetChannelsResponse { Channels = _channels };
    }

    public async Task<Channel?> GetChannel(string channelName)
    {
        return _channels.FirstOrDefault(c => c.ChannelName == channelName);
    }
}