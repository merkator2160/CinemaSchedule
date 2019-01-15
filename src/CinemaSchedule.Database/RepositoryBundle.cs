using CinemaSchedule.Database.Interfaces;

namespace CinemaSchedule.Database
{
	public class RepositoryBundle : IRepositoryBundle
	{
		public RepositoryBundle(
			ICinemaRepository cinemaRepository,
			IMovieRepository movies,
			ISessionRepository sessionRepository,
			IDatabaseManagementRepository databaseManagementRepository)
		{
			Cinemas = cinemaRepository;
			Movies = movies;
			Sessions = sessionRepository;
			Management = databaseManagementRepository;
		}


		// IUnitOfWork ////////////////////////////////////////////////////////////////////////////
		public ICinemaRepository Cinemas { get; }
		public IMovieRepository Movies { get; }
		public ISessionRepository Sessions { get; }
		public IDatabaseManagementRepository Management { get; }
	}
}