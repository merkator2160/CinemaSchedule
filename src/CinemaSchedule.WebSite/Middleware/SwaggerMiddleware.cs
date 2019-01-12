using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace CinemaSchedule.WebSite.Middleware
{
	internal static class SwaggerMiddleware
	{
		public static void AddConfiguredSwaggerGen(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("CinemaSchedule", new Info
				{
					Title = "CinemaSchedule API",
					Version = "v1"
				});
				c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Documentation.xml"));
				c.IgnoreObsoleteActions();
				c.IgnoreObsoleteProperties();
			});
		}
		public static void UseConfiguredSwagger(this IApplicationBuilder app)
		{
			app.UseSwagger(c =>
			{
				c.RouteTemplate = "api-docs/{documentName}/swagger.json";
			});
			app.UseSwaggerUI(c =>
			{
				c.RoutePrefix = "api-docs";
				c.SwaggerEndpoint("/api-docs/CinemaSchedule/swagger.json", "CinemaSchedule API V1");
			});
		}
	}
}