using FakeItEasy;
using FastEndpoints;
using FluentAssertions;
using OnlyFunds._1___Models.Domain;
using OnlyFunds._1___Models.Responses;
using OnlyFunds._2___Endpoints;
using OnlyFunds.Services;

namespace OnlyFunds.Tests._2___Endpoints;

public class GetChannelsEndpointTest
{
    [Fact]
    public async Task HandleAsync_HasTwoChannels_ReturnsCorrectTwoChannels()
    {
        //Arrange
        var channel1 = new Channel("Channel1", true);
        var channel2 = new Channel("Channel2", false);
        var channelsService = A.Fake<IChannelsService>();
        A.CallTo(() => channelsService.GetChannels()).Returns(
            new GetChannelsResponse()
            {
                Channels = new List<Channel> { channel1, channel2 }
            });
        
        var endpoint = Factory.Create<GetChannelsEndpoint>(channelsService);
        
        //Act
        await endpoint.HandleAsync(default);
        var response = endpoint.Response;

        //Assert
        response.Channels.Should().NotBeNull();
        response.Channels.Should().HaveCount(2);
        response.Channels!.First().Should().BeEquivalentTo(channel1);
        response.Channels!.Skip(1).First().Should().BeEquivalentTo(channel2);
    }
}