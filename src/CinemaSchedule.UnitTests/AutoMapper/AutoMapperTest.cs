using AutoMapper;
using CinemaSchedule.WebSite.Middleware.AutoMapper;
using System.Reflection;
using Xunit;

namespace CinemaSchedule.UnitTests.AutoMapper
{
	public class AutoMapperTest
	{
		[Fact]
		public void AutomapperConfigurationTest()
		{
			var mapperConfiguration = new MapperConfiguration(cfg =>
			{
				cfg.AddProfiles(typeof(AutoMapperModule).GetTypeInfo().Assembly);
			});

			mapperConfiguration.CompileMappings();
			mapperConfiguration.AssertConfigurationIsValid();
		}
	}
}