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

        /// <summary>
        /// Returns the object if it exists
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A specific object.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /getObject
        ///     {
        ///          "id": 1,
        ///          "type": "User"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Returns a specific object.</response>  
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

        /// <summary>
        /// Returns the object property if it exists
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A specific object property.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /getObjectProperty
        ///     {
        ///          "id": 1,
        ///          "type": "User",
        ///          "propertyName": "Name"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Returns a specific object property.</response>  
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


        /// <summary>
        /// Adds/Updates object
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /setObject
        ///     {
        ///          "id": 1,
        ///          "type": "User",
        ///          "properties": {
        ///             "firstName": "John",
        ///             "lastName": "Doe",
        ///             "email": "john@somewhere.com"
        ///          }
        ///     }
        ///     
        /// </remarks>
        /// <response code="200"></response>  
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

        /// <summary>
        /// Adds/Updates one or more object properties
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /setObjectProperty
        ///     {
        ///          "id": 1,
        ///          "type": "User",
        ///          "properties": {
        ///             "title": "Manager"
        ///          }
        ///     }
        ///     
        /// </remarks>
        /// <response code="200"></response>  
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

        /// <summary>
        /// Refreshes an object if it exists
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /refreshObject
        ///     {
        ///          "id": 1,
        ///          "type": "User"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200"></response>  
        [HttpPost]
        [Route("refreshObject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshObject(RefreshObjectRequest request)
        {
            ResponseBase<string> toReturn = new();
            await _cacheService.RefreshObject(request);
            if (_cacheService.HasError)
            {
                toReturn.Error = new() { Message = _defaultServerErrorMessage };
            }
            return Ok(toReturn);
        }

        /// <summary>
        /// Removes an object if it exists
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /removeObject
        ///     {
        ///          "id": 1,
        ///          "type": "User"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200"></response>  
        [HttpPost]
        [Route("removeObject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveObject(RemoveObjectRequest request)
        {
            ResponseBase<string> toReturn = new();
            await _cacheService.RemoveObject(request);
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

    }
}
