using System;
using System.Collections.Generic;

namespace Immo.Domain.BusinessDomain
{
    public class Search : Entity<Guid>
    {
        public Guid UserId { get; set; }

        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }

        public int MinRoomsNo { get; set; }

        public int MaxRoomsNo { get; set; }

        #region links
        public IList<Guid> SeachLocatioIds { get; set; }

        public IList<SearchLocation> SeachLocations { get; set; }
        #endregion
    }
}
