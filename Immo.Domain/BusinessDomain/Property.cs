using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Immo.Domain.Enums;

namespace Immo.Domain.BusinessDomain

{
    public class Property : Entity<Guid>
    {
        public PropertyTypeEnum? PropertyType { get; set; }

        public AddyTypeEnum AddType { get; set; }

        public int? ConstructionYear { get; set; }

        public int? BedroomsNo { get; set; }

        public int? BathroomNo { get; set; }

        public double? Surface { get; set; }

        public double? Price { get; set; }

        public string Pictures { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string OriginalURL { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        #region Links

        public Guid TownId { get; set; }

        public Guid PropertyWebsiteId { get; set; }

        public Guid SearchId { get; set; }


        #endregion
    }
}
