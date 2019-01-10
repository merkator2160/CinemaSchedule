using CinemaSchedule.Database.Interfaces;
using MongoDB.Driver;
using System;
using System.Linq;

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
		public String[] GetAllCollections()
		{
			using(var collections = _context.Database.ListCollections())
			{
				var collectionList = collections.ToList();
				return collectionList.Select(x => x["name"].ToString()).ToArray();
			}
		}
	}
}