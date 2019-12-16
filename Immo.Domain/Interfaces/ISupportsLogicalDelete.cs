using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Domain.Interfaces
{
    public interface ISupportsLogicalDelete
    {
        public bool IsDeleted { get; set; }

    }
}
