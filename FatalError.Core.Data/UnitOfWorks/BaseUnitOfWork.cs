using FatalError.Core.DataAccess.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.Data.UnitOfWorks
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {

        public DbContext context;
        public BaseUnitOfWork(DbContext _context, IServiceProvider serviceProvider)
        {
            context = _context;
        }

        public DbContext DbContext()
        {
            return context;
        }
    }
}
