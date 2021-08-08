#region Using Statements
using System.Threading.Tasks;
using CacheManager.WebApis.Models;
using CacheManager.WebApis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace CacheManager.WebApis.api
{
    [Route("api")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        private const string _defaultServerErrorMessage = "Server Error";

        public DefaultController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpPost]
        [Route("getObject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetObject(GetObjectRequest request)
        {
            ResponseBase<CacheObject> toReturn = new();
            toReturn.Message = await _cacheService.GetObject(request);
            if (_cacheService.HasError)
            {
                toReturn.Error = new() { Message = _defaultServerErrorMessage };
            }
            return Ok(toReturn);
        }

        [HttpPost]
        [Route("getObjectCollection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetObjectCollection(GetObjectCollectionRequest request)
        {
            ResponseBase<CacheObjectCollection> toReturn = new();
            toReturn.Message = await _cacheService.GetObjectCollection(request);
            if (_cacheService.HasError)
            {
                toReturn.Error = new() { Message = _defaultServerErrorMessage };
            }
            return Ok(toReturn);
        }

        [HttpPost]
        [Route("getObjectProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetObjectProperty(GetObjectPropertyRequest request)
        {
            ResponseBase<object> toReturn = new();
            toReturn.Message = await _cacheService.GetObjectProperty(request);
            if (_cacheService.HasError)
            {
                toReturn.Error = new() { Message = _defaultServerErrorMessage };
            }
            return Ok(toReturn);
        }

        [HttpPost]
        [Route("setObject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SetObject(CacheObject request)
        {
            ResponseBase<string> toReturn = new();
            await _cacheService.SetObject(request);
            if (_cacheService.HasError)
            {
                toReturn.Error = new() { Message = _defaultServerErrorMessage };
            }
            return Ok(toReturn);
        }

        [HttpPost]
        [Route("setObjectCollection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SetObjectCollection(CacheObjectCollection request)
        {
            ResponseBase<string> toReturn = new();
            await _cacheService.SetObjectCollection(request);
            if (_cacheService.HasError)
            {
                toReturn.Error = new() { Message = _defaultServerErrorMessage };
            }
            return Ok(toReturn);
        }

        [HttpPost]
        [Route("setObjectProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SetObjectProperty(SetObjectPropertyRequest request)
        {
            ResponseBase<string> toReturn = new();
            await _cacheService.SetObjectProperty(request);
            if (_cacheService.HasError)
            {
                toReturn.Error = new() { Message = _defaultServerErrorMessage };
            }
            return Ok(toReturn);
        }
    }
}
