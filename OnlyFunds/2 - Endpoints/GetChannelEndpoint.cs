using OnlyFunds._1___Models.Requests;
using OnlyFunds.Perfis.Attributes;
using OnlyFunds.Perfis.Models;
using OnlyFunds.Services;

namespace OnlyFunds._2___Endpoints;

public class GetChannelEndpoint : Endpoint<GetChannelRequest>
{
    private readonly IChannelsService _channelsService;

    public GetChannelEndpoint(IChannelsService channelsService)
    {
        _channelsService = channelsService ?? throw new ArgumentNullException(nameof(channelsService));
    }
    
    public override void Configure()
    {
        Get("/api/channel/{ChannelName}");
        AllowAnonymous();
    }
    
    [ProfileGuardForSystemActionFilter(SystemAction.LerEntidades)]
    public override async Task HandleAsync(GetChannelRequest req, CancellationToken ct)
    {
        var channel = await _channelsService.GetChannel(req.ChannelName);
        await SendOkAsync(channel, ct);
    }
}