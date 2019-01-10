using CinemaSchedule.Database.Interfaces;
using MongoDB.Bson;
using System;

namespace CinemaSchedule.Database.Models.Storage
{
	public class CinemaDb : IStorageEntity
	{
		public ObjectId Id { get; set; }
		public String Name { get; set; }
		public String City { get; set; }
		public String Country { get; set; }
	}
}