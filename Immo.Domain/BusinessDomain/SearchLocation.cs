using System;

namespace Immo.Domain.BusinessDomain
{
    public class SearchLocation : Entity<Guid>
    {
        public Guid SearchId { get; set; }

        public Guid TownId { get; set; }
    }
}
