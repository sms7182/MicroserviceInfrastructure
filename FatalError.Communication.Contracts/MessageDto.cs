using FatalError.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Contracts
{
    public class MessageRequestDto:RequestDto
    {
        public Guid MyProperty { get; set; }
    }

    public class MessageResponseDto : ResponseDto
    {

    }

 
}
