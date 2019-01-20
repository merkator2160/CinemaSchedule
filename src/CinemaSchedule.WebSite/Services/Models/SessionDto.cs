﻿using System;

namespace CinemaSchedule.WebSite.Services.Models
{
	public class SessionDto
	{
		public String Id { get; set; }
		public DateTime StartDate { get; set; }
		public String CinemaId { get; set; }
		public String MovieId { get; set; }
	}
}