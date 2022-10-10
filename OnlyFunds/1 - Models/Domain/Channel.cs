namespace OnlyFunds._1___Models.Domain;

public class Channel
{
    public Channel(string channelName, bool isAdult)
    {
        ChannelName = channelName;
        IsAdult = isAdult;
    }

    public string ChannelName { get; set; }
    public bool IsAdult { get; set; }
}

public class ChannelRequest
{
    public string ChannelName { get; set; }
}