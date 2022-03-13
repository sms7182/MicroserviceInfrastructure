using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FatalError.Communication.ApplicationService.Queries
{
    //public abstract class BaseQueryHandler<T, U> : IRequestHandler<T, U> where T : IRequest<U>, new() where U : ResponseDto, new()
    //{
    //    public async Task<U> Handle(T request, CancellationToken cancellationToken)
    //    {

    //        return await Handler(request, cancellationToken);
    //    }

    //    public abstract Task<U> Handler(T request, CancellationToken cancellationToken);
    //}

    //public abstract class BaseQueryHandler<T,U> : IRequestHandler<T, U> where T :MyResponse , new() where U : MyResponse, new()
    //{
    //    public async Task<U> Handle(T request, CancellationToken cancellationToken)
    //    {

    //        return await Handler(request, cancellationToken);
    //    }

    //    public abstract Task<U> Handler(T request, CancellationToken cancellationToken);
    //}
    //public class MyQueryHandle : BaseQueryHandler<MyRequest, MyResponse>
    //{
    //    public override async Task<MyResponse> Handler(MyRequest request, CancellationToken cancellationToken)
    //    {
           
    //        return new MyResponse();
    //    }
    //}
}
  
