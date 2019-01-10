namespace CinemaSchedule.Database.Interfaces
{
	public interface IRepositoryBundle
	{
		ICinemaRepository Cinemas { get; }
		IDatabaseManagementRepository Management { get; }
	}
}