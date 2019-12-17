using System;
using static Immo.Domain.Enums;

namespace Immo.Domain.BusinessDomain

{
    public class Property : Entity<Guid>
    {
        public PropertyTypeEnum? PropertyType { get; set; }

        public AddyTypeEnum AddType { get; set; }

        public int? ConstructionYear { get; set; }

        public int? BedroomsNo { get; set; }

        public int? FloorNo { get; set; }

        public int? BathroomNo { get; set; }

        public int? Garrages { get; set; }

        public int? ParkingPlaces { get; set; }

        public double? LivableSurface { get; set; }

        public double? GroundSurface { get; set; }

        public bool? HasTerrace { get; set; }

        public bool? HasGarden { get; set; }

        public double? Bedroom1Surface { get; set; }

        public double? Bedroom2Surface { get; set; }

        public double? Bedroom3Surface { get; set; }

        public double? Bedroom4Surface { get; set; }

        public double? Price { get; set; }

        public int? EPC { get; set; }

        public string Pictures { get; set; }

        public string Description { get; set; }

        public string OriginalURL { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Title { get; set; }
        #region Links

        public Guid? TownId { get; set; }

        public Town Town { get; set; }
        public PropertyWebsite PropertyWebsite { get; set; }

        #endregion
    }
}
