using Microsoft.Extensions.Logging;

namespace SumIntervalsSample.BusinessLibrary.Services;

public class BaseService<T> where T : BaseService<T>
{
    protected readonly ILogger<T> Logger;
    public BaseService(ILogger<T> logger)
    {
        Logger = logger;
    }
}
