using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaSchedule.Database.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class
	{
		TEntity Get(String id);
		TEntity Get(ObjectId id);
		Task<TEntity> GetAsync(String id);
		Task<TEntity> GetAsync(ObjectId id);
		TEntity[] GetAll();
		Task<TEntity[]> GetAllAsync();
		TEntity[] GetChunked(Int32 offset, Int32 amount);
		Task<TEntity[]> GetChunkedAsync(Int32 offset, Int32 amount);
		Int64 GetQuantity();
		Task<Int64> GetQuantityAsync();
		void Add(TEntity item);
		Task AddAsync(TEntity item);
		void AddRange(IEnumerable<TEntity> items);
		Task AddRangeAsync(IEnumerable<TEntity> items);
		void Update(TEntity item);
		Task UpdateAsync(TEntity item);
		void Delete(String id);
		void Delete(ObjectId id);
		Task DeleteAsync(String id);
		Task DeleteAsync(ObjectId id);
		void Remove(TEntity item);
		Task RemoveAsync(TEntity item);
		void RemoveRange(IEnumerable<TEntity> items);
		Task RemoveRangeAsync(IEnumerable<TEntity> items);
	}
}