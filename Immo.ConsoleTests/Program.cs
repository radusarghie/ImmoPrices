using Immo.Logic.PropertyWebsiteParser;
using Immo.Logic.SeedData;
using System;

namespace Immo.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Data..");
            GetData();
            Console.WriteLine("Got Data");
        }

        private static void GetData()
        {
            var parser = PropertyWebsiteParserFactory.GetPropertyWebsiteParser(Logic.SeedData.SeedValues.PropertyWebsites.Structura.Name);
            var savedHtmlPagedResults = parser.SaveProperties(SeedValues.Searches.DefaultWemmelApartments, SeedValues.PropertyWebsites.Structura);
        }
    }
}
