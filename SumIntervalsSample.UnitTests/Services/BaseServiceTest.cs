using Microsoft.Extensions.Logging.Abstractions;
using SumIntervalsSample.BusinessLibrary.Services;
using System.Diagnostics.CodeAnalysis;


namespace SumIntervalsSample.UnitTests.Services
{
    [ExcludeFromCodeCoverage]
    public class BaseServiceTest<T> where T : BaseService<T>
    {
        protected T Service { get; private set; }
        public BaseServiceTest() => InitService();

        protected void InitService()
        {
            Service = CreateInstance();
        }

        protected virtual T CreateInstance() => (T)Activator.CreateInstance(typeof(T), NullLogger<T>.Instance);
    }
}
