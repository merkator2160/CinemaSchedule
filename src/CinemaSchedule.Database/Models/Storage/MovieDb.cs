using CinemaSchedule.Database.Interfaces;
using MongoDB.Bson;
using System;

namespace CinemaSchedule.Database.Models.Storage
{
	public class MovieDb : IStorageEntity
	{
		public ObjectId Id { get; set; }
		public String Name { get; set; }
		public DateTime ReleaseDate { get; set; }
		public String Country { get; set; }
		public String Director { get; set; }
		public String Composer { get; set; }
		public String Producer { get; set; }
		public Int32 Duration { get; set; }
	}
}