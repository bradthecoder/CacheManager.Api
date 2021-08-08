#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CacheManager.WebApis.Models;
using CacheManager.WebApis.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace CacheManager.WebApis.Tests.Services
{
    [TestClass]
    public class CacheServiceTests : ServiceTestsBase
    {
        private CacheObject MockCacheObject()
        {
            CacheObject input = new() { Id = 99, Properties = new Dictionary<string, object>() };
            input.Properties.Add("Name", "Some User");
            input.Properties.Add("Today", DateTime.Now);
            return input;
        }

        private CacheObjectCollection MockCacheObjectCollection()
        {
            CacheObjectCollection input = new() { Id = 999, Type = CacheObjectCollectionType.DataXyz, Items = new List<object>() };
            input.Items.Add(new { Id = Guid.NewGuid(), Message = "hello world" });
            input.Items.Add(new { Id = Guid.NewGuid(), Message = "this is a test" });
            return input;
        }

        [TestMethod]
        public void HasError_True_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            target.ErrorMessage = "error";

            // Act
            var actual = target.HasError;

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HasError_False_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);

            // Act
            var actual = target.HasError;

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ObjectToByteArray_Test()
        {
            // Arrange
            //CacheService target = new CacheService(_configuration, _distributedCache);
            var input = this.MockCacheObject();

            // Act
            var actual = (byte[])CacheService.ObjectToByteArray(input);
            //string hexval = "0x" + BitConverter.ToString(actual).Replace("-",",0x");

            // Assert 
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public async Task ByteArrayToObject_Test()
        {
            // Arrange
            //CacheService target = new CacheService(_configuration, _distributedCache);
            byte[] input = { 0x7B, 0x22, 0x49, 0x64, 0x22, 0x3A, 0x39, 0x39,
                    0x2C, 0x22, 0x54, 0x79, 0x70, 0x65, 0x22, 0x3A, 0x30, 0x2C, 0x22,
                    0x50, 0x72, 0x6F, 0x70, 0x65, 0x72, 0x74, 0x69, 0x65, 0x73, 0x22,
                    0x3A, 0x7B, 0x22, 0x4E, 0x61, 0x6D, 0x65, 0x22, 0x3A, 0x22, 0x53,
                    0x6F, 0x6D, 0x65, 0x20, 0x55, 0x73, 0x65, 0x72, 0x22, 0x2C, 0x22,
                    0x54, 0x6F, 0x64, 0x61, 0x79, 0x22, 0x3A, 0x22, 0x32, 0x30, 0x32,
                    0x31, 0x2D, 0x30, 0x38, 0x2D, 0x30, 0x38, 0x54, 0x31, 0x33, 0x3A,
                    0x35, 0x36, 0x3A, 0x33, 0x34, 0x2E, 0x36, 0x36, 0x39, 0x38, 0x39,
                    0x30, 0x33, 0x2D, 0x30, 0x35, 0x3A, 0x30, 0x30, 0x22, 0x7D, 0x7D };

            // Act
            var actual = CacheService.ByteArrayToObject<CacheObject>(input);

            // Assert 
            Assert.IsNotNull(actual);
        }


        [TestMethod]
        public async Task SetObject_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            var input = this.MockCacheObject();

            // Act
            await target.SetObject(input);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public async Task SetObjectProperty_Existing_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            var existing = this.MockCacheObject();
            await target.SetObject(existing);
            SetObjectPropertyRequest input = new() { Id = existing.Id, Type = existing.Type, Properties = new Dictionary<string, object>() };
            input.Properties.Add("compelex", new { Message = "hello world" });

            // Act
            await target.SetObjectProperty(input);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public async Task SetObjectProperty_New_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            var existing = this.MockCacheObject();
            //await target.SetObject(existing);
            SetObjectPropertyRequest input = new() { Id = existing.Id, Type = existing.Type, Properties = new Dictionary<string, object>() };
            input.Properties.Add("compelex", new { Message = "hello world" });

            // Act
            await target.SetObjectProperty(input);

            // Assert
            Assert.IsFalse(target.HasError);
        }

        [TestMethod]
        public async Task SetObjectCollection_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            CacheObjectCollection input = MockCacheObjectCollection();

            // Act
            await target.SetObjectCollection(input);

            // Assert
            Assert.IsFalse(target.HasError);
        }


        [TestMethod]
        public async Task GetObject__Null_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            var existing = MockCacheObject();
            var input = new GetObjectRequest() { Id = existing.Id, Type = existing.Type };

            // Act
           var actual = await target.GetObject(input);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public async Task GetObject_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            var existing = MockCacheObject();
            await target.SetObject(existing);
            var input = new GetObjectRequest() { Id = existing.Id, Type = existing.Type };

            // Act
            var actual = await target.GetObject(input);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public async Task GetObjectProperty_Null_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            var existing = MockCacheObject();
            var input = new GetObjectPropertyRequest() { Id = existing.Id, Type = existing.Type, PropertyName = "unknown" };

            // Act
            var actual = await target.GetObjectProperty(input);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public async Task GetObjectProperty_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            var existing = MockCacheObject();
            await target.SetObject(existing);
            var input = new GetObjectPropertyRequest() { Id = existing.Id, Type = existing.Type, PropertyName = "Today" };

            // Act
            var actual = await target.GetObjectProperty(input);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public async Task GetObjectProperty_EmptyName_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            var existing = MockCacheObject();
            var input = new GetObjectPropertyRequest() { Id = existing.Id, Type = existing.Type };

            // Act
            var actual = await target.GetObjectProperty(input);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public async Task GetObjectCollection__Null_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            var existing = MockCacheObjectCollection();
            var input = new GetObjectCollectionRequest() { Id = existing.Id, Type = existing.Type };

            // Act
            var actual = await target.GetObjectCollection(input);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public async Task GetObjectCollection_Test()
        {
            // Arrange
            CacheService target = new CacheService(_configuration, _distributedCache);
            var existing = MockCacheObjectCollection();
            await target.SetObjectCollection(existing);
            var input = new GetObjectCollectionRequest() { Id = existing.Id, Type = existing.Type };

            // Act
            var actual = await target.GetObjectCollection(input);

            // Assert
            Assert.IsFalse(target.HasError);
            Assert.IsNotNull(actual);
        }

    }
}
