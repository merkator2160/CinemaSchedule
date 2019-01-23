using CinemaSchedule.Contracts.Models;
using CinemaSchedule.Database.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
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

		[Fact]
		public async Task CreateDatesForEditorTest()
		{
			using(var factory = new CustomWebApplicationFactory())
			{
				var client = factory.CreateClient();

				var datesResponse = await client.GetAsync("/api/Cinema/CreateDatesForEditor");

				datesResponse.EnsureSuccessStatusCode();
				var dates = await datesResponse.DeserializeAsync<ScheduleEditorDateAm[]>();

				Assert.Equal(30, dates.Length);
			}
		}

		[Fact]
		public async Task GetSessionsTest()
		{
			using(var factory = new CustomWebApplicationFactory())
			{
				var client = factory.CreateClient();
				using(var scope = factory.Server.Host.Services.CreateScope())
				{
					var repositoryBundle = scope.ServiceProvider.GetRequiredService<IRepositoryBundle>();
					var sessionsDb = repositoryBundle.Sessions.GetAll().First();


					var sessionsResponse = await client.GetAsync("/api/Cinema/GetSessions?" +
																 $"cinemaId={sessionsDb.CinemaId}&" +
																 $"movieId={sessionsDb.MovieId}&" +
																 $"date={sessionsDb.StartDate.AddDays(1)}");

					sessionsResponse.EnsureSuccessStatusCode();
					var sessions = await sessionsResponse.DeserializeAsync<SessionAm[]>();

					Assert.Equal(1, sessions.Length);
				}
			}
		}

		[Fact]
		public async Task DeleteSessionTest()
		{
			using(var factory = new CustomWebApplicationFactory())
			{
				var client = factory.CreateClient();
				using(var scope = factory.Server.Host.Services.CreateScope())
				{
					var repositoryBundle = scope.ServiceProvider.GetRequiredService<IRepositoryBundle>();

					var sessionsDb = repositoryBundle.Sessions.GetAll();
					var firstSession = sessionsDb.First();
					var initialSessionsCount = sessionsDb.Length;


					var sessionsResponse = await client.DeleteAsync($"/api/Cinema/DeleteSession/{firstSession.Id}");

					sessionsResponse.EnsureSuccessStatusCode();

					var sessionQuantityAfterDeletion = repositoryBundle.Sessions.GetQuantity();
					Assert.Equal(initialSessionsCount - 1, sessionQuantityAfterDeletion);
				}
			}
		}

		[Fact]
		public async Task GetSessionsForScheduleViewerTest()
		{
			using(var factory = new CustomWebApplicationFactory())
			{
				var client = factory.CreateClient();
				var sessionResponse = await client.GetAsync("/api/Cinema/GetSessionsForScheduleViewer");

				sessionResponse.EnsureSuccessStatusCode();
				var sessions = await sessionResponse.DeserializeAsync<SessionWithCinemaAndMovieAm[]>();

				Assert.Equal(4, sessions.Length);
				foreach(var x in sessions)
				{
					Assert.NotNull(x.Id);
					Assert.NotNull(x.Cinema);
					Assert.NotNull(x.Movie);
				}
			}
		}
	}
}