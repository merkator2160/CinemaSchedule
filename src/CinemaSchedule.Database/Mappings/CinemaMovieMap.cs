using CinemaSchedule.Database.Models.Storage;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CinemaSchedule.Database.Mappings
{
	public class CinemaMovieMap : BsonClassMap<CinemaMovieDb>
	{
		public CinemaMovieMap()
		{
			AutoMap();
			MapIdMember(c => c.Id).SetIdGenerator(new ObjectIdGenerator());
			MapIdMember(c => c.CinemaId).SetIsRequired(true);
			MapIdMember(c => c.MovieId).SetIsRequired(true);
		}
	}
}