using OnlyFunds._1___Models.Responses;
using OnlyFunds.Services;

namespace OnlyFunds._2___Endpoints;

public class GetChannelsEndpoint : EndpointWithoutRequest<GetChannelsResponse>
{
    private readonly IChannelsService _channelsService;

    public GetChannelsEndpoint(IChannelsService channelsService)
    {
        _channelsService = channelsService ?? throw new ArgumentNullException(nameof(channelsService));
    }
    
    public override void Configure()
    {
        Get("/api/channels");
        ResponseCache(20);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(await _channelsService.GetChannels(), cancellation: ct);
    }
}