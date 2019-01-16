using CinemaSchedule.Database.Interfaces;
using CinemaSchedule.Database.Models.Storage;

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
	}
}