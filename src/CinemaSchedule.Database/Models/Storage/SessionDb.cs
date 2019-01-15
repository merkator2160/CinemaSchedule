using CinemaSchedule.Database.Interfaces;
using MongoDB.Bson;
using System;

namespace CinemaSchedule.Database.Models.Storage
{
	public class SessionDb : IStorageEntity
	{
		public ObjectId Id { get; set; }
		public DateTime StartDate { get; set; }
		public ObjectId CinemaId { get; set; }
		public ObjectId MovieId { get; set; }
	}
}