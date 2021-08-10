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
        Task SetObject(CacheObject request);
        Task<object> GetObjectProperty(GetObjectPropertyRequest request);
        Task SetObjectProperty(SetObjectPropertyRequest request);
        Task RefreshObject(RefreshObjectRequest request);
        Task RemoveObject(RemoveObjectRequest request);

        Task RemoveObjectProperty(RemoveObjectPropertyRequest request);

    }
}
