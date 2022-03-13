using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.Contracts
{
    public class RequestDto
    {
        public Guid Id { get; set; }
    }

    public class ResponseDto
    {
        public bool IsSuccess { get; set; }
        public IList Data { get; set; }
    }
}
