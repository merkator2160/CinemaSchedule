using System;

namespace CinemaSchedule.WebSite.Services.Models
{
	public class SessionDto
	{
		public Int32 Id { get; set; }
		public DateTime BeginDate { get; set; }
		public FilmDto Film { get; set; }
	}
}