#region Using Statements
using System.Collections.Generic;
using System.Threading.Tasks;
using CacheManager.WebApis.Models;
using CacheManager.WebApis.Services;
#endregion

namespace CacheManager.WebApis.Tests.ServiceMocks
{
    public class CacheServiceMock : ICacheService
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        public async Task<CacheObject> GetObject(GetObjectRequest request)
        {
            return new CacheObject() { Id = 1, Type = CacheObjectType.User, Properties = new Dictionary<string, object>() };
        }

        public async Task<object> GetObjectProperty(GetObjectPropertyRequest request)
        {
            return new() { };
        }

        public async Task RefreshObject(RefreshObjectRequest request)
        {
            return;
        }

        public async Task RemoveObject(RemoveObjectRequest request)
        {
            return;
        }

        public async Task RemoveObjectProperty(RemoveObjectPropertyRequest request)
        {
            return;
        }

        public async Task SetObject(CacheObject request)
        {
            return;
        }

        public async Task SetObjectProperty(SetObjectPropertyRequest request)
        {
            return;
        }
    }
}
