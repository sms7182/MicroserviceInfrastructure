using FatalError.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Core.DataAccess.IUnitOfWorks
{
    public interface IBaseWriteUnitOfWork:IBaseUnitOfWork
    {
        Task CommitAsync();
      

        Task Rollback();
        void AddEvent(Event @event);
       
    }
}
