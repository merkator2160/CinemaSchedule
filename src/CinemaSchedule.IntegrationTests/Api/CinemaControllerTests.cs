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

		[Fact]
		public async Task GetAllMoviesTest()
		{
			using(var factory = new CustomWebApplicationFactory())
			{
				var client = factory.CreateClient();
				var response = await client.GetAsync("/api/Cinema/GetAllMovies");

				response.EnsureSuccessStatusCode();
				var movies = await response.DeserializeAsync<MovieAm[]>();

				Assert.True(movies.Length > 0);
			}
		}

		[Fact]
		public async Task GetMoviesByCinemaIdTest()
		{
			using(var factory = new CustomWebApplicationFactory())
			{
				var client = factory.CreateClient();

				var cinemasResponse = await client.GetAsync("/api/Cinema/GetAllCinemas");

				cinemasResponse.EnsureSuccessStatusCode();
				var cinemas = await cinemasResponse.DeserializeAsync<CinemaAm[]>();

				var moviesResponse = await client.GetAsync($"/api/Cinema/GetMoviesByCinemaId?cinemaId={cinemas[0].Id}");

				moviesResponse.EnsureSuccessStatusCode();
				var movies = await moviesResponse.DeserializeAsync<MovieAm[]>();

				Assert.True(movies.Length > 0);
			}
		}
	}
}