using CinemaSchedule.Database.Interfaces;
using CinemaSchedule.Database.Models.Storage;
using MongoDB.Driver;

namespace CinemaSchedule.Database.Repositories
{
	public class SessionRepository : MongoRepositoryBase<SessionDb>, ISessionRepository
	{
		private readonly IMongoCollection<SessionDb> _collection;


		public SessionRepository(DataContext context) : base(context.Sessions)
		{
			_collection = context.Sessions;
		}


		// ISessionRepository /////////////////////////////////////////////////////////////////////
	}
}