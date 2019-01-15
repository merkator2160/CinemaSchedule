namespace CinemaSchedule.Database.Interfaces
{
	public interface IRepositoryBundle
	{
		ICinemaRepository Cinemas { get; }
		IMovieRepository Movies { get; }
		ISessionRepository Sessions { get; }
		IDatabaseManagementRepository Management { get; }
	}
}