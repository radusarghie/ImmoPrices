using System;

namespace Immo.Domain.BusinessDomain
{
    public class SearchLocation : Entity<Guid>
    {

        #region references
        public Guid SearchId { get; set; }

        public Guid TownId { get; set; }

        public Town Town { get; set; }

        public Search Search { get; set; }
        #endregion
    }
}
