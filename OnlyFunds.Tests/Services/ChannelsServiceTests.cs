using OnlyFunds._1___Models.Domain;

namespace OnlyFunds.Tests.Services;

public class ChannelsServiceTests
{
    /*
     Naming your tests should consist of three parts:
        The name of the method being tested.
        The scenario under which it's being tested.
        The expected behavior when the scenario is invoked.
    */
    
    [Fact]
    public void GetChannels_HasTwoChannels_ReturnsCorrectTwoChannels()
    {
        //Arrange
        var channel1 = new Channel("Channel1", true);
        var channel2 = new Channel("Channel2", false);

        //Act

        //Assert
        
        
        
        
    }
}