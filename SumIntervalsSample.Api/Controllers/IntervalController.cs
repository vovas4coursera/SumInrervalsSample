
using Microsoft.AspNetCore.Mvc;
using SumIntervalsSample.BusinessLibrary.Models;

namespace SumIntervalsSample.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IntervalController : ControllerBase
{
    private readonly IIntervalSevice _intervalSeavice;
    private readonly ILogger<IntervalController> _logger;

    public IntervalController(IIntervalSevice intervalSevice, ILogger<IntervalController> logger)
    {
        this._intervalSeavice = intervalSevice;
        _logger = logger;
    }

    /// <summary>
    /// Calculate distinct intervals count, based in the input given
    /// </summary>
    /// <param name="intervals" example="[ {"from":2, "to":10} ]"></param>
    /// <returns>intervals count result</returns>
    [HttpPost(Name = "CalculateDistinct")]
    public int CalculateDistinct([FromBody] List<Interval> intervals)
    {
        return _intervalSeavice.CalculateDistinct(intervals);
    }
}
