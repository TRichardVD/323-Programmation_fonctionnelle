using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MyApp
{
    internal class Program
    {

        private static Random random = new Random();

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        static (long time, long memory) MesurePerf(Action action, int iterations = 1000)
        {
            // Forcer le garbage collection avant mesure
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var memoryBefore = GC.GetTotalMemory(false);
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < iterations; i++)
            {
                action();
            }

            stopwatch.Stop();
            var memoryAfter = GC.GetTotalMemory(false);

            return (stopwatch.ElapsedMilliseconds, memoryAfter - memoryBefore);
        }

        static void Main(string[] args)
        {
            List<(string name, int age)> testList = new();



            Dictionary<string, Action> actions = new()
            {
                { "Select Simple", () =>
                {
                    var result = new List<string>();
                    foreach (var item in testList) {
                        result.Add(item.name);
                    }
                } },
                { "Select avec méthodes externes", () =>
                {
                    Func<(string name, int age), string> selectFunc = x => x.name;

                    testList.Select(selectFunc);
                } },
                { "Select avec expressions lambda", () =>
                {
                    testList.Select(x => x.name);
                } },
                { "Select avec création d'objets anonymes", () =>
                {
                    testList.Select(x => (x.name, x.age));
                } },
                { "Select avec création de classes typée", () =>
                {
                    testList.Select(x => new {Name = x.name, Age = x.age});
                } },

            };


            Console.WriteLine("Mesure de Performance");
            Console.Write("Préparation des données de tests ");

            for (int i = 0; i < 100000; i++)
            {
                testList.Add((GenerateRandomString(5), i));
            }
            Console.WriteLine("OK");
            Console.WriteLine("Tests en cours...");

            var results = new List<(string Method, long Time, long Memory)>();

            foreach (var (key, action) in actions)
            {
                var res = MesurePerf(action);
                results.Add((key, res.time, res.memory));
                Console.WriteLine($"{key} terminé en {res.time} et en utilisant {res.memory} de mémoire");
            }

            Console.WriteLine("Tests terminés");
            const string FILE_NAME = "export.md";
            Console.Write($"Génération du fichier récapitulatif \"{FILE_NAME}\" : ");
            var markdownContent = @"# Performance Comparison of Select Operations

| Method                          | Time (ms) | Memory (bytes) |
|---------------------------------|-----------|----------------|
";

            foreach (var result in results)
            {
                markdownContent += $"| {result.Method} | {result.Time} | {result.Memory} |\n";
            }

            File.WriteAllText(FILE_NAME, markdownContent);
            Console.WriteLine("OK");

        }


    }
}