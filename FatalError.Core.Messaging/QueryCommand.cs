using FatalError.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FatalError.Core.Messaging
{
    public abstract class QueryCommand<T> : IRequest<ResponseDto> where T : RequestDto, new()
    {

    }

    public class QueryCommandHandler<T> : IRequestHandler<QueryCommand<T>, ResponseDto> where T : RequestDto, new()
    {
        public async Task<ResponseDto> Handle(QueryCommand<T> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
