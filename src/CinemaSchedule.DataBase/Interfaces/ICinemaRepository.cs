using CinemaSchedule.Database.Models.Storage;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace CinemaSchedule.Database.Interfaces
{
	public interface ICinemaRepository : IRepository<CinemaDb>
	{
		Task<Boolean> CheckSessionExistenceAsync(ObjectId cinemaId);
	}
}