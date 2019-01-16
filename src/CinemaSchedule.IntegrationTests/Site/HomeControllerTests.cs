using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CinemaSchedule.IntegrationTests.Site
{
	public class HomeControllerTests
	{
		[Fact]
		public async Task ScheduleEditorTest()
		{
			using(var factory = new CustomWebApplicationFactory())
			{
				var client = factory.CreateClient();
				var response = await client.GetAsync("/Home/ScheduleEditor");

				response.EnsureSuccessStatusCode();

				Assert.Equal(HttpStatusCode.OK, response.StatusCode);
			}
		}
	}
}