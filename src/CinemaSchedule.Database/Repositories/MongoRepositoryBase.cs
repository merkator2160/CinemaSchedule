using CinemaSchedule.Database.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSchedule.Database.Repositories
{
	public class MongoRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IStorageEntity
	{
		private readonly IMongoCollection<TEntity> _collection;


		public MongoRepositoryBase(IMongoCollection<TEntity> collection)
		{
			_collection = collection;
		}


		// IRepository ////////////////////////////////////////////////////////////////////////////
		// IRepository ////////////////////////////////////////////////////////////////////////////
		public TEntity Get(String id)
		{
			return Get(new ObjectId(id));
		}
		public TEntity Get(ObjectId id)
		{
			return _collection.Find(p => p.Id.Equals(id)).FirstOrDefault();
		}
		public async Task<TEntity> GetAsync(String id)
		{
			return await GetAsync(new ObjectId(id));
		}
		public async Task<TEntity> GetAsync(ObjectId id)
		{
			return await _collection.Find(p => p.Id.Equals(id)).FirstOrDefaultAsync();
		}
		public TEntity[] GetAll()
		{
			return _collection.Find(FilterDefinition<TEntity>.Empty).ToList().ToArray();
		}
		public async Task<TEntity[]> GetAllAsync()
		{
			return (await _collection.Find(FilterDefinition<TEntity>.Empty).ToListAsync()).ToArray();
		}
		public TEntity[] GetChunked(Int32 offset, Int32 amount)
		{
			return _collection.Find(FilterDefinition<TEntity>.Empty).Skip(offset).Limit(amount).ToList().ToArray();
		}
		public async Task<TEntity[]> GetChunkedAsync(Int32 offset, Int32 amount)
		{
			return (await _collection.Find(FilterDefinition<TEntity>.Empty).Skip(offset).Limit(amount).ToListAsync()).ToArray();
		}
		public Int64 GetQuantity()
		{
			return _collection.CountDocuments(FilterDefinition<TEntity>.Empty);
		}
		public async Task<Int64> GetQuantityAsync()
		{
			return await _collection.CountDocumentsAsync(FilterDefinition<TEntity>.Empty);
		}
		public void Add(TEntity item)
		{
			_collection.InsertOne(item);
		}
		public async Task AddAsync(TEntity item)
		{
			await _collection.InsertOneAsync(item);
		}
		public void AddRange(IEnumerable<TEntity> items)
		{
			_collection.InsertMany(items);
		}
		public async Task AddRangeAsync(IEnumerable<TEntity> items)
		{
			await _collection.InsertManyAsync(items);
		}
		public void Update(TEntity item)
		{
			_collection.ReplaceOne(p => p.Id.Equals(item.Id), item);
		}
		public async Task UpdateAsync(TEntity item)
		{
			await _collection.ReplaceOneAsync(p => p.Id.Equals(item.Id), item);
		}
		public void Delete(String id)
		{
			Delete(new ObjectId(id));
		}
		public void Delete(ObjectId id)
		{
			_collection.DeleteOne(p => p.Id.Equals(id));
		}
		public async Task DeleteAsync(String id)
		{
			await DeleteAsync(new ObjectId(id));
		}
		public async Task DeleteAsync(ObjectId id)
		{
			await _collection.DeleteOneAsync(p => p.Id.Equals(id));
		}
		public void Remove(TEntity item)
		{
			_collection.DeleteOne(p => p.Id.Equals(item.Id));
		}
		public async Task RemoveAsync(TEntity item)
		{
			await _collection.DeleteOneAsync(p => p.Id.Equals(item.Id));
		}
		public void RemoveRange(IEnumerable<TEntity> items)
		{
			var ids = items.Select(p => p.Id).ToArray();
			_collection.DeleteMany(p => ids.Contains(p.Id));
		}
		public async Task RemoveRangeAsync(IEnumerable<TEntity> items)
		{
			var ids = items.Select(p => p.Id).ToArray();
			await _collection.DeleteManyAsync(p => ids.Contains(p.Id));
		}
	}
}