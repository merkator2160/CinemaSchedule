using AutoMapper;
using System.Reflection;
using Xunit;

namespace CinemaSchedule.UnitTests.AutoMapper
{
	public class AutoMapperTest
	{
		[Fact]
		public void TheWholeAutomapperConfigurationTest()
		{
			var mapperConfiguration = new MapperConfiguration(cfg =>
			{
				cfg.AddProfiles(typeof(AutoMapperMiddleware).GetTypeInfo().Assembly);
			});

			mapperConfiguration.CompileMappings();
			mapperConfiguration.AssertConfigurationIsValid();
		}
	}
}