using Immo.Domain.BusinessDomain;
using Immo.Logic.PropertyWebsiteParser;
using System.Linq;
using System.Collections.Generic;
using System;
using Immo.Repositories.EF.Base;
using Immo.Database;
using System.Net;
using System.IO;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace Immo.Services.PropertyWebsiteParser
{
    public abstract class PropertyWebsiteParserBase : IPropertyWebsiteParser
    {
        protected abstract string GetSearchUrl(Search search, PropertyWebsite propertyWebsite);

        protected abstract Dictionary<string, string> GetPropertiesDetailsHtmls(string baseUrl);

        protected abstract Property GetPropertyFromDetailsHtml(string originalUrl, string html, Search search, PropertyWebsite propertyWebsite);

        protected IImmoCache ImmoCache { get; }

        public PropertyWebsiteParserBase(IImmoCache immoCache)
        {
            this.ImmoCache = immoCache;
        
        }
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

            var propertiesHtmls = GetPropertiesDetailsHtmls(url);
            ConcurrentBag<Property> propertiesBag = new ConcurrentBag<Property>();
            Parallel.ForEach(propertiesHtmls, (currentProperty) =>
            {
                var curentProperty = GetPropertyFromDetailsHtml(currentProperty.Key, currentProperty.Value, search, propertyWebsite);
                propertiesBag.Add(curentProperty);
                
               
            });


            var properties = SaveProperties(propertiesBag.ToList());

            return properties;
        }

        protected string SavePicture(Property property, string pictureUrl, string rootFolder)
        {
            var utcNow = DateTime.UtcNow;
            var dateFolder = $"{utcNow.Year}.{utcNow.Month}.{utcNow.Day}";
            var timeStamp = $"{utcNow.Hour}:{utcNow.Minute}:{utcNow.Second}:{utcNow.Millisecond}";
            var fileName = $"{property.Id}_{timeStamp}_{pictureUrl}";
            var fullFileName = $"{dateFolder}\\{fileName}";
            return fullFileName;
        }

        protected T ChangeType<T>(string stringValue)
        {
            Type t = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

            var result = (T)Convert.ChangeType(stringValue, t);
            return result;
        }

        protected string RemoveFormatting(string stringValue)
        {
            stringValue = stringValue.Replace("<strong>", string.Empty);
            stringValue = stringValue.Replace("</strong>", string.Empty);
            stringValue = stringValue.Replace("\"", string.Empty);
            stringValue = stringValue.Trim();

            return stringValue;
        }

        protected abstract T GetPropertyElement<T>(IDocument document, string label, string stringToRemove = null);
    }
}
