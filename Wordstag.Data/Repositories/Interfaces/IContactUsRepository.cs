using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Data.Contexts;
using Wordstag.Domain.Entities.ContactUs;
using Wordstag.Domain.Entities.User;

namespace Wordstag.Data.Repositories.Interfaces
{
    public interface IContactUsRepository<TContext> : IBaseRepository<ContactUs, TContext> where TContext : IBaseContext
    {
    }
}
