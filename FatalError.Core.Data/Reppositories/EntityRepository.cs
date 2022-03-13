using FatalError.Core.DataAccess.Repositories;
using FatalError.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Core.Data.Reppositories
{
    public abstract class ReadRepository<T>:IReadRepository<T> where T :Entity,IEntity
    {
        DbContext dbContext;
        public ReadRepository(DbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            var entities = await Task.Run(() => dbContext.Set<T>().AsNoTracking().Where(d => !d.IsDeleted).Where(predicate));
            return entities;
        }

        public async Task<IQueryable<T>> GetAllWithDeleted()
        {
            var queryable = await Find(d => d.IsDeleted || !d.IsDeleted);
            return queryable;
        }
        public async Task<IQueryable<T>> GetAll()
        {
            var queryable = await Find(d => !d.IsDeleted);
            return queryable;
        }

        public async Task<T> GetById(Guid id)
        {
            return await dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(d => !d.IsDeleted && d.Id == id);
        }



    }
    public abstract class EntityRepository<T> :ReadRepository<T>, IGenericRepository<T> where T : AggregateEntity,IEntity
    {
        DbContext dbContext;
        public EntityRepository(DbContext _dbContext):base(_dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<bool> Add(T entity)
        {
            var saved = await dbContext.AddAsync(entity);
            return saved != null;
        }

        public async Task<bool> Delete(Guid id)
        {
          var entity=  await GetById(id);
            if (entity != null && !entity.IsDeleted)
            { 
                entity.IsDeleted = true;
                return true;
            }
            return false;
        }
        

             


        public async Task<bool> Update(T entity)
        {
           var updatedentity= dbContext.Set<T>().Update(entity);
            return updatedentity != null;
        }
    }

}
