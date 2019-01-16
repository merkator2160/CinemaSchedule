using CinemaSchedule.Database.Interfaces;
using CinemaSchedule.Database.Models.Storage;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSchedule.Database.Repositories
{
	public class MovieRepository : MongoRepositoryBase<MovieDb>, IMovieRepository
	{
		private readonly DataContext _context;


		public MovieRepository(DataContext context) : base(context.Movies)
		{
			_context = context;
		}


		// IMovieRepository ///////////////////////////////////////////////////////////////////////
		public async Task<MovieDb[]> GetByCinemaId(String cinemaId)
		{
			var movieIds = await _context.Sessions
				.AsQueryable()
				.Where(p => p.CinemaId == new ObjectId(cinemaId))
				.Select(p => p.MovieId)
				.ToListAsync();

			return (await _context.Movies.AsQueryable().Where(p => movieIds.Contains(p.Id)).ToListAsync()).ToArray();
		}
	}
}