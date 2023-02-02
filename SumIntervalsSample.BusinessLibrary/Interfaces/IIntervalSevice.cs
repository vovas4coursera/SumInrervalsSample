namespace SumIntervalsSample.BusinessLibrary.Models;

public interface IIntervalSevice
{
    /// <summary>
    /// Calculate distinct intervals count, based in the input given
    /// </summary>
    /// <param name="intervals"></param>
    /// <returns></returns>
    int CalculateDistinct(List<Interval> intervals);
}