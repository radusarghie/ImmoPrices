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
        protected override Property GetPropertyFromDetailsHtml(string html)
        {
            var document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(req => req.Content(html)).Result;

            var property = new Property();

            return property;
        }

        protected override IEnumerable<string> GetPropertiesHtmls(string baseUrl)
        {
            string listContent;
            using (WebClient client = new WebClient())
            {
                listContent = client.DownloadString(baseUrl);
            }
            var document = BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(req => req.Content(listContent)).Result;
            var links = document.QuerySelectorAll("figure a").Select(p=>p.Attributes["href"].Value);
            var propertyHtmls = new ConcurrentBag<string>();
            Parallel.ForEach(links, (link) =>
             {
                 using (WebClient client = new WebClient())
                 {
                     propertyHtmls.Add(client.DownloadString(baseUrl));
                 }
             });
           
            return propertyHtmls;
           
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
