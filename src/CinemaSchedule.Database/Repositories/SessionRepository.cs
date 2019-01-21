using CinemaSchedule.Database.Interfaces;
using CinemaSchedule.Database.Models.Filters;
using CinemaSchedule.Database.Models.Storage;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

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
		public Task<SessionDb[]> GetSessionsAsync(GetSessionsFilterDb filter)
		{
			return Task.Run(() =>
			{
				return _context.Sessions
					.AsQueryable()
					.Where(p => p.CinemaId == filter.CinemaId &&
								p.MovieId == filter.MovieId &&
								filter.Date >= p.StartDate)
					.ToArray();
			});     // Maybe there is more elegant solution. I will be looking for it.
		}
		public Task<SessionDb[]> GetSessionsOlderThanAsync(DateTime to)
		{
			return Task.Run(() =>
			{
				return _context.Sessions
					.AsQueryable()
					.Where(p => to > p.StartDate)
					.ToArray();
			});
		}
	}
}