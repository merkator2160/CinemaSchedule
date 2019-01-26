using System;

namespace CinemaSchedule.WebSite.Services.Models.ScheduleViewer
{
	public class SessionWithCinemaAndMovieDto
	{
		public String Id { get; set; }
		public DateTime StartDate { get; set; }
		public CinemaDto Cinema { get; set; }
		public MovieDto Movie { get; set; }
	}
}