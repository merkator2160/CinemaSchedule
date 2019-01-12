using CinemaSchedule.Database.Interfaces;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.Database.Repositories
{
	public class DatabaseManagementRepository : IDatabaseManagementRepository
	{
		private readonly DataContext _context;


		public DatabaseManagementRepository(DataContext context)
		{
			_context = context;
		}


		// IDatabaseManagementRepository //////////////////////////////////////////////////////////
		public async Task<String[]> GetAllCollectionsAsync()
		{
			using(var cursor = await _context.Database.ListCollectionNamesAsync())
			{
				return (await cursor.ToListAsync()).ToArray();
			}
		}
		public Task DropDatabaseAsync(String name)
		{
			return _context.Client.DropDatabaseAsync(name);
		}
		public Task DropCollectionAsync(String name)
		{
			return _context.Database.DropCollectionAsync(name);
		}
	}
}