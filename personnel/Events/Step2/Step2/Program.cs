using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MyApp
{
    internal class Program
    {
        public class Match
        {
            public string Player1 { get; set; }
            public string Player2 { get; set; }
            public int Score1 { get; set; }
            public int Score2 { get; set; }
            public string Winner => Score1 > Score2 ? Player1 : Player2;
            public string Result => $"{Player1} {Score1}-{Score2} {Player2}";
            public bool IsCloseMatch => Math.Abs(Score1 - Score2) <= 2;

            public override string ToString() => $"{Player1} {Score1}-{Score2} {Player2}";
        }

        static void Main(string[] args)
        {
            var playersA = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Eve", "Felix" };
            var playersB = new List<string> { "Grace", "Hugo", "Iris", "Jack", "Kim", "Leo" };
            var scoresA = new List<int> { 21, 18, 21, 15, 21, 19 };
            var scoresB = new List<int> { 19, 21, 16, 21, 17, 21 };

            var matchs = playersA.Zip(playersB, (a,b) => (playerA: a, playerB:b)).Zip(scoresA.Zip(scoresB, (a, b) => (scoreA: a, scoreB: b)), (a,b)=>(Players: a, Scores: b)).Select(x => new Match()
            {
                Player1 = x.Players.playerA,
                Player2 = x.Players.playerB,
                Score1 = x.Scores.scoreA,
                Score2 = x.Scores.scoreB,
            });

            Console.WriteLine("Tournoi de Ping-Pong");
            Console.WriteLine("==============================");
            Console.WriteLine(String.Join("\n", matchs.Select((x, index) => $"Match {index}: {x.ToString()} → Gagnante: {x.Winner}")));
            
            Console.WriteLine("\nMatchs serrés:");
            Console.WriteLine(String.Join("\n", matchs.Where(x => x.IsCloseMatch).Select((x, index) => $"\t• {x.ToString()}")));

            Console.WriteLine("\nClassement");
            Console.WriteLine(String.Join("\n", matchs.Aggregate(new Dictionary<String, int>(), (acc, x) =>
            {
                if (!acc.ContainsKey(x.Player1)) acc[x.Player1] = 0;
                if (!acc.ContainsKey(x.Player2)) acc[x.Player2] = 0;
                acc[x.Winner]++;
                return acc;
            }).OrderByDescending(x => x.Value).Select((x, index) => $"\t{x.Key}: {x.Value} victoire(s)")));


        }
    }
}