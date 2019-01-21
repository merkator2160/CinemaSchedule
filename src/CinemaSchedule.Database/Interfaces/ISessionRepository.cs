using CinemaSchedule.Database.Models.Filters;
using CinemaSchedule.Database.Models.Storage;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.Database.Interfaces
{
	public interface ISessionRepository : IRepository<SessionDb>
	{
		Task<SessionDb[]> GetSessionsAsync(GetSessionsFilterDb filter);
		Task<SessionDb[]> GetSessionsOlderThanAsync(DateTime to);
	}
}