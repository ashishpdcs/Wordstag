using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Data.Contexts;
using Wordstag.Data.Repositories.Interfaces;
using Wordstag.Domain.Entities.ContactUs;
using Wordstag.Domain.Entities.User;

namespace Wordstag.Data.Repositories
{
    public class ContactUsRepository<TContext> : BaseRepository<ContactUs, TContext>, IContactUsRepository<TContext> where TContext : IBaseContext
    {
        public ContactUsRepository(TContext unit) : base(unit)
        {

        }
    }
}
