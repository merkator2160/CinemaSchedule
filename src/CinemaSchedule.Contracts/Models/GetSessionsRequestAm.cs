using System;

namespace CinemaSchedule.Contracts.Models
{
	public class GetSessionsRequestAm
	{
		public String CinemaId { get; set; }
		public String MovieId { get; set; }
		public DateTime Date { get; set; }
	}
}