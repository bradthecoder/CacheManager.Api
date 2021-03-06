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

        public async Task<object> GetObjectProperty(GetObjectPropertyRequest request)
        {
            this.ErrorMessage = "error";
            return new() { };
        }

        public async Task RefreshObject(RefreshObjectRequest request)
        {
            this.ErrorMessage = "error";
            return;
        }

        public async Task RemoveObject(RemoveObjectRequest request)
        {
            this.ErrorMessage = "error";
            return;
        }

        public async Task RemoveObjectProperty(RemoveObjectPropertyRequest request)
        {
            this.ErrorMessage = "error";
            return;
        }

        public async Task SetObject(CacheObject request)
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
