using CinemaSchedule.Database.Models.Storage;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CinemaSchedule.Database.Mappings
{
	public class CinemaMap : BsonClassMap<CinemaDb>
	{
		public CinemaMap()
		{
			AutoMap();
			MapIdMember(c => c.Id).SetIdGenerator(new ObjectIdGenerator());
			MapMember(p => p.Name).SetIgnoreIfNull(true);
			MapMember(p => p.City).SetIgnoreIfNull(true);
			MapMember(p => p.Country).SetIgnoreIfNull(true);
		}
	}
}