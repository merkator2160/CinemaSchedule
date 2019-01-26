using CinemaSchedule.Database.Models.Filters;
using CinemaSchedule.Database.Models.Storage;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.Database.Interfaces
{
	public interface ISessionRepository : IRepository<SessionDb>
	{
		Task<SessionDb[]> GetSessionsAsync(GetSessionsFilterDb filter);
		Task<SessionDb[]> GetSessionsAsync(ObjectId cinemaId, ObjectId movieId);
		Task<SessionDb[]> GetSessionsOlderThanAsync(DateTime to);
	}
}