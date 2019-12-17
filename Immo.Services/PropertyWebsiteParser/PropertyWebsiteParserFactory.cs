using Immo.Domain.BusinessDomain;

namespace Immo.Logic.PropertyWebsiteParser
{
    public static class PropertyWebsiteParserFactory
    {

        public static IPropertyWebsiteParser GetPropertyWebsiteParser(string propertyWebsiteName)
        {
            switch (propertyWebsiteName)
            {
                case "Structura":
                {
                    return new StructuraParser();
                }
            }

            return null;
        }

       
    }
}
