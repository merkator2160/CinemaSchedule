using CinemaSchedule.Database.Interfaces;
using MongoDB.Bson;

namespace CinemaSchedule.Database.Models.Storage
{
	public class CinemaMovieDb : IStorageEntity
	{
		public ObjectId Id { get; set; }
		public ObjectId CinemaId { get; set; }
		public ObjectId MovieId { get; set; }
	}
}