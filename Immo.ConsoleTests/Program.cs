using Immo.Database;
using Immo.Logic.PropertyWebsiteParser;
using Immo.Logic.SeedData;
using System;

namespace Immo.ConsoleTests
{
    class Program
    {
        private static IImmoCache ImmoCache => new ImmoDBCache(new ImmoContext("Data Source=.\\SQLEXPRESS;Database=Immo;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true"));
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Data..");
            GetData();
            Console.WriteLine("Got Data");
        }

        private static void GetData()
        {

            var parser = PropertyWebsiteParserFactory.GetPropertyWebsiteParser(SeedValues.PropertyWebsites.Structura.Name, ImmoCache);
            var savedHtmlPagedResults = parser.SaveProperties(SeedValues.Searches.DefaultWemmelApartments, SeedValues.PropertyWebsites.Structura);
        }
    }
}
