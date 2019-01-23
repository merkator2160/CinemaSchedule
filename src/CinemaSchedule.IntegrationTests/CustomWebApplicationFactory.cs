using CinemaSchedule.Common.Consts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using System;

namespace CinemaSchedule.IntegrationTests
{
	public class CustomWebApplicationFactory : WebApplicationFactory<TestStartup>
	{
		// OVERRIDE ///////////////////////////////////////////////////////////////////////////////
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
	}
}