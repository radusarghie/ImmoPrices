using Immo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Domain.BusinessDomain
{
    public class Entity<IdType> : IEntity<IdType>
    {
        public IdType Id { get; set; }
      

        #region Links
        #endregion
    }
}
