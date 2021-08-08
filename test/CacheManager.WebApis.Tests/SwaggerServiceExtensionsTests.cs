#region Using Statements
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace CacheManager.WebApis.Tests
{
    [TestClass]
    public class SwaggerServiceExtensionsTests
    {
        [TestMethod]
        public void AddSwaggerDocumentationTest()
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();
            string error = null;

            // Act
            try
            {
                SwaggerServiceExtensions.AddSwaggerDocumentation(services);
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }

            // Assert
            Assert.IsNull(error);
        }

        [TestMethod]
        public void UseSwaggerDocumentationTest()
        {
            // Arrange
            IServiceCollection services = new ServiceCollection();
            SwaggerServiceExtensions.AddSwaggerDocumentation(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IApplicationBuilder app = new Microsoft.AspNetCore.Builder.ApplicationBuilder(serviceProvider);
            string error = null;

            // Act
            try
            {
                SwaggerServiceExtensions.UseSwaggerDocumentation(app);
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }

            // Assert
            Assert.IsNull(error);
        }

    }
}
