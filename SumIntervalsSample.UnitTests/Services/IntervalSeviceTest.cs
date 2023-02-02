using Newtonsoft.Json;
using SumIntervalsSample.BusinessLibrary.Models;

namespace SumIntervalsSample.UnitTests.Services;

public class IntervalSeviceTest : BaseServiceTest<IntervalSevice>
{
    [Theory]
    [InlineData("[{\"from\":1,\"to\":2}]", 1)]
    [InlineData("[{\"from\":1,\"to\":4}, {\"from\":7,\"to\":10}, {\"from\":3,\"to\":5}]", 7)]
    public void CalculateDistinct_Success(string intervalsJson, int correctResult)
    {
        // Arrange
        var intervals = JsonConvert.DeserializeObject<List<Interval>>(intervalsJson);

        // Act
        var connt = Service.CalculateDistinct(intervals);

        // Assert
        Assert.Equal(correctResult, connt);
    }

    [Theory]
    [InlineData("[{\"from\":111,\"to\":1}]")]
    public void CalculateDistinct_Failed_Exeption(string intervalsJson)
    {
        // Arrange
        var intervals = JsonConvert.DeserializeObject<List<Interval>>(intervalsJson);

        // Act
        void outOfRangeException() => Service.CalculateDistinct(intervals);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(outOfRangeException);
    }
}
