#region Using Statements
using System.Threading.Tasks;
using CacheManager.WebApis.Models;
#endregion

namespace CacheManager.WebApis.Services
{
    public interface ICacheService
    {
        string ErrorMessage { get; set; }
        bool HasError { get; }
        Task<CacheObject> GetObject(GetObjectRequest request);
        Task<CacheObjectCollection> GetObjectCollection(GetObjectCollectionRequest request);
        Task<object> GetObjectProperty(GetObjectPropertyRequest request);
        Task SetObject(CacheObject request);
        Task SetObjectCollection(CacheObjectCollection request);
        Task SetObjectProperty(SetObjectPropertyRequest request);

    }
}
