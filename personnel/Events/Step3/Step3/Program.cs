using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp
{

    public class DanceSession
    {
        public string MalePartner { get; set; }
        public string FemalePartner { get; set; }
        public string DanceStyle { get; set; }
        public string Song { get; set; }
        public TimeSpan StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public string Couple => $"{MalePartner} & {FemalePartner}";
        public TimeSpan EndTime => StartTime.Add(TimeSpan.FromMinutes(DurationMinutes));
        public string Schedule => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm} : {DanceStyle} to '{Song}'";
    }

    public enum DanceLevel { Beginner, Intermediate, Advanced }
    internal class Program
    {
        static void Main(string[] args)
        {
            var malePartners = new List<string> { "Antoine", "Bruno", "Camille", "David", "Etienne", "Fabien" };
            var femalePartners = new List<string> { "Amelie", "Beatrice", "Celine", "Delphine", "Elise", "Fanny" };
            var danceStyles = new List<string> { "Waltz", "Tango", "Salsa", "Rock", "Bachata", "Cha-cha" };
            var songs = new List<string> {
    "La Vie en Rose", "Por una Cabeza", "Bamboleo",
    "Johnny B. Goode", "Corazon Espinado", "Sway"
};
            var schedules = new List<TimeSpan> {
    new(20, 00, 0), new(20, 15, 0), new(20, 30, 0),
    new(20, 45, 0), new(21, 00, 0), new(21, 15, 0)
};
            var durations = new List<int> { 12, 10, 15, 8, 12, 10 };

            var sessions = malePartners
                .Zip(femalePartners, (m, f) => (Male: m, Female: f))
                .Zip(danceStyles, (mf, style) => (mf.Male, mf.Female, Style: style))
                .Zip(songs, (t, song) => (t.Male, t.Female, t.Style, Song: song))
                .Zip(schedules, (t, start) => (t.Male, t.Female, t.Style, t.Song, Start: start))
                .Zip(durations, (t, dur) => new DanceSession
                {
                    MalePartner = t.Male,
                    FemalePartner = t.Female,
                    DanceStyle = t.Style,
                    Song = t.Song,
                    StartTime = t.Start,
                    DurationMinutes = dur
                })
                .OrderBy(x => x.StartTime)
                .ToList();

            Console.WriteLine("Programme de dance");
            Console.WriteLine(new string('=', 31));
            foreach (var s in sessions)
            {
                Console.WriteLine("🎵 " + $"{s.StartTime:hh\\:mm} - {s.EndTime:hh\\:mm} : {s.DanceStyle} to '{s.Song}'");
                Console.WriteLine("   Couple: " + s.Couple);
                Console.WriteLine();
            }

            Console.WriteLine("Vérification du planning");
            bool anyOverlap = false;
            for (int i = 1; i < sessions.Count; i++)
            {
                var prev = sessions[i - 1];
                var cur = sessions[i];
                if (cur.StartTime < prev.EndTime)
                {
                    anyOverlap = true;
                    Console.WriteLine($"Chevauchement entre {prev.Couple} ({prev.StartTime:hh\\:mm}-{prev.EndTime:hh\\:mm}) et {cur.Couple} ({cur.StartTime:hh\\:mm}-{cur.EndTime:hh\\:mm})");
                }
            }
            if (!anyOverlap)
            {
                Console.WriteLine("Aucun chevauchement détecté.");
            }

            Console.WriteLine("Statistiques:");
            var totalDuration = sessions.Sum(s => s.DurationMinutes);
            Console.WriteLine($"   • Durée totale: {totalDuration} minutes");
            Console.WriteLine($"   • Nombre de dances: {sessions.Count}");

            var begin = sessions.Min(s => s.StartTime);
            var end = sessions.Max(s => s.EndTime);
            Console.WriteLine($"   • Début: {begin:hh\\:mm}");
            Console.WriteLine($"   • Fin: {end:hh\\:mm}");
            Console.WriteLine();

            Console.WriteLine("Styles:");
            var styleCounts = sessions.GroupBy(s => s.DanceStyle).OrderBy(g => g.Key);
            foreach (var g in styleCounts)
            {
                Console.WriteLine($"   • {g.Key}: {g.Count()}x");
            }

            Console.WriteLine();
            Console.WriteLine("Prochaine session:");
            Console.WriteLine("Suggestion:");
            var rotatedMales = malePartners.Skip(1).Concat(malePartners.Take(1)).ToList();
            var suggestion = rotatedMales.Zip(femalePartners, (m, f) => (m, f));
            foreach (var p in suggestion)
            {
                Console.WriteLine($"{p.m} & {p.f}");
            }
        }
    }
}