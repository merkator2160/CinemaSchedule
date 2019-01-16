using CinemaSchedule.Database.Models.Storage;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.Database.Interfaces
{
	public interface IMovieRepository : IRepository<MovieDb>
	{
		Task<MovieDb[]> GetByCinemaId(String cinemaId);
	}
}