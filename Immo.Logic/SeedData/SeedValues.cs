using Immo.Domain.BusinessDomain;
using System;
using System.Collections.Generic;

namespace Immo.Logic.SeedData
{
    public static class SeedValues
    {
        public static class Users
        {
            public static User Radu { get; } = new User
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                UserName = "rsarghie",
                CreationDate = DateTime.UtcNow
            };
        }

        public static class Countries
        {
            public static Country Belgium = new Country
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Belgium",
                CreationDate = DateTime.UtcNow
            };

            public static Country Romania = new Country
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "Romania",
                CreationDate = DateTime.UtcNow
            };

        }

        public static class Towns
        {
            public static Town Wemmel = new Town
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                Name = "Wemmel",
                PostCode = "1780",
                CountryId = Countries.Belgium.Id,
                CreationDate = DateTime.UtcNow
            };

            public static Town Iasi = new Town
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                Name = "Iasi",
                PostCode = "700303",
                CountryId = Countries.Romania.Id,
                CreationDate = DateTime.UtcNow
            };
        }

        public static class PropertyWebsites
        {
            public static PropertyWebsite Structura = new PropertyWebsite
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
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
                Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                UserId = Users.Radu.Id,
                MinPrice = 200000,
                MaxPrice = 400000,
                MinRoomsNo = 2,
                CreationDate = DateTime.UtcNow,
                AddType = Domain.Enums.AddyTypeEnum.ForSale,
                TownId = Towns.Wemmel.Id,
                Name = "DefaultWemmelApartments"
            };

            public static Search DefaultIasiApartments = new Search
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                UserId = Users.Radu.Id,
                MinPrice = 50000,
                MaxPrice = 90000,
                MinRoomsNo = 2,
                CreationDate = DateTime.UtcNow,
                AddType = Domain.Enums.AddyTypeEnum.ForSale,
                TownId = Towns.Iasi.Id,
                Name = "DefaultIasiApartments"
            };
        }



        public static class Properties
        {
            public static Property MyApartmentWemmel = new Property
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                CreationDate = DateTime.UtcNow,
                BathroomNo = 1,
                BedroomsNo = 2,
                ConstructionYear = 1970,
                Description = "My House Wemmel",
                Surface = 80,
                Price = 200000,
                PropertyType = Domain.Enums.PropertyTypeEnum.Apartment,
                TownId = Towns.Wemmel.Id,
                Street = "Eburonenlaan",
                Number = "5",
                AddType = Domain.Enums.AddyTypeEnum.ForSale,
                Title = "My House Wemmel",
                PropertyWebsiteId = PropertyWebsites.Structura.Id
            };

            public static Property MyApartmentIasi = new Property
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                CreationDate = DateTime.UtcNow,
                BathroomNo = 1,
                BedroomsNo = 1,
                ConstructionYear = 1980,
                Description = "My House Iasi",
                Surface = 50,
                Price = 65000,
                PropertyType = Domain.Enums.PropertyTypeEnum.Apartment,
                TownId = Towns.Iasi.Id,
                Street = "Apelor",
                Number = "6",
                AddType = Domain.Enums.AddyTypeEnum.ForSale,
                Title = "My House Iasi",
                PropertyWebsiteId = PropertyWebsites.Structura.Id
            };
        }


    }
}
