using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var group1 = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Eve" };
            var group2 = new List<string> { "Felix", "Grace", "Hugo", "Iris", "Jack" };

            var result = group1.Zip(group2);

            Console.WriteLine("Répartition:");
            Console.WriteLine("-------------------------");

            Console.WriteLine(String.Join("\n",result.Select((x,i) => $"Team {i}: {x.First} & {x.Second}")));
            Console.WriteLine($"\nTotal: {result.Count()} équipes");
        }
    }
}