
using FatalError.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Core.DataAccess.Repositories
{
    public interface IGenericRepository<T>:IReadRepository<T> where T:AggregateEntity,IEntity
    {
        Task<bool> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Update(T entity);
      
    }
}
