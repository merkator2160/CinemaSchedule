using CinemaSchedule.WebSite.Services.Interfaces;
using Quartz;
using System.Threading.Tasks;

namespace CinemaSchedule.WebSite.Middleware.Quartz.Jobs
{
	public class RemoveObsoleteSessionsJob : IJob
	{
		private readonly ICinemaService _cinemaService;


		public RemoveObsoleteSessionsJob(ICinemaService cinemaService)
		{
			_cinemaService = cinemaService;
		}


		// IJob ///////////////////////////////////////////////////////////////////////////////////
		public async Task Execute(IJobExecutionContext context)
		{
			await _cinemaService.RemoveObsoleteSessionsAsync();
		}
	}
}