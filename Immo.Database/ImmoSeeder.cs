using Immo.Domain.BusinessDomain;
using Immo.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Immo.Database
{
    public class ImmoSeeder
    {
        public readonly ImmoContext immoContext;

        public ImmoSeeder(ImmoContext immoContext)
        {
            this.immoContext = immoContext;
        }

        public void Seed()
        {
            immoContext.Database.EnsureCreated();

            if (!immoContext.Users.Any())
            {
                immoContext.Users.Add(new User
                {
                    Id = Guid.Empty,
                    UserName = "rsarghie"
                });
            }


            if (!immoContext.Countries.Any())
            {
                immoContext.Countries.Add(new Country
                {
                    Id = Guid.Empty,
                    Name = "Belgium"
                });

                immoContext.Countries.Add(new Country
                {   
                    Id = Guid.NewGuid(),
                    Name = "Romania"
                });
            }


            if (!immoContext.Provinces.Any())
            {
                immoContext.Provinces.Add(new Province
                {
                    Id = Guid.Empty,
                    Name = "Flemish Brabant",
                    CountryId = immoContext.Countries.First(p=>p.Name == "Belgium").Id
                }); ;

                immoContext.Provinces.Add(new Province
                {
                    Id = Guid.Empty,
                    Name = "Iasi",
                    CountryId = immoContext.Countries.First(p => p.Name == "Romania").Id
                });
            }


            if (!immoContext.Towns.Any())
            {
                immoContext.Towns.Add(new Town
                {
                    Id = Guid.Empty,
                    Name = "Wemmel",
                    ProvinceId = immoContext.Provinces.First(p => p.Name == "Flemish Brabant").Id
                }); ;

                immoContext.Towns.Add(new Town
                {
                    Id = GuidExtensions.NextGuid(Guid.Empty),
                    Name = "Iasi",
                    ProvinceId = immoContext.Provinces.First(p => p.Name == "Iasi").Id
                });

                immoContext.SaveChanges();
            }
        }
    }
}
