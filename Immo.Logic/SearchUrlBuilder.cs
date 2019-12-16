using Immo.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Logic
{
    public class SearchUrlBuilder
    {
        public string GetSearchUrl(Search search, PropertyWebsite propertyWebsite)
        {
            var result = string.Empty;
            switch (propertyWebsite.Name)
            {
                case "Structura":
                {
                    return StructuraUrlBuilder(search);
                }
            }

            return result;
        }

        public string StructuraUrlBuilder(Search search)
        {
            var searchUrlPattern = string.Format(SeedValues.PropertyWebsites.Structura.WebsitePropertyUrl,"1780","2","400000","2");
            var result = "";
            return result;
        }
    }
}
