using FatalError.Communication.Contracts;
using FatalError.Communication.Contracts.Dtos;
using FatalError.Communication.Contracts.Queries;
using FatalError.Communication.Domain;
using FatalError.Communication.Domain.Messages.ReadModel;
using FatalError.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FatalError.Communication.ApplicationService.Queries
{
    public class GetMessageQueryHandler: CommandQueryHandler<GetMessageQuery, TRequestDto, TResponseDto>
    {
        ICommunicationReadUnitOfWork communicationReadUnitOfWork;
        public GetMessageQueryHandler( ICommunicationReadUnitOfWork readUnitOfWork)
        {
           
            communicationReadUnitOfWork = readUnitOfWork;
        }
        public override async Task<TResponseDto> Handler(GetMessageQuery req, CancellationToken ct)
        {
             var message=await communicationReadUnitOfWork.MessageRepository.GetById(req.RequestDto.Id);
            
            return new TResponseDto() { Data = new List<MessageViewModel>() { message}, IsSuccess = true };
        }
    }
}
