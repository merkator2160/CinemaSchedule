using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaSchedule.Contracts.Models
{
	public class GetSessionsRequestAm
	{
		[Required]
		public String CinemaId { get; set; }

		[Required]
		public String MovieId { get; set; }

		[Required]
		public DateTime Date { get; set; }
	}
}