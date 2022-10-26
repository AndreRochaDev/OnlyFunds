using FakeItEasy;
using Microsoft.Extensions.Logging;
using OnlyFunds._1___Models.Domain;
using OnlyFunds.Services;

namespace OnlyFunds.Tests.TestFixtureBuilders;

public class ChannelsServiceTestFixtureBuilder
{
    private ILogger<ChannelsService> _logger;
    private List<Channel> _channels = new();

    public ChannelsServiceTestFixtureBuilder()
    {
        WithLogger(A.Fake<ILogger<ChannelsService>>());
    }

    public ChannelsServiceTestFixtureBuilder WithLogger(ILogger<ChannelsService> logger)
    {
        _logger = logger;
        return this;
    }

    public ChannelsServiceTestFixtureBuilder WithChannels(params Channel[] channels)
    {
        _channels = channels.ToList(); 
        return this;
    }
    
    private async Task AddChannels(ChannelsService channelsService)
    {
        foreach (var channel in _channels)
        {
            await channelsService.CreateChannel(channel);
        }
    }

    public async Task<ChannelsService> Build()
    {
        var channelsService = new ChannelsService(_logger);
        await AddChannels(channelsService);
        return channelsService;
    }
}