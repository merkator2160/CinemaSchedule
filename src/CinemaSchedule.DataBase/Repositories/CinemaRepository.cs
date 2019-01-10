using CinemaSchedule.Database.Interfaces;
using CinemaSchedule.Database.Models.Storage;
using MongoDB.Driver;

namespace CinemaSchedule.Database.Repositories
{
	public class CinemaRepository : MongoRepositoryBase<CinemaDb>, ICinemaRepository
	{
		private readonly IMongoCollection<CinemaDb> _collection;


		public CinemaRepository(DataContext context) : base(context.Cinemas)
		{
			_collection = context.Cinemas;
		}


		// ICinemaRepository ////////////////////////////////////////////////////////////////////////
	}
}