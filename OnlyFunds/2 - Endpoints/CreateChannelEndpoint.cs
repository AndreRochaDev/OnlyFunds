using OnlyFunds._1___Models.Requests;
using OnlyFunds._1___Models.Responses;
using OnlyFunds.Mappers;
using OnlyFunds.Services;

namespace OnlyFunds._2___Endpoints;

public class CreateChannelEndpoint : Endpoint<CreateChannelRequest, CreateChannelResponse, CreateChannelMapper>
{
    private readonly IChannelsService _channelsService;

    public CreateChannelEndpoint(IChannelsService channelsService)
    {
        _channelsService = channelsService ?? throw new ArgumentNullException(nameof(channelsService));
    }
    
    public override void Configure()
    {
        Post("/api/channel");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CreateChannelRequest req, CancellationToken ct)
    {
        var createChannel = await _channelsService.CreateChannel(Map.ToEntity(req));
        await SendCreatedAtAsync<GetChannelEndpoint>(new 
            { createChannel.ChannelName }, 
            Map.FromEntity(createChannel), 
            cancellation: ct);
    }
}