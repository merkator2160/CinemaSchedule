using System;

namespace CinemaSchedule.Contracts.Models.ScheduleViewer
{
	public class CinemaWithMovieAm
	{
		public String Id { get; set; }
		public String Name { get; set; }
		public MovieWithSessionAm[] Movies { get; set; }
	}
}