using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Services.Entities.ContactUs;

namespace Wordstag.Services.Interfaces
{
    public interface IContactUsService
    {
        Task<Guid> SaveContactUs(SaveContactUsDto request);
    }
}
