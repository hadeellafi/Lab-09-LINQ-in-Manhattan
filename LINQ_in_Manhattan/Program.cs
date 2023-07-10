using Newtonsoft.Json;
using System.Text.Json;

namespace LINQ_in_Manhattan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../data.json";

            string jsonString = File.ReadAllText(path);

            //Console.WriteLine(jsonString);
            Root roots = JsonConvert.DeserializeObject<Root>(jsonString);

            ////////////////////////////////

            AllNeighborhoods(roots);
            AllNeighborhoodsWithoutEmpty(roots);
            RemoveDuplicates(roots);
            AllTogather(roots);
            OpposingMethod(roots);
            
            //////////////////

        }
        static void AllNeighborhoods(Root roots)
        {
            Console.WriteLine("1.Output all of the neighborhoods in this data list (Final Total: 147 neighborhoods");

            var neighborhoods = roots.Features.Select(feature => feature.Properties.Neighborhood);

            foreach (var neighborhood in neighborhoods)
            {
                Console.WriteLine(neighborhood);
            }

            int totalNeighborhoods = neighborhoods.Count();
            Console.WriteLine($"Final Total: {totalNeighborhoods} neighborhoods");

            Console.WriteLine("*******************************************************************************");

        }
        static void AllNeighborhoodsWithoutEmpty(Root roots)
        {
            Console.WriteLine("2.Filter out all the neighborhoods that do not have any names (Final Total: 143)\n");

            var neighborhoods = roots.Features.Select(feature => feature.Properties.Neighborhood)
                                        .Where(neighborhood => !string.IsNullOrEmpty(neighborhood));

            foreach (var neighborhood in neighborhoods)
            {
                Console.WriteLine(neighborhood);
            }

            int totalNeighborhoods = neighborhoods.Count();
            Console.WriteLine($"Final Total: {totalNeighborhoods} neighborhoods");
            Console.WriteLine("*******************************************************************************");
        }
        static void RemoveDuplicates(Root roots)
        {
            Console.WriteLine("3.Remove the duplicates (Final Total: 39 neighborhoods)\n");

            var neighborhoods = roots.Features.Select(feature => feature.Properties.Neighborhood)
                                   .Where(neighborhood => !string.IsNullOrEmpty(neighborhood)).Distinct();

            foreach (var neighborhood in neighborhoods)
            {
                Console.WriteLine(neighborhood);
            }

            int totalNeighborhoods = neighborhoods.Count();
            Console.WriteLine($"Final Total: {totalNeighborhoods} neighborhoods");
            Console.WriteLine("*******************************************************************************");
        }
        static void AllTogather(Root roots)
        {
            Console.WriteLine("4.Rewrite the queries from above and consolidate all into one single query.\n");

            var neighborhoods = (from feature in roots.Features
                               let neighborhood = feature.Properties.Neighborhood
                               where !string.IsNullOrEmpty(neighborhood)
                               select neighborhood).Distinct();

            foreach (var neighborhood in neighborhoods)
            {
                Console.WriteLine(neighborhood);
            }

            int totalNeighborhoods = neighborhoods.Count();
            Console.WriteLine($"Final Total: {totalNeighborhoods} neighborhoods");
            Console.WriteLine("*******************************************************************************");
        }
        static void OpposingMethod(Root roots)
        {
            /////////// here rewrite the first question using linq query syntax instead of method syntax

            Console.WriteLine("5. rewrite one of question: qustiont 1 :put all of the neighborhoods in this data list \n using linq query syntax instead of method syntax");

            var neighborhoods = (from feature in roots.Features select feature.Properties.Neighborhood);

            foreach (var neighborhood in neighborhoods)
            {
                Console.WriteLine(neighborhood);
            }

           int totalNeighborhoods = neighborhoods.Count();
            Console.WriteLine($"Final Total: {totalNeighborhoods} neighborhoods");
            Console.WriteLine("*******************************************************************************"); 

        }


    }
}
/*
 */