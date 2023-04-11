﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IRequireHardCopyRepository<TContext> : IBaseRepository<RequireHardCopy, TContext> where TContext : IBaseContext
    {
    }
}
