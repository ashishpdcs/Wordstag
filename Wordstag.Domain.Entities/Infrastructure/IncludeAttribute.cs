using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordstag.Domain.Entities.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class |
                     AttributeTargets.Struct
      | AttributeTargets.Field | AttributeTargets.Property)]
    public class IncludeAttribute :Attribute
    {
        public IncludeAttribute()
        {
        }

    }
}
