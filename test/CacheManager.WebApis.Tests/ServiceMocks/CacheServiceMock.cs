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

        public async Task<CacheObjectCollection> GetObjectCollection(GetObjectCollectionRequest request)
        {
            return new CacheObjectCollection() { Id = 10, Type = CacheObjectCollectionType.DataXyz, Items = new List<object>() } ;
        }

        public async Task<object> GetObjectProperty(GetObjectPropertyRequest request)
        {
            return new() { };
        }

        public async Task SetObject(CacheObject request)
        {
            return;
        }

        public async Task SetObjectCollection(CacheObjectCollection request)
        {
            return;
        }

        public async Task SetObjectProperty(SetObjectPropertyRequest request)
        {
            return;
        }
    }
}
