using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using OnlyFunds._1___Models.Domain;
using OnlyFunds._1___Models.Responses;
using OnlyFunds.Services;
using OnlyFunds.Tests.TestFixtureBuilders;

namespace OnlyFunds.Tests.Services;

public class ChannelsServiceTest
{
    /*
     Naming your tests should consist of three parts:
        The name of the method being tested.
        The scenario under which it's being tested.
        The expected behavior when the scenario is invoked.
    */
    
    [Fact]
    public async Task GetChannels_HasTwoChannels_ReturnsCorrectTwoChannels()
    {
        //Arrange
        var channel1 = new Channel("Channel1", true);
        var channel2 = new Channel("Channel2", false);
        var channelsService = await new ChannelsServiceTestFixtureBuilder()
            .WithLogger(A.Fake<ILogger<ChannelsService>>())
            .WithChannels(channel1, channel2)
            .Build();

        //Act
        var getChannelsResult = await channelsService.GetChannels();

        //Assert
        getChannelsResult.Channels.Should().NotBeNull();
        getChannelsResult.Channels.Should().HaveCount(2);
        getChannelsResult.Channels!.First().Should().BeEquivalentTo(channel1);
        getChannelsResult.Channels!.Skip(1).First().Should().BeEquivalentTo(channel2);
    }
}