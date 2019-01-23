using Autofac;
using Autofac.Extensions.DependencyInjection;
using CinemaSchedule.Common.DependencyInjection;
using CinemaSchedule.Database;
using CinemaSchedule.Database.DependencyInjection;
using CinemaSchedule.WebSite.Middleware;
using CinemaSchedule.WebSite.Middleware.AutoMapper;
using CinemaSchedule.WebSite.Middleware.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CinemaSchedule.IntegrationTests
{
	public class TestStartup
	{
		private readonly IConfiguration _configuration;
		private readonly IHostingEnvironment _env;


		public TestStartup(IHostingEnvironment env)
		{
			_env = env;
			_configuration = CustomConfigurationProvider.CreateConfiguration(env.EnvironmentName, env.ContentRootPath);
		}


		// FUNCTIONS //////////////////////////////////////////////////////////////////////////////
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});
			services.AddConfiguredSwaggerGen();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			return BuildServiceProvider(services);
		}
		private IServiceProvider BuildServiceProvider(IServiceCollection services)
		{
			var webSiteAssembly = Collector.GetAssembly("CinemaSchedule.WebSite");
			var builder = new ContainerBuilder();

			builder.RegisterServices(webSiteAssembly);
			builder.RegisterConfiguration(_configuration, webSiteAssembly);

			builder.RegisterModule(new DatabaseModule(_configuration));
			builder.RegisterModule(new AutoMapperModule(Collector.LoadAssemblies("CinemaSchedule.WebSite")));

			builder.Populate(services);

			return new AutofacServiceProvider(builder.Build());
		}
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataSeeder dataSeeder)
		{
			dataSeeder.DropCreateInitializeStrategy();

			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseConfiguredSwagger();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=ScheduleViewer}/{id?}");
			});
		}
	}
}