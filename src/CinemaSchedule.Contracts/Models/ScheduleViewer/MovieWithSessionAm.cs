using System;

namespace CinemaSchedule.Contracts.Models.ScheduleViewer
{
	public class MovieWithSessionAm
	{
		public String Id { get; set; }
		public String Name { get; set; }
		public CleanSessionAm[] Sessions { get; set; }
	}
}