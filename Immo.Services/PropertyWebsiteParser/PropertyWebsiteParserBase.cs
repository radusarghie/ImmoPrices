using Immo.Domain.BusinessDomain;
using Immo.Logic.PropertyWebsiteParser;
using System.Linq;
using System.Collections.Generic;
using System;
using Immo.Repositories.EF.Base;
using Immo.Database;
using System.Net;

namespace Immo.Services.PropertyWebsiteParser
{
    public abstract class PropertyWebsiteParserBase : IPropertyWebsiteParser
    {
        protected abstract string GetSearchUrl(Search search, PropertyWebsite propertyWebsite);

        protected abstract Dictionary<string, string> GetPropertiesHtmls(string baseUrl);

        protected abstract Property GetPropertyFromDetailsHtml(string originalUrl, string html, Search search, PropertyWebsite propertyWebsite);

        protected IEnumerable<Property> SaveProperties(IEnumerable<Property> properties)
        {
            using (ImmoContext dbContext = new ImmoContextFactory().CreateDbContext())
            {
                var repository = new EFReadWriteRepositoryBase<Property, Guid>(dbContext);
                repository.CreateOrUpdate(properties);
            }

            return properties;
        }

        public IEnumerable<Property> SaveProperties(Search search, PropertyWebsite propertyWebsite)
        {

            var url = GetSearchUrl(search, propertyWebsite);

            var propertiesHtmls = GetPropertiesHtmls(url);

            var properties = propertiesHtmls.Select(p => GetPropertyFromDetailsHtml(p.Key, p.Value, search, propertyWebsite));

            //properties = SaveProperties(properties);

            return properties;
        }

    
    }
}
