#region Using Statements
using System.Threading.Tasks;
using CacheManager.WebApis.api;
using CacheManager.WebApis.Models;
using CacheManager.WebApis.Tests.ServiceMocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace CacheManager.WebApis.Tests.api
{
    [TestClass]
    public class DefaultControllerTests
    {
        private readonly CacheServiceMock _mockService = new CacheServiceMock();
        private readonly CacheServiceExceptionMock _errorService = new CacheServiceExceptionMock();

        [TestMethod]
        public async Task GetObject_Test()
        {
            // Arrange
            DefaultController target = new DefaultController(_mockService);
            GetObjectRequest input = new();

            // Act
            var actual = await target.GetObject(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<CacheObject>)actual.Value);
            Assert.IsNull(response.Error);
        }

        [TestMethod]
        public async Task GetObjectCollection_Test()
        {
            // Arrange
            DefaultController target = new DefaultController(_mockService);
            GetObjectCollectionRequest input = new();

            // Act
            var actual = await target.GetObjectCollection(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<CacheObjectCollection>)actual.Value);
            Assert.IsNull(response.Error);
        }

        [TestMethod]
        public async Task GetObjectProperty_Test()
        {
            // Arrange
            DefaultController target = new DefaultController(_mockService);
            GetObjectPropertyRequest input = new();

            // Act
            var actual = await target.GetObjectProperty(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<object>)actual.Value);
            Assert.IsNull(response.Error);
        }

        [TestMethod]
        public async Task SetObject_Test()
        {
            // Arrange
            DefaultController target = new DefaultController(_mockService);
            CacheObject input = new();

            // Act
            var actual = await target.SetObject(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<string>)actual.Value);
            Assert.IsNull(response.Error);
        }

        [TestMethod]
        public async Task SetObjectCollection_Test()
        {
            // Arrange
            DefaultController target = new DefaultController(_mockService);
            CacheObjectCollection input = new();

            // Act
            var actual = await target.SetObjectCollection(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<string>)actual.Value);
            Assert.IsNull(response.Error);
        }

        [TestMethod]
        public async Task SetObjectProperty_Test()
        {
            // Arrange
            DefaultController target = new DefaultController(_mockService);
            SetObjectPropertyRequest input = new();

            // Act
            var actual = await target.SetObjectProperty(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<string>)actual.Value);
            Assert.IsNull(response.Error);
        }

        //EXCEPTIONS

        [TestMethod]
        public async Task GetObject_Test_Exception()
        {
            // Arrange
            DefaultController target = new DefaultController(_errorService);
            GetObjectRequest input = new();

            // Act
            var actual = await target.GetObject(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<CacheObject>)actual.Value);
            Assert.IsFalse(string.IsNullOrEmpty(response.Error.Message));
        }

        [TestMethod]
        public async Task GetObjectCollection_Test_Exception()
        {
            // Arrange
            DefaultController target = new DefaultController(_errorService);
            GetObjectCollectionRequest input = new();

            // Act
            var actual = await target.GetObjectCollection(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<CacheObjectCollection>)actual.Value);
            Assert.IsFalse(string.IsNullOrEmpty(response.Error.Message));
        }

        [TestMethod]
        public async Task GetObjectProperty_Test_Exception()
        {
            // Arrange
            DefaultController target = new DefaultController(_errorService);
            GetObjectPropertyRequest input = new();

            // Act
            var actual = await target.GetObjectProperty(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<object>)actual.Value);
            Assert.IsFalse(string.IsNullOrEmpty(response.Error.Message));
        }

        [TestMethod]
        public async Task SetObject_Test_Exception()
        {
            // Arrange
            DefaultController target = new DefaultController(_errorService);
            CacheObject input = new();

            // Act
            var actual = await target.SetObject(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<string>)actual.Value);
            Assert.IsFalse(string.IsNullOrEmpty(response.Error.Message));
        }

        [TestMethod]
        public async Task SetObjectCollection_Test_Exception()
        {
            // Arrange
            DefaultController target = new DefaultController(_errorService);
            CacheObjectCollection input = new();

            // Act
            var actual = await target.SetObjectCollection(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<string>)actual.Value);
            Assert.IsFalse(string.IsNullOrEmpty(response.Error.Message));
        }

        [TestMethod]
        public async Task SetObjectProperty_Test_Exception()
        {
            // Arrange
            DefaultController target = new DefaultController(_errorService);
            SetObjectPropertyRequest input = new();

            // Act
            var actual = await target.SetObjectProperty(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(actual);
            var response = ((ResponseBase<string>)actual.Value);
            Assert.IsFalse(string.IsNullOrEmpty(response.Error.Message));
        }

    }
}
