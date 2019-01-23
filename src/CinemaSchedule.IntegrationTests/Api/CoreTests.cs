using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CinemaSchedule.IntegrationTests.Api
{
	public class CoreTests : IClassFixture<CustomWebApplicationFactory>
	{
		private readonly CustomWebApplicationFactory _factory;


		public CoreTests(CustomWebApplicationFactory factory)
		{
			_factory = factory;
		}


		// TESTS //////////////////////////////////////////////////////////////////////////////////
		[Fact]
		public async Task EnvironmentTest()
		{
			var client = _factory.CreateClient();
			var response = await client.GetAsync("/api/Debug/GetEnvironmentName");

			response.EnsureSuccessStatusCode();

			var result = response.Content.ReadAsStringAsync().Result;
			Assert.Equal("Development", result);
		}

		[Fact]
		public async Task DiTest()
		{
			var client = _factory.CreateClient();
			var response = await client.GetAsync("/api/Debug/GetAvailableRepositories");

			response.EnsureSuccessStatusCode();
		}

		[Fact]
		public async Task ErrorHandlingMiddlewareTest()
		{
			var client = _factory.CreateClient();
			var response = await client.GetAsync("/api/Debug/CreateUnhandledException");
			var result = response.Content.ReadAsStringAsync().Result;

			Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
			Assert.Equal("Exception message!", result);
		}
	}
}