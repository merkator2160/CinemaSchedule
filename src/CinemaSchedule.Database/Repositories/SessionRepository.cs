using CinemaSchedule.Database.Interfaces;
using CinemaSchedule.Database.Models.Storage;

namespace CinemaSchedule.Database.Repositories
{
	public class SessionRepository : MongoRepositoryBase<SessionDb>, ISessionRepository
	{
		private readonly DataContext _context;


		public SessionRepository(DataContext context) : base(context.Sessions)
		{
			_context = context;
		}


		// ISessionRepository /////////////////////////////////////////////////////////////////////
	}
}