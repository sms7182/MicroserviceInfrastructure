using DotNetCore.CAP;
using FatalError.Communication.ApplicationService.Queries;
using FatalError.Communication.Contracts;
using FatalError.Communication.Contracts.CacheProvider;
using FatalError.Communication.Contracts.Dtos;
using FatalError.Communication.Contracts.Queries;
using FatalError.Communication.Domain;
using FatalError.Communication.Domain.Messages;
using FatalError.Core.DataAccess.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatalError.Communication.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MessageController:ControllerBase
    {
        ICacheProvider cacheProvider;
        ICapPublisher capPublisher;
        IMediator mediator;
        public MessageController(ICacheProvider _cacheProvider,IMessageMongoRepository messageRepository,ICapPublisher _capPublisher,IMediator _mediatr)
        {
            cacheProvider = _cacheProvider;
            capPublisher = _capPublisher;
            mediator = _mediatr;
        }


        [HttpPost("getMessages")]
        public async Task<ActionResult<TResponseDto>> GetMessages([FromBody]TRequestDto dto)
        {
         var response=  await mediator.Send(new GetMessagesQuery()
            {
               RequestDto=dto
            });
            return Ok(response);
        }


        [HttpPost("getMessage")]
        public async Task<ActionResult<TResponseDto>> GetMessage([FromBody] TRequestDto dto)
        {
            var response = await mediator.Send(new GetMessageQuery()
            {
             RequestDto=dto,
            });
            return Ok(response);
        }
    }

    public class LogicBody
    {
        public string UserName { get; set; }
    }
}
