﻿using System;

namespace CinemaSchedule.Contracts.Models.ScheduleViewer
{
	public class SessionWithCinemaAndMovieAm
	{
		public String Id { get; set; }
		public DateTime StartDate { get; set; }
		public CinemaAm Cinema { get; set; }
		public MovieAm Movie { get; set; }
	}
}