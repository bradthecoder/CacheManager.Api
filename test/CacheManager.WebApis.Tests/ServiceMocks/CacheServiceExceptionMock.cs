#region Using Statements
using System.Threading.Tasks;
using CacheManager.WebApis.Models;
using CacheManager.WebApis.Services;
#endregion

namespace CacheManager.WebApis.Tests.ServiceMocks
{
    public class CacheServiceExceptionMock : ICacheService
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        public async Task<CacheObject> GetObject(GetObjectRequest request)
        {
            this.ErrorMessage = "error";
            return new CacheObject();
        }

        public async Task<CacheObjectCollection> GetObjectCollection(GetObjectCollectionRequest request)
        {
            this.ErrorMessage = "error";
            return new CacheObjectCollection();
        }

        public async Task<object> GetObjectProperty(GetObjectPropertyRequest request)
        {
            this.ErrorMessage = "error";
            return new() { };
        }

        public async Task SetObject(CacheObject request)
        {
            this.ErrorMessage = "error";
            return;
        }

        public async Task SetObjectCollection(CacheObjectCollection request)
        {
            this.ErrorMessage = "error";
            return;
        }

        public async Task SetObjectProperty(SetObjectPropertyRequest request)
        {
            this.ErrorMessage = "error";
            return;
        }
    }
}
