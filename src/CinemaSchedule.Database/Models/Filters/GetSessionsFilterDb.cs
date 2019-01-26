using MongoDB.Bson;
using System;

namespace CinemaSchedule.Database.Models.Filters
{
	public class GetSessionsFilterDb
	{
		public ObjectId CinemaId { get; set; }
		public ObjectId MovieId { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
	}
}