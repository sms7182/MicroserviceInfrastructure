using FatalError.Core.Data.Configuration;
using FatalError.Core.DataAccess.Mongo;
using FatalError.Core.DataAccess.Repositories;
using FatalError.Core.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FatalError.Core.Data.MongoDataInfrastructure
{
    public class MongoRepository<T> : IMongoRepository<T> where T : Document
    {
        private readonly IMongoCollection<T> _collection;

        public Guid Id { get; set ; }

        public MongoRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
        }
        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollection)documentType.GetCustomAttributes(
                    typeof(BsonCollection),
                    true)
                .FirstOrDefault())?.CollectionName;
        }
        public IQueryable<T> AsQueryable()
        {
            return _collection.AsQueryable<T>();
        }

        public long DeleteById(string id)
        {
            if (!string.IsNullOrWhiteSpace(id) && Guid.TryParse(id, out Guid boId))
            {
                var deleteResult = _collection.DeleteOne(d => d.Id == boId);
                return deleteResult.DeletedCount;
            }
            return 0;
        }

        public async Task<long> DeleteByIdAsync(string id)
        {
            if (!string.IsNullOrWhiteSpace(id) && Guid.TryParse(id, out Guid boId))
            {
                var deleteResult = await _collection.DeleteOneAsync(d => d.Id == boId);
                return deleteResult.DeletedCount;
            }
            return 0;
        }

        public long DeleteMany(Expression<Func<T, bool>> filterExpression)
        {
            var deleteResults = _collection.DeleteMany<T>(filterExpression);
            return deleteResults.DeletedCount;
        }

        public async Task<long> DeleteManyAsync(Expression<Func<T, bool>> filterExpression)
        {
            var deleteResult = await _collection.DeleteManyAsync<T>(filterExpression);
            return deleteResult.DeletedCount;
        }

        public long DeleteOne(Expression<Func<T, bool>> filterExpression)
        {
            var deleteResult = _collection.DeleteOne<T>(filterExpression);
            return deleteResult.DeletedCount;

        }

        public async Task<long> DeleteOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            var deleteResult = await _collection.DeleteOneAsync<T>(filterExpression);
            return deleteResult.DeletedCount;
        }

        public IQueryable<T> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            return _collection.AsQueryable<T>().Where(filterExpression);
        }



        public T FindById(string id)
        {
            if (Guid.TryParse(id, out var boId))
            {
                return _collection.AsQueryable<T>().Where(d=>d.Id==boId).FirstOrDefault();
            }
            return null;
        }
    

        public async Task<T> FindByIdAsync(string id)
        {
            if (Guid.TryParse(id, out var boId))
            {
              return await Task.Run(()=> _collection.AsQueryable<T>().Where(d => d.Id == boId).FirstOrDefault());
            }
            return null;
        }

        public T FindOne(Expression<Func<T, bool>> filterExpression)
        {
            return _collection.AsQueryable<T>().Where(filterExpression).FirstOrDefault();
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            return await Task.Run(() => _collection.AsQueryable<T>().Where(filterExpression).FirstOrDefault());
        }

        public void InsertMany(ICollection<T> documents)
        {
            _collection.InsertMany(documents);
        }

        public async Task InsertManyAsync(ICollection<T> documents)
        {
           await _collection.InsertManyAsync(documents);
        }

        public void InsertOne(T document)
        {
            _collection.InsertOne(document);
        }

        public async Task InsertOneAsync(T document)
        {
           await Task.Run(() => _collection.InsertOneAsync(document));
        }

        public ReplaceOneResult ReplaceOne(FilterDefinition<T> filterDefinition,T document)
        {
            return _collection.ReplaceOne(filterDefinition, document);
        }

        public async Task<ReplaceOneResult> ReplaceOneAsync(Expression<Func<T, bool>> filterExpression,T document)
        {
           return await _collection.ReplaceOneAsync<T>(filterExpression, document);
        }

        public async Task<UpdateResult> UpdateManyAsync(Expression<Func<T, bool>> filterExpression, UpdateDefinition<T> updateDefinition, UpdateOptions updateOptions = null, CancellationToken cancelationToken = default)
        {

            return await _collection.UpdateManyAsync<T>(filterExpression, updateDefinition,updateOptions,cancelationToken);
        }

        public async Task<UpdateResult> UpdateOneAsync(Expression<Func<T, bool>> filterExpression, UpdateDefinition<T> updateDefinition,UpdateOptions updateOptions=null,CancellationToken cancelationToken=default)
        {

            return await _collection.UpdateOneAsync<T>(filterExpression, updateDefinition,updateOptions,cancelationToken);
        }


    }
}
