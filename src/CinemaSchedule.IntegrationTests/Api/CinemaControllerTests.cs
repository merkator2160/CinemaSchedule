using CinemaSchedule.Contracts.Models;
using System.Threading.Tasks;
using Xunit;

namespace CinemaSchedule.IntegrationTests.Api
{
	public class CinemaControllerTests
	{
		[Fact]
		public async Task GetAllCinemasTest()
		{
			using(var factory = new CustomWebApplicationFactory())
			{
				var client = factory.CreateClient();
				var response = await client.GetAsync("/api/Cinema/GetAllCinemas");

				response.EnsureSuccessStatusCode();
				var cinemas = await response.DeserializeAsync<CinemaAm[]>();

				Assert.True(cinemas.Length > 0);
			}
		}
	}
}