using Autofac;
using Autofac.Extras.Quartz;
using CinemaSchedule.WebSite.Middleware.Quartz.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Collections.Specialized;
using System.Reflection;

namespace CinemaSchedule.WebSite.Middleware.Quartz
{
	internal static class QuartzMiddleware
	{
		// FUNCTIONS //////////////////////////////////////////////////////////////////////////////
		public static void AddQuartz(this ContainerBuilder builder, Assembly[] assembliesToScan)
		{
			builder.RegisterModule(new QuartzAutofacFactoryModule()
			{
				ConfigurationProvider = c => new NameValueCollection
				{
					{"quartz.threadPool.threadCount", "3"},
					{"quartz.scheduler.threadName", "Scheduler"}
				}
			});
			builder.RegisterModule(new QuartzAutofacJobsModule(assembliesToScan));
		}
		public static void UseQuartz(this IApplicationBuilder builder)
		{
			var scheduler = builder.ApplicationServices.GetRequiredService<IScheduler>();
			scheduler.Start();
		}
		public static void RegisterQuartzJobs(this IContainer container)
		{
			var scheduler = container.Resolve<IScheduler>();
			scheduler
				.RegisterRemoveObsoleteSessionsJob();
		}
		public static IScheduler RegisterSampleJob(this IScheduler scheduler)
		{
			var job = JobBuilder.Create<SampleJob>()
				.WithIdentity("Heartbeat", "Maintenance")
				.Build();

			var trigger = TriggerBuilder.Create()
				.WithIdentity("Heartbeat", "Maintenance")
				.StartNow()
				.WithSchedule(SimpleScheduleBuilder.RepeatSecondlyForever(2))
				.Build();

			scheduler.ScheduleJob(job, trigger).ConfigureAwait(true).GetAwaiter().GetResult();

			return scheduler;
		}
		public static IScheduler RegisterRemoveObsoleteSessionsJob(this IScheduler scheduler)
		{
			var job = JobBuilder.Create<RemoveObsoleteSessionsJob>()
				.WithIdentity("RemoveObsoleteSessions", "Maintenance")
				.Build();

			var trigger = TriggerBuilder.Create()
				.WithIdentity("RemoveObsoleteSessions", "Maintenance")
				.WithCronSchedule("0 0 0 * * ?")    // Every day at midnight - 12am
				.Build();

			scheduler.ScheduleJob(job, trigger).ConfigureAwait(true).GetAwaiter().GetResult();

			return scheduler;
		}
	}
}