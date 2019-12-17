using Immo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Domain.BusinessDomain
{
    public class Entity<IdType> : IEntity<IdType>, ISupportsHistory
    {
        public IdType Id { get; set; }
      
        public DateTime CreationDate { get; set; }


        #region Links
        #endregion
    }
}
