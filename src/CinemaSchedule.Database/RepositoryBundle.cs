using CinemaSchedule.Database.Interfaces;

namespace CinemaSchedule.Database
{
	public class RepositoryBundle : IRepositoryBundle
	{
		public RepositoryBundle(
			ICinemaRepository cinemaRepository,
			IDatabaseManagementRepository databaseManagementRepository)
		{
			Cinemas = cinemaRepository;
			Management = databaseManagementRepository;
		}


		// IUnitOfWork ////////////////////////////////////////////////////////////////////////////
		public ICinemaRepository Cinemas { get; }
		public IDatabaseManagementRepository Management { get; }
	}
}