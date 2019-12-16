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
        private readonly ImmoContext immoContext;

        public ImmoSeeder(ImmoContext immoContext)
        {
            this.immoContext = immoContext;
        }

        public void Seed()
        {

            immoContext.Database.EnsureCreated();

            SeedUsers(immoContext);

            SeedCountries(immoContext);

            SeedProvinces(immoContext);

            SeedTowns(immoContext);

            SeedPropertyWebsites(immoContext);

            SeedSearches(immoContext);

            SeedProperties(immoContext);

            immoContext.SaveChanges();
        }

        private void SeedProperties(ImmoContext immoContext)
        {
            if (!immoContext.Properties.Any(p => p.Id == SeedValues.Properties.MyApartment.Id))
            {
                immoContext.Properties.Add(SeedValues.Properties.MyApartment);
            }
            else 
            {
                immoContext.Properties.Update(SeedValues.Properties.MyApartment);
            }

        }

        private void SeedSearches(ImmoContext immoContext)
        {
            if (!immoContext.Searches.Any(p => p.Id == SeedValues.Searches.DefaultWemmelApartments.Id))
            {
                immoContext.Searches.Add(SeedValues.Searches.DefaultWemmelApartments);
            }
            else
            {
                immoContext.Searches.Update(SeedValues.Searches.DefaultWemmelApartments);
            }
        }


        private void SeedPropertyWebsites(ImmoContext immoContext)
        {
            if (!immoContext.PropertyWebsites.Any(p => p.Id == SeedValues.PropertyWebsites.Structura.Id))
            {
                immoContext.PropertyWebsites.Add(SeedValues.PropertyWebsites.Structura); ;
            }
            else
            {
                immoContext.PropertyWebsites.Update(SeedValues.PropertyWebsites.Structura); ;
            }
        }

        private void SeedTowns(ImmoContext immoContext)
        {
            if (!immoContext.Towns.Any(p => p.Id == SeedValues.Towns.Wemmel.Id))
            {
                immoContext.Towns.Add(SeedValues.Towns.Wemmel); ;
            }
            else 
            {
                immoContext.Towns.Update(SeedValues.Towns.Wemmel); ;
            }

            if (!immoContext.Towns.Any(p => p.Id == SeedValues.Towns.Iasi.Id))
            {
                immoContext.Towns.Add(SeedValues.Towns.Iasi);
            }
            else 
            {
                immoContext.Towns.Update(SeedValues.Towns.Iasi);
            }
        }

        private void SeedProvinces(ImmoContext immoContext)
        {
            if (!immoContext.Provinces.Any(p => p.Id == SeedValues.Provinces.FlemishBrabant.Id))
            {
                immoContext.Provinces.Add(SeedValues.Provinces.FlemishBrabant);
            }
            else 
            {
                immoContext.Provinces.Update(SeedValues.Provinces.FlemishBrabant);
            }
            if (!immoContext.Provinces.Any(p => p.Id == SeedValues.Provinces.Iasi.Id))
            {
                immoContext.Provinces.Add(SeedValues.Provinces.Iasi);
            }
            else
            {
                immoContext.Provinces.Update(SeedValues.Provinces.Iasi);
            }
        }

        private void SeedCountries(ImmoContext immoContext)
        {
            if (!immoContext.Countries.Any(p => p.Id == SeedValues.Countries.Belgium.Id))
            {
                immoContext.Countries.Add(SeedValues.Countries.Belgium);
            }
            else 
            {
                immoContext.Countries.Update(SeedValues.Countries.Belgium);
            }
            if (!immoContext.Countries.Any(p => p.Id == SeedValues.Countries.Romania.Id))
            {
                immoContext.Countries.Add(SeedValues.Countries.Romania);
            }
            else
            {
                immoContext.Countries.Update(SeedValues.Countries.Romania);
            }
        }

        private void SeedUsers(ImmoContext immoContext)
        {
            if (!immoContext.Users.Any(p => p.Id == SeedValues.Users.Radu.Id))
            {
                immoContext.Users.Add(SeedValues.Users.Radu);
            }
            else
            {
                immoContext.Users.Update(SeedValues.Users.Radu);
            }
        }
    }
}
