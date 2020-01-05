using AngleSharp;
using AngleSharp.Dom;
using Immo.Database;
using Immo.Domain.BusinessDomain;
using Immo.Services.PropertyWebsiteParser;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Immo.Logic.PropertyWebsiteParser
{
    public class StructuraParser : PropertyWebsiteParserBase
    {
        public StructuraParser(IImmoCache immoCache) : base(immoCache) { }
        protected override Property GetPropertyFromDetailsHtml(string originalUrl, string html, Search search, PropertyWebsite propertyWebsite)
        {
            var document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(req => req.Content(html)).Result;
            var property = new Property();
            property.Id = Guid.NewGuid();
            property.OriginalURL = originalUrl;
            property.AddType = search.AddType;
            property.CreationDate = DateTime.UtcNow;
            property.PropertyType = search.PropertyType;
            property.PropertyWebsiteId = propertyWebsite.Id;
            property.BathroomNo = GetPropertyElement<Int32?>(document, "AANTAL BADKAMERS");
            property.BedroomsNo = GetPropertyElement<Int32?>(document, "AANTAL SLAAPKAMERS");
            property.ConstructionYear = GetPropertyElement<Int32?>(document, "BOUWJAAR"); ;
            property.Description = document.QuerySelector("div.main-content div.content p").TextContent;
            property.Surface = GetPropertyElement<double?>(document, "BEWOONBARE OPPERVLAKTE", "m2"); ;
            property.Number = null;
            property.Pictures = String.Join(",", document.QuerySelectorAll("section.property-slider a")?.Select(p => p.Attributes["href"]?.Value));
            property.Price = ChangeType<double?>(document.QuerySelector("span.property-price").TextContent.Replace("€", string.Empty).Trim());
            property.Street = null;
            property.TownId = search.TownId;
            property.Title = RemoveFormatting(document.QuerySelector("div.main-content header h1").TextContent) ;
            
            
            return property;
        }

        protected override Dictionary<string, string> GetPropertiesDetailsHtmls(string baseUrl)
        {
            string listContent;
            using (WebClient client = new WebClient())
            {
                listContent = client.DownloadString(baseUrl);
            }
            var document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(req => req.Content(listContent)).Result;
            var links = document.QuerySelectorAll("figure a").Select(p=>p.Attributes["href"].Value);
            var propertyHtmls = new ConcurrentDictionary<string, string>();
            Parallel.ForEach(links, (link) =>
             {
                 using (WebClient client = new WebClient())
                 {
                     propertyHtmls[link] =client.DownloadString(link);
                 }
             });
           
            return propertyHtmls.ToDictionary(entry=>entry.Key, entry => entry.Value);
           
        }

        protected override string GetSearchUrl(Search search, PropertyWebsite propertyWebsite)
        {
            var queryStringParameters = new StringBuilder(propertyWebsite.WebsitePropertyUrl + "/kopen/?");
            if (search.TownId != null)
            {
                var zipCode = ImmoCache.Towns.FirstOrDefault(p=>p.Id==search.TownId).PostCode;
                queryStringParameters.Append("zips="+string.Join("%2C", zipCode) + "&");
            }
            if (search.PropertyType.HasValue)
            {
                queryStringParameters.Append("WebIdD=" + (search.PropertyType == Domain.Enums.PropertyTypeEnum.House ? 2:1) + "&");
            }

            if (search.MaxPrice.HasValue)
            {
                queryStringParameters.Append("priceTo=" + search.MaxPrice + "&");
            }

            if (search.MinRoomsNo.HasValue)
            {
                queryStringParameters.Append("minRooms=" + search.MinRoomsNo + "&");
            }

            var result = queryStringParameters.ToString();
            return result;
        }

        protected  T GetPropertyElement<T>(IDocument document, string label, string stringToRemove = null) 
        {
            var attributeTable = document.QuerySelector("table.attribute-table");
            var stringValue = attributeTable.QuerySelectorAll("tr")
                .FirstOrDefault(p => string.Equals(p.FirstElementChild.TextContent, label,StringComparison.OrdinalIgnoreCase))
                ?.QuerySelector("td").TextContent;
            if (string.IsNullOrEmpty(stringValue))
            {
                return default(T);
            }
            if (!string.IsNullOrEmpty(stringToRemove))
            {
                stringValue = stringValue.Replace(stringToRemove, string.Empty).Trim();
            }

            var result = ChangeType<T>(stringValue);
            return result;

        }
    }
}
