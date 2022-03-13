using DotNetCore.CAP;
using FatalError.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FatalError.Core.CAP
{
    public interface ICapService
    {
        void Publish<T>(string name, T contentObj, string callbackName = null) where T : Event;
    }
    public class CapService : ICapService
    {
        IServiceProvider serviceProvider;
        AsyncLocal<ICapTransaction> capTransaction;
        public CapService(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
           capTransaction= (AsyncLocal<ICapTransaction>)serviceProvider.GetService(typeof(AsyncLocal<ICapTransaction>));
        }
        public IServiceProvider ServiceProvider => serviceProvider;

        public AsyncLocal<ICapTransaction> Transaction => capTransaction;

        public void Publish<T>(string name, T contentObj, string callbackName = null) where T:Event
        {
            
            throw new NotImplementedException();
        }

        public void Publish<T>(string name, T contentObj, IDictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync<T>(string name, T contentObj, string callbackName = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync<T>(string name, T contentObj, IDictionary<string, string> headers, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
