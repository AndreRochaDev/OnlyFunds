using OnlyFunds._1___Models.Domain;
using OnlyFunds._1___Models.Requests;
using OnlyFunds._1___Models.Responses;

namespace OnlyFunds.Mappers;

public class CreateChannelMapper : Mapper<CreateChannelRequest, CreateChannelResponse, Channel>
{
    public override Channel ToEntity(CreateChannelRequest request)
    {
        return new Channel($"{request.FirstName}'s channel.", request.Age >= 18);
    }

    public override CreateChannelResponse FromEntity(Channel channel)
    {
        return new CreateChannelResponse { CreatedChannelName = channel.ChannelName, IsAdult = channel.IsAdult };
    }
}