using DotNetCore.CAP;
using FatalError.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.ApplicationService
{
    public abstract class BaseEventHandler<T>:ICapSubscribe where T:Event
    {
    }
}
