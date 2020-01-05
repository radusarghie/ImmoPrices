using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Immo.Domain.Enums;

namespace Immo.Domain.BusinessDomain
{
    public class Search : Entity<Guid>
    {
        public string Name { get; set; }
        public AddyTypeEnum AddType { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinRoomsNo { get; set; }
        public int? MaxRoomsNo { get; set; }
        public int? MinConstructionYear { get; set; }
        public int? MaxConstructionYear { get; set; }
        public int? MinSurface { get; set; }
        public int? MaxSurface { get; set; }
        public string CustomFields { get; set; }
        public PropertyTypeEnum? PropertyType { get; set; }
        #region links

        public Guid UserId { get; set; }

        public Guid TownId { get; set; }

        #endregion
    }
}
