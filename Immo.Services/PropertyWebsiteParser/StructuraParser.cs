using AngleSharp;
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
        protected override Property GetPropertyFromDetailsHtml(string originalUrl, string html, Search search, PropertyWebsite propertyWebsite)
        {
            var document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(req => req.Content(html)).Result;

            var property = new Property
            {
                Id = Guid.NewGuid(),
                OriginalURL = originalUrl,
                AddType = search.AddyType,
                CreationDate = DateTime.UtcNow,
                PropertyType = search.PropertyType,
                PropertyWebsite = propertyWebsite,
                BathroomNo = null,
                BedroomsNo = null,
                Bedroom1Surface = null,
                Bedroom2Surface = null,
                Bedroom3Surface = null,
                Bedroom4Surface = null,
                ConstructionYear = null,
                Description = null,
                EPC = null,
                FloorNo = null,
                Garrages = null,
                GroundSurface = null,
                HasGarden = null,
                HasTerrace = null,
                Latitude = null,
                LivableSurface = null,
                Longitude = null,
                Number = null,
                ParkingPlaces = null,
                Pictures = null,
                Price = null,
                Street = null,
                TownId = null,
                Title = null
            };
            
            return property;
        }

        protected override Dictionary<string, string> GetPropertiesHtmls(string baseUrl)
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
                     propertyHtmls[baseUrl]=client.DownloadString(baseUrl);
                 }
             });
           
            return propertyHtmls.ToDictionary(entry=>entry.Key, entry => entry.Value);
           
        }

        protected override string GetSearchUrl(Search search, PropertyWebsite propertyWebsite)
        {
            var queryStringParameters = new StringBuilder(propertyWebsite.WebsitePropertyUrl + "/kopen/?");
            if (search.SeachLocations!=null && search.SeachLocations.Any())
            {
                queryStringParameters.Append("zips="+string.Join("%2C", search.SeachLocations.Select(p => p.Town.PostCode)) + "&");
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
    }
}
