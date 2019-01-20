using System;

namespace CinemaSchedule.WebSite.Services.Models
{
	public class GetSessionsRequestDto
	{
		public String CinemaId { get; set; }
		public String MovieId { get; set; }
		public DateTime Date { get; set; }
	}
}