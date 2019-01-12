using System;
using System.Threading.Tasks;

namespace CinemaSchedule.Database.Interfaces
{
	public interface IDatabaseManagementRepository
	{
		Task<String[]> GetAllCollectionsAsync();
		Task DropDatabaseAsync(String name);
		Task DropCollectionAsync(String name);
	}
}