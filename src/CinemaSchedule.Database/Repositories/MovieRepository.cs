using CinemaSchedule.Database.Interfaces;
using CinemaSchedule.Database.Models.Storage;
using MongoDB.Driver;

namespace CinemaSchedule.Database.Repositories
{
	public class MovieRepository : MongoRepositoryBase<MovieDb>, IMovieRepository
	{
		private readonly IMongoCollection<MovieDb> _collection;


		public MovieRepository(IMongoCollection<MovieDb> collection) : base(collection)
		{
			_collection = collection;
		}


		// IMovieRepository ///////////////////////////////////////////////////////////////////////
	}
}