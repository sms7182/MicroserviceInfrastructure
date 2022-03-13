using FatalError.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Contracts.Dtos
{
    public class TRequestDto : RequestDto
    {
        public string UserName { get; set; }
    }
    public class TResponseDto : ResponseDto
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
