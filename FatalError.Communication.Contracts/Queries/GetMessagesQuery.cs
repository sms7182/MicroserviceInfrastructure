using FatalError.Communication.Contracts.Dtos;
using FatalError.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Communication.Contracts.Queries
{
    public class GetMessagesQuery: CommandQuery<TRequestDto, TResponseDto>
    {
    }
}
