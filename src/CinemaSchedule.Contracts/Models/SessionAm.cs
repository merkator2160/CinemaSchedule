using System;

namespace CinemaSchedule.Contracts.Models
{
	public class SessionAm
	{
		public String Id { get; set; }
		public DateTime StartDate { get; set; }
		public String CinemaId { get; set; }
		public String MovieId { get; set; }
	}
}