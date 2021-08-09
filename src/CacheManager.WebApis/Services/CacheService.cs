#region Using Statements
using System;
using System.Text.Json;
using System.Threading.Tasks;
using CacheManager.WebApis.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
#endregion

namespace CacheManager.WebApis.Services
{
    public class CacheService : ICacheService
    {
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _cache;

        public CacheService(IConfiguration configuration, IDistributedCache cache)
        {
            _configuration = configuration;
            _cache = cache;
        }
        
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        private DistributedCacheEntryOptions CacheOptions
        {
            get {
                int minutes = _configuration.GetValue<int>("SlidingExpirationMinutes");
                return new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(minutes)); 
            }
        }

        public static byte[] ObjectToByteArray(object input)
        {
            return JsonSerializer.SerializeToUtf8Bytes(input);
        }

        public static T ByteArrayToObject<T>(byte[] input)
        {
            var readOnlySpan = new ReadOnlySpan<byte>(input);
            return JsonSerializer.Deserialize<T>(readOnlySpan);
        }


        public async Task<CacheObject> GetObject(GetObjectRequest request)
        {
            CacheObject toReturn = null;
            byte[] value = await _cache.GetAsync($"{request.Type}-{request.Id}");
            if (value != null)
            {
                toReturn = ByteArrayToObject<CacheObject>(value);
            }
            return toReturn;
        }

        public async Task SetObject(CacheObject request)
        {
            await _cache.SetAsync($"{request.Type}-{request.Id}", ObjectToByteArray(request), CacheOptions);
            return;
        }

        public async Task<object> GetObjectProperty(GetObjectPropertyRequest request)
        {
            object toReturn = null;
            if (string.IsNullOrEmpty(request.PropertyName))
            {
                return toReturn;
            }
            CacheObject cacheObject = await GetObject(new GetObjectRequest { Id = request.Id, Type = request.Type });
            if (cacheObject != null && cacheObject.Properties != null)
            {
                cacheObject.Properties.TryGetValue(request.PropertyName, out toReturn);
            }
            return toReturn;
        }

        public async Task SetObjectProperty(SetObjectPropertyRequest request)
        {
            CacheObject cacheObject = await GetObject(new GetObjectRequest { Id = request.Id, Type = request.Type });

            if (cacheObject == null)
            {
                cacheObject = new()
                {
                    Id = request.Id,
                    Type = request.Type,
                    Properties = new()
                };
            }
            foreach (var kvp in request.Properties)
            {
                cacheObject.Properties.Remove(kvp.Key);
                cacheObject.Properties.Add(kvp.Key, kvp.Value);
            }
            await SetObject(cacheObject);
            return;
        }

        public async Task RefreshObject(RefreshObjectRequest request)
        {
            await _cache.RefreshAsync($"{request.Type}-{request.Id}");
            return;
        }

        public async Task RemoveObject(RemoveObjectRequest request)
        {
            await _cache.RemoveAsync($"{request.Type}-{request.Id}");
            return;
        }

        #region ObjectCollection
        public async Task<CacheObjectCollection> GetObjectCollection(GetObjectCollectionRequest request)
        {
            CacheObjectCollection toReturn = null;
            byte[] value = await _cache.GetAsync($"{request.Type}-{request.Id}");
            if (value != null)
            {
                toReturn = ByteArrayToObject<CacheObjectCollection>(value);
            }
            return toReturn;
        }
        public async Task SetObjectCollection(CacheObjectCollection request)
        {
            await _cache.SetAsync($"{request.Type}-{request.Id}", ObjectToByteArray(request), CacheOptions);
            return;
        } 
        #endregion

    }
}
