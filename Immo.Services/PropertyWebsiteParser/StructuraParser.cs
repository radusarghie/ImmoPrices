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

                BathroomNo = 0,
                BedroomsNo = 0,
                Bedroom1Surface = 0,
                Bedroom2Surface = 0,
                Bedroom3Surface = 0,
                Bedroom4Surface = 0,
                ConstructionYear = 0,
                Description = "",
                EPC = 0,
                FloorNo = 0,
                Garrages = 0,
                GroundSurface = 0,
                HasGarden = false,
                HasTerrace = false,
                Latitude = 0,
                LivableSurface = 0,
                Longitude = 0,
                Number = "",
                ParkingPlaces = 0,
                Pictures = "",
                Price = 0,
                Street = "",
                Town = null 
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
