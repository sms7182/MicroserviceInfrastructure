using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.DataAccess.IUnitOfWorks
{
    public interface IBaseUnitOfWork
    {
        DbContext DbContext();
    }
}
