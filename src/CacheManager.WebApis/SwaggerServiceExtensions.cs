#region Using Statements
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace CacheManager.WebApis
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
			// https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.1&tabs=visual-studio%2Cvisual-studio-xml
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "CacheManager Api",
                    //Description = "A description of the API should be defined.",
                    //TermsOfService = new Uri("https://example.com/terms"),
                    //Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    //{
                    //    Name = "John Doe",
                    //    Email = "johndoe@somewhere.com",
                    //    Url = new Uri("https://twitter.com/microsoft"),
                    //},
                    //License = new Microsoft.OpenApi.Models.OpenApiLicense
                    //{
                    //    Name = "Use under LICX",
                    //    Url = new Uri("https://example.com/license"),
                    //}
                });

                //c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
                //c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                //        { "Bearer", Enumerable.Empty<string>() },
                //    });
                
                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
 
            return services;
        }
 
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "CacheManager Api v1.0");

            });
 
            return app;
        }
    }
}
