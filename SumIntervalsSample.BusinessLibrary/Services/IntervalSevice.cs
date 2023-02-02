using Microsoft.Extensions.Logging;
using SumIntervalsSample.BusinessLibrary.Services;

namespace SumIntervalsSample.BusinessLibrary.Models;

public class IntervalSevice : BaseService<IntervalSevice>, IIntervalSevice
{
    public IntervalSevice(ILogger<IntervalSevice> logger) : base(logger)
    {
    }

    /// <summary>
    /// Calculate distinct intervals count based in the input given
    /// </summary>
    /// <param name="intervals"></param>
    /// <returns></returns>
    public int CalculateDistinct(List<Interval> intervals)
    {
        Logger.LogInformation($"intervals given: [ {string.Join(", ", intervals)} ]");

        return intervals.Count;
    }
}