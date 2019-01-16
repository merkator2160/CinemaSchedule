using CinemaSchedule.Common.Consts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace CinemaSchedule.IntegrationTests
{
	public class CustomWebApplicationFactory : WebApplicationFactory<TestStartup>
	{
		// OVERRIDE ///////////////////////////////////////////////////////////////////////////////
		protected override void ConfigureClient(HttpClient client)
		{
			base.ConfigureClient(client);
		}
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			base.ConfigureWebHost(builder);
		}
		protected override TestServer CreateServer(IWebHostBuilder builder)
		{
			return base.CreateServer(builder);
		}
		protected override IWebHostBuilder CreateWebHostBuilder()
		{
			return WebHost.CreateDefaultBuilder()
				.UseEnvironment(HostingEnvironment.Development)
				.UseWebRoot(Environment.CurrentDirectory)
				.UseStartup<TestStartup>()
				.ConfigureLogging(logging =>
				{
					logging.ClearProviders();
					logging.SetMinimumLevel(LogLevel.Trace);
				});
		}
		protected override void Dispose(Boolean disposing)
		{
			base.Dispose(disposing);
		}
		protected override IEnumerable<Assembly> GetTestAssemblies()
		{
			return base.GetTestAssemblies();
		}


		// DEPENDENCY INJECTION ///////////////////////////////////////////////////////////////////
		public T Resolve<T>()
		{
			return (T)Server.Host.Services.GetService(typeof(T));
		}
	}
}