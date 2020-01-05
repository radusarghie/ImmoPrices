using Immo.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Immo.Database
{
    public class ImmoDBCache : IImmoCache
    {
        private List<Town> towns;

        private List<Country> countries;

        private List<User> users;

        private List<PropertyWebsite> propertyWebsites;

        private ImmoContext dbContext;
        public ImmoDBCache(ImmoContext dbContext)
        {
            this.dbContext = dbContext;
        }
       

        public List<Town> Towns 
        {
            get 
            {
                if (towns == null)
                {
                    towns = dbContext.Towns.ToList();
                }
                return towns;
            }
        }

        public List<Country> Countries
        {
            get
            {
                if (countries == null)
                {
                    countries = dbContext.Countries.ToList();
                }
                return countries;
            }
        }

        public List<User> Users
        {
            get
            {
                if (users == null)
                {
                    users = dbContext.Users.ToList();
                }
                return users;
            }
        }

        public List<PropertyWebsite> PropertyWebsites
        {
            get
            {
                if (propertyWebsites == null)
                {
                    propertyWebsites = dbContext.PropertyWebsites.ToList();
                }
                return propertyWebsites;
            }
        }
    }
}
