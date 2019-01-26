using System;

namespace CinemaSchedule.WebSite.Services.Models.ScheduleViewer
{
	public class CinemaWithMovieDto
	{
		public String Id { get; set; }
		public String Name { get; set; }
		public String City { get; set; }
		public String Country { get; set; }
		public MovieWithSessionDto[] Movies { get; set; }
	}
}