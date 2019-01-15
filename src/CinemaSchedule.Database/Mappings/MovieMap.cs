using CinemaSchedule.Database.Models.Storage;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace CinemaSchedule.Database.Mappings
{
	public class MovieMap : BsonClassMap<MovieDb>
	{
		public MovieMap()
		{
			AutoMap();
			MapIdMember(c => c.Id).SetIdGenerator(new ObjectIdGenerator());
			MapMember(p => p.Name).SetIsRequired(true);
			MapMember(p => p.ReleaseDate).SetIgnoreIfNull(true);
			MapMember(p => p.Country).SetIgnoreIfNull(true);
			MapMember(p => p.Director).SetIgnoreIfNull(true);
			MapMember(p => p.Composer).SetIgnoreIfNull(true);
			MapMember(p => p.Producer).SetIgnoreIfNull(true);
			MapMember(p => p.Duration).SetIsRequired(true);
		}
	}
}