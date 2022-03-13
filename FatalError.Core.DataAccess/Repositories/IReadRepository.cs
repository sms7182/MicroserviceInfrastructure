using FatalError.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Core.DataAccess.Repositories
{
   
    public interface IReadRepository<T> where T:IEntity
    {
        Task<IQueryable<T>> GetAll();
        Task<IQueryable<T>> GetAllWithDeleted();
        Task<T> GetById(Guid id);

        Task<IQueryable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
