using CinemaSchedule.Database.Interfaces;
using CinemaSchedule.Database.Models.Storage;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.Database.Repositories
{
	public class CinemaRepository : MongoRepositoryBase<CinemaDb>, ICinemaRepository
	{
		private readonly DataContext _context;


		public CinemaRepository(DataContext context) : base(context.Cinemas)
		{
			_context = context;
		}


		// ICinemaRepository ////////////////////////////////////////////////////////////////////////
		public Task<Boolean> CheckSessionExistenceAsync(ObjectId cinemaId)
		{
			return _context.Sessions.AsQueryable().AnyAsync(p => p.CinemaId == cinemaId);
		}
	}
}