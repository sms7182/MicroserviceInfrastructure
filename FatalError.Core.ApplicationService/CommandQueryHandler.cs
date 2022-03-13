using FatalError.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FatalError.Core.ApplicationService
{



    public abstract class CommandQueryHandler<H, T, U> : IRequestHandler<H, U> where H : CommandQuery<T, U>, new() where T : RequestDto where U : ResponseDto
    {
        public async Task<U> Handle(H request, CancellationToken cancellationToken)
        {
            return await Handler(request, cancellationToken);
        }

        public abstract Task<U> Handler(H req, CancellationToken ct);

    }
}
