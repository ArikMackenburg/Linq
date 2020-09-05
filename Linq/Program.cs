using System;
using System.Collections;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Linq;
using System.Security.Cryptography.X509Certificates;

namespace Linq
{
    class Program
    {
        static string Data = GeoData.Data;
        public static RootObject Root = JsonConvert.DeserializeObject<RootObject>(Data);
        static void Main(string[] args)
        {
            ConsoleOutput();
        }


        public static void ConsoleOutput()
        {
            Title("Neighborhoods");
            Lines();
            Console.WriteLine(string.Join(", ", Neighborhoods));
            Spaces();
            Title("No empty Neighborhoods");
            Lines();
            Console.WriteLine(string.Join(", ", NonEmptyNeighborhoods));
            Spaces();
            Title("No duplicate or empty Neighborhoods");
            Lines();
            Console.WriteLine(string.Join(", ", NonDuplicateNeighborhoods));
            Spaces();
            Title("Boroughs in list");
            Lines();
            Console.WriteLine(string.Join(", ", NonDuplicateBorough));
            Spaces();
            Title("No duplicate Zipcodes");
            Lines();
            Console.WriteLine(string.Join(", ", NonDuplicateZip));
            Spaces();
            Title("Coordinates");
            Lines();
            Coordinates();
        }

        public static IEnumerable<string> Neighborhoods =
            from x in Root.features
            select x.properties.neighborhood;

        public static IEnumerable<string> NonEmptyNeighborhoods =
            from x in Root.features
            where x.properties.neighborhood != ""
            select x.properties.neighborhood;

        public static IEnumerable<string> NonDuplicateNeighborhoods = Root.features
            .Select(x => x.properties.neighborhood)
            .Distinct()
            .Where(neighborhood => !neighborhood.Equals(""));

        public static IEnumerable<string> NonDuplicateBorough =
            (from x in Root.features
             select x.properties.borough).Distinct();

        public static IEnumerable<string> NonDuplicateZip =
            (from x in Root.features
             select x.properties.zip).Distinct();

        public static void Coordinates()
        {

            IEnumerable<double[]> coordinates = Root.features
                .Select(x => x.geometry.coordinates);
            foreach (double[] coordinate in coordinates)
            {
                Console.Write($"[{string.Join(",",coordinate)}] ");
            }
                
        }
        public static void Lines()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        }
        public static void Title(string title)
        {
            Console.WriteLine(title);
        }

        public static void Spaces()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
