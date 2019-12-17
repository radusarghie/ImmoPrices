using Immo.Domain.BusinessDomain;
using System;
using System.Collections.Generic;

namespace Immo.Logic.SeedData
{
    public static class SeedValues
    {
        private static SequentialGuid SequentialGuid { get; set; } = new SequentialGuid();

        public static class Users
        {
            public static User Radu { get; } = new User
            {
                Id = SequentialGuid++.CurrentGuid,
                UserName = "rsarghie",
                CreationDate = DateTime.UtcNow
            };
        }

        public static class Countries
        {
            public static Country Belgium = new Country
            {
                Id = SequentialGuid++.CurrentGuid,
                Name = "Belgium",
                CreationDate = DateTime.UtcNow
            };

            public static Country Romania = new Country
            {
                Id = SequentialGuid++.CurrentGuid,
                Name = "Romania",
                CreationDate = DateTime.UtcNow
            };

        }

        public static class Provinces
        {
            public static Province FlemishBrabant = new Province
            {
                Id = SequentialGuid++.CurrentGuid,
                Name = "Flemish Brabant",
                CountryId = Countries.Belgium.Id,
                CreationDate = DateTime.UtcNow
            };

            public static Province Iasi = new Province
            {
                Id = SequentialGuid++.CurrentGuid,
                Name = "Iasi",
                CountryId = Countries.Romania.Id,
                CreationDate = DateTime.UtcNow
            };
        }


        public static class Towns
        {
            public static Town Wemmel = new Town
            {
                Id = SequentialGuid++.CurrentGuid,
                Name = "Wemmel",
                PostCode = "1780",
                ProvinceId = Provinces.FlemishBrabant.Id,
                CreationDate = DateTime.UtcNow
            };

            public static Town Iasi = new Town
            {
                Id = SequentialGuid++.CurrentGuid,
                Name = "Iasi",
                PostCode = "700303",
                ProvinceId = Provinces.Iasi.Id,
                CreationDate = DateTime.UtcNow
            };
        }

        public static class PropertyWebsites
        {
            public static PropertyWebsite Structura = new PropertyWebsite
            {
                Id = SequentialGuid++.CurrentGuid,
                Name = "Structura",
                WebsitePropertyUrl = @"http://www.structura.be",
                WebsiteRootUrl = @"http://www.structura.be/",
                CreationDate = DateTime.UtcNow
            };
        }

        public static class Searches
        {
            public static Search DefaultWemmelApartments = new Search
            {
                Id = SequentialGuid++.CurrentGuid,
                User = Users.Radu,
                MinPrice = 200000,
                MaxPrice = 400000,
                MinRoomsNo = 2,
                CreationDate = DateTime.UtcNow,
                AddyType = Domain.Enums.AddyTypeEnum.ForSale,
                SeachLocations  = new List<SearchLocation>
                {
                    new SearchLocation
                    {
                        Id = SequentialGuid++.CurrentGuid,
                        Town = Towns.Wemmel,
                        Search = Searches.DefaultWemmelApartments,
                        CreationDate = DateTime.UtcNow,
                    }
                }
            };
        }



        public static class Properties
        {
            public static Property MyApartment = new Property
            {
                Id = SequentialGuid++.CurrentGuid,
                CreationDate = DateTime.UtcNow,
                BathroomNo = 1,
                Bedroom1Surface = 12,
                BedroomsNo = 2,
                ConstructionYear = 1970,
                Description = "My House",
                EPC = 150,
                FloorNo = 1,
                Garrages = 0,
                HasGarden = false,
                HasTerrace = true,
                LivableSurface = 80,
                ParkingPlaces = 0,
                Price = 200000,
                PropertyType = Domain.Enums.PropertyTypeEnum.Apartment,
                Town = Towns.Wemmel,
                Street = "Eburonenlaan",
                Number = "5",
                Latitude = 50.9009335,
                Longitude = 4.3292941,
                AddType = Domain.Enums.AddyTypeEnum.ForSale,
                Title = "My House"
            };
        }


    }
}
