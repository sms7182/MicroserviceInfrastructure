using DotNetCore.CAP;
using FatalError.Core.Contracts;
using FatalError.Core.DataAccess.IUnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FatalError.Core.Data.UnitOfWorks
{
    public class BaseWriteUnitOfWork:BaseUnitOfWork,IBaseWriteUnitOfWork, IDisposable
    {
        private bool disposed = false;
        protected List<Event> events;
        private ICapPublisher capPublisher;
        public BaseWriteUnitOfWork(DbContext dbContext,IServiceProvider serviceProvider):base(dbContext,serviceProvider)
        {
           capPublisher= (ICapPublisher) serviceProvider.GetService(typeof(ICapPublisher));
            
            events = new List<Event>();
        }

       
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task CommitAsync()
        {

            using(var transaction = context.Database.BeginTransaction())
            {
                try
                {
                   await context.SaveChangesAsync();
                   
                    await transaction.CommitAsync();
                }
                catch(Exception e)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            foreach (var eventForPublish in events)
            {
                capPublisher.Publish<Event>((eventForPublish).GetType().Name, eventForPublish);
            }



        }

        public async Task Rollback()
        {
          await  context.Database.RollbackTransactionAsync();
        }

        public void AddEvent(Event @event)
        {
            events.Add(@event);
        }
    }
}
