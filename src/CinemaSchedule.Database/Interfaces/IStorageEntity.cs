using MongoDB.Bson;

namespace CinemaSchedule.Database.Interfaces
{
	public interface IStorageEntity
	{
		ObjectId Id { get; set; }
	}
}