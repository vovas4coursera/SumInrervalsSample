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

        var corruptedInervals = intervals.Where(item => item.From > item.To);
        if (corruptedInervals.Any())
        {
            throw new ArgumentOutOfRangeException($"To-value should be GreaterThanOrEqualTo From-value. corrupted intervals: [ {string.Join(", ", intervals)} ]");
        }


        List<string> splittedIntervals = new();
        intervals.ForEach(item =>
        {
            var itemSplittedInervals = Enumerable.Range(item.From, item.To - item.From) // generate atomic interlvals for item
                .Select(i => i.ToString() + (i + 1).ToString()) // project to string representation
                .ToList();

            splittedIntervals.AddRange(itemSplittedInervals);
        });

       return splittedIntervals.Distinct().Count(); 
    }
}