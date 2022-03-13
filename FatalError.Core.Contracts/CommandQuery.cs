using FatalError.Core.Contracts;
using MediatR;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace FatalError.Core.Contracts
{

    public abstract class CommandQuery<T, U> : IRequest<U> where T : RequestDto where U : ResponseDto
    {
        public Guid Id { get; set; }
        public T RequestDto { get; set; }
    }



}
