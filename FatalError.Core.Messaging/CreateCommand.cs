using FatalError.Core.Contracts;
using MediatR;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace FatalError.Core.Messaging
{
   
    public abstract class CreateCommand<T> :IRequest<ResponseDto> where T : RequestDto, new()
    {

    }

    public class CreateCommandHandler<T> : IRequestHandler<CreateCommand<T>, ResponseDto> where T : RequestDto,new()
    {
        public Task<ResponseDto> Handle(CreateCommand<T> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
