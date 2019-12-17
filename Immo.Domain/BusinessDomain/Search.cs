using System;
using System.Collections.Generic;
using static Immo.Domain.Enums;

namespace Immo.Domain.BusinessDomain
{
    public class Search : Entity<Guid>
    {
        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public int? MinRoomsNo { get; set; }

        public int? MaxRoomsNo { get; set; }

        public PropertyTypeEnum? PropertyType { get; set; }

        #region links
        public List<SearchLocation> SeachLocations { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
        #endregion
    }
}
