using FatalError.Communication.Contracts;
using FatalError.Communication.Contracts.Dtos;
using FatalError.Communication.Contracts.Queries;
using FatalError.Communication.Domain;
using FatalError.Core.ApplicationService;
using FatalError.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FatalError.Communication.ApplicationService.Queries
{
    public class GetMessagesQueryHandler : CommandQueryHandler<GetMessagesQuery, TRequestDto, TResponseDto>
    {

        IMessageMongoRepository messageMongoRepository;
        
        public GetMessagesQueryHandler(IMessageMongoRepository _messageMongoRepository)
        {
            messageMongoRepository = _messageMongoRepository;
        }
        public override async Task<TResponseDto> Handler(GetMessagesQuery req, CancellationToken ct)
        {
           
            var userName = req.RequestDto.UserName;
            var messages = messageMongoRepository.AsQueryable()
                 .Where(d => d.Sender == userName || d.Receiver == userName).OrderBy(d => d.CreationDate)
                 .Select(it => new TResponseDto() { Sender = it.Sender, Message = it.MessageContent, Receiver = it.Receiver, IsSuccess = true, Id = it.Id })
                 .ToList();

            return new TResponseDto() { Data = messages.ToList(),IsSuccess=true ,Id=messageMongoRepository.Id};
        }
    }


}
  
