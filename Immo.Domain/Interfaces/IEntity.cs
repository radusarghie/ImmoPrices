using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Domain.Interfaces
{
    public interface IEntity<IdType>
    {
        public IdType Id { get; set; }

    }
}
