#region Using Statements
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace CacheManager.WebApis.Tests.Services
{
    [TestClass]
    public abstract class ServiceTestsBase
    {
        protected IConfiguration _configuration;
        protected IDistributedCache _distributedCache;

        [TestInitialize]
        public void Initalize()
        {
            IServiceCollection services = new ServiceCollection();            

            // Configuration
            _configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", true, true)
               .Build();
            services.AddSingleton(_configuration);

            services.AddDistributedMemoryCache();
           

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            _distributedCache = serviceProvider.GetService<IDistributedCache>();
        }

    }
    
}
