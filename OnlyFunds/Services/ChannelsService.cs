using OnlyFunds._1___Models.Domain;
using OnlyFunds._1___Models.Responses;

namespace OnlyFunds.Services;

public interface IChannelsService
{
    // Apenas tem estes requests/responses como parametros para ser mais rapida a apresentação
    Task<Channel> CreateChannel(Channel channel);
    Task<GetChannelsResponse> GetChannels();
    Task<Channel> GetChannel(string channelName);
}

public class ChannelsService : IChannelsService
{
    private List<Channel> _channels = new();
    
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