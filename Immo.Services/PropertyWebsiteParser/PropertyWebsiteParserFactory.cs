using Immo.Database;
using Immo.Domain.BusinessDomain;

namespace Immo.Logic.PropertyWebsiteParser
{
    public static class PropertyWebsiteParserFactory
    {

        public static IPropertyWebsiteParser GetPropertyWebsiteParser(string propertyWebsiteName, IImmoCache cache)
        {
            switch (propertyWebsiteName)
            {
                case "Structura":
                {
                    return new StructuraParser(cache);
                }
            }

            return null;
        }

       
    }
}
