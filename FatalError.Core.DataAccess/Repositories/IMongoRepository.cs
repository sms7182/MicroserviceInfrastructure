using FatalError.Core.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FatalError.Core.DataAccess.Repositories
{
    public interface IMongoRepository<T> where T:Document
    {
        Guid Id { get; set; }
        IQueryable<T> AsQueryable();

        IQueryable<T> FilterBy(Expression<Func<T, bool>> filterExpression);
       
        T FindOne(Expression<Func<T, bool>> filterExpression);

        Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression);

        T FindById(string id);

        Task<T> FindByIdAsync(string id);

        void InsertOne(T document);

        Task InsertOneAsync(T document);

        void InsertMany(ICollection<T> documents);

        Task InsertManyAsync(ICollection<T> documents);

        ReplaceOneResult ReplaceOne(FilterDefinition<T> filterDefinition, T document);

        Task<ReplaceOneResult> ReplaceOneAsync(Expression<Func<T, bool>> filterExpression, T document);

        long DeleteOne(Expression<Func<T, bool>> filterExpression);

        Task<long> DeleteOneAsync(Expression<Func<T, bool>> filterExpression);

        long DeleteById(string id);

        Task<long> DeleteByIdAsync(string id);

        long DeleteMany(Expression<Func<T, bool>> filterExpression);

        Task<long> DeleteManyAsync(Expression<Func<T, bool>> filterExpression);
        Task<UpdateResult> UpdateManyAsync(Expression<Func<T, bool>> filterExpression, UpdateDefinition<T> updateDefinition, UpdateOptions updateOptions = null, CancellationToken cancelationToken = default);
        Task<UpdateResult> UpdateOneAsync(Expression<Func<T, bool>> filterExpression, UpdateDefinition<T> updateDefinition, UpdateOptions updateOptions = null, CancellationToken cancelationToken = default);


    }
}
