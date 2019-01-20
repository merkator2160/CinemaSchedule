using System;

namespace CinemaSchedule.WebSite.Services.Models
{
	public class MovieDto
	{
		public String Id { get; set; }
		public String Name { get; set; }
		public DateTime ReleaseDate { get; set; }
		public String Country { get; set; }
		public String Director { get; set; }
		public String Composer { get; set; }
		public String Producer { get; set; }
		public Int32 Duration { get; set; }
	}
}