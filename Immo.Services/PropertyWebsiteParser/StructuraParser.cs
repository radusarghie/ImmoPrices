using Immo.Domain.BusinessDomain;
using Immo.Services.PropertyWebsiteParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Immo.Logic.PropertyWebsiteParser
{
    public class StructuraParser : PropertyWebsiteParserBase
    {
        protected override Property GetPropertyFromDetailsHtml(string html)
        {
            var property = new Property();

            return property;
        }

        protected override IEnumerable<string> GetPropertiesHtmls(string baseUrl)
        {
            var properyUrls = new List<string>();
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                string html = client.DownloadString(baseUrl);
            }

            return properyUrls;

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
