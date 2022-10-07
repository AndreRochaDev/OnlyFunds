using OnlyFunds._1___Models.Domain;

namespace OnlyFunds._1___Models.Responses;

public class GetChannelsResponse
{
    public IEnumerable<Channel>? Channels { get; set; }

    public int TestInt { get; set; } = default;
    public int? TestIntNullable { get; set; }
    
    public string TestString { get; set; } = "Test";
    public string? TestStringNullable { get; set; } = null;

    public bool TestBool { get; set; } = true;
    public bool? TestBoolNullable { get; set; } = null;

    public Channel TestObject { get; set; } = new Channel("name", true);
    public Channel? TestObjectNullable { get; set; } = null;
    
    public int[] TestArray { get; set; } = new []{1,2,3};
    public int[]? TestArrayNullable { get; set; } = null;
}