using CinemaSchedule.Database.Models.Storage;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CinemaSchedule.Database.Mappings
{
	public class SessionMap : BsonClassMap<SessionDb>
	{
		public SessionMap()
		{
			AutoMap();
			MapIdMember(c => c.Id).SetIdGenerator(new ObjectIdGenerator());
			MapMember(p => p.StartDate).SetIsRequired(true);
			MapMember(p => p.CinemaId).SetIsRequired(true);
			MapMember(p => p.MovieId).SetIsRequired(true);
		}
	}
}