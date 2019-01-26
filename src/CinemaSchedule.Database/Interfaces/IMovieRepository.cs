using CinemaSchedule.Database.Models.Storage;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.Database.Interfaces
{
	public interface IMovieRepository : IRepository<MovieDb>
	{
		Task<MovieDb[]> GetByCinemaId(String cinemaId);
		Task<MovieDb[]> GetByCinemaId(ObjectId cinemaId);
		Task<Boolean> CheckSessionExistenceAsync(ObjectId movieId);
	}
}