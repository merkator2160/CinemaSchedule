using Quartz;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.WebSite.Middleware.Quartz.Jobs
{
	/// <summary>
	/// A sample job that just prints info on console for demonstration purposes.
	/// </summary>
	public class SampleJob : IJob
	{
		public async Task Execute(IJobExecutionContext context)
		{
			Console.WriteLine($"Job: {context.JobDetail.Description} executing...");

			await Task.Delay(TimeSpan.FromSeconds(5));

			Console.WriteLine($"Job: {context.JobDetail.Description} executed");
		}
	}
}