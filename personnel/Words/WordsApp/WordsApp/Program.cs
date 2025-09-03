using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Partie 1
            // Filtrage Basique
            Console.WriteLine("\nPartie 1A :\n==================================\n");
            Partie1A();


            // Données parasite 1
            Console.WriteLine("\nPartie 1B :\n==================================\n");
            Partie1B();

            // Données parasite 2
            Console.WriteLine("\nPartie 1C :\n==================================\n");
            Partie1C();

            // Elitime
            Console.WriteLine("\nPartie 1D :\n==================================\n");
            Partie1D();

            // Partie 2
            // Epsilon
            Console.WriteLine("\nPartie 2 :\n==================================\n");
            Partie2();

            // Partie 3
            // Dictionnaire
            Console.WriteLine("\nPartie 3 :\n==================================\n");
            Partie3();

        }

        public static void Partie1A()
        {

            string[] words = { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };
            double avgLength = words.Average(x => x.Length);
            var wordsFiltered = words.Where(word => !word.ToLower().Contains('x') && word.Length >= 4 && word.Length == avgLength).OrderDescending();
            Console.WriteLine("Order descending :\n" + string.Join("\n", words) + "\n---------------------");
            Console.WriteLine("Order a-z :\n" + string.Join("\n", words.OrderBy(x => x)) + "\n---------------------");
            Console.WriteLine("Order z-a :\n" + string.Join("\n", words.OrderByDescending(x => x)) + "\n---------------------");
        }

        public static void Partie1B()
        {
            string[] words = { "whatThe!!!", "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune", "My kingdom for a horse !", "Ooops I did it again" };
            var improveData = words.Skip(1).SkipLast(2);
            Console.WriteLine(string.Join("\n", improveData));
        }

        public static void Partie1C()
        {

            // Réponse à la question de l'exercice :
            // Non, on ne peut pas utilisé SkipWhile car il skip les premiers elements qui respecte la condition mais a partir du moment ou un element de respecte pas la condition il arrete de filtrer et donc retourner tous le reste.
            string[] words = { "+++++", "<<<<<", ">>>>>", "bonjour", "hello", "@@@@", "vert", "rouge", "bleu", "jaune", "#####", "%%%%%%%" };
            var wordsFiltered = words.Where(x => Regex.IsMatch(x, "^[a-zA-Z]"));
            Console.WriteLine(string.Join('\n', wordsFiltered));
        }

        public static void Partie1D()
        {
            string[] words = { "i am the winner", "hello", "monde", "vert", "rouge", "bleu", "i am the looser" };
            var filtredWords = new[] { words.First(), words.Last() };
            Console.WriteLine(string.Join('\n', filtredWords));

        }

        public static void Partie2()
        {
            Dictionary<char, double> frenchLetterProbability = new Dictionary<char, double>()
{
    {'e', 0.1210},
    {'a', 0.0711},
    {'i', 0.0659},
    {'s', 0.0651},
    {'n', 0.0639},
    {'r', 0.0607},
    {'t', 0.0592},
    {'o', 0.0502},
    {'l', 0.0496},
    {'u', 0.0449},
    {'d', 0.0367},
    {'c', 0.0318},
    {'m', 0.0262},
    {'p', 0.0249},
    {'é', 0.0194},
    {'g', 0.0123},
    {'b', 0.0114},
    {'v', 0.0111},
    {'h', 0.0111},
    {'f', 0.0111},
    {'q', 0.0065},
    {'y', 0.0046},
    {'x', 0.0038},
    {'j', 0.0034},
    {'è', 0.0031},
    {'à', 0.0031},
    {'k', 0.0029},
    {'w', 0.0017},
    {'z', 0.0015},
    {'ê', 0.0008},
    {'ç', 0.0006},
    {'ô', 0.0004},
    {'â', 0.0003},
    {'î', 0.0003},
    {'û', 0.0002},
    {'ù', 0.0002},
    {'ï', 0.0001},
    {'á', 0.0001},
    {'ü', 0.0001},
    {'ë', 0.0001},
    {'ö', 0.0001},
    {'í', 0.0001}
};


            double CalculeProbabilityOfWord(string word)
            {
                string wordToLower = word.ToLower();
                double probability = 0;
                List<char> carChecked = new List<char>();

                foreach (char c in wordToLower)
                {
                    if (carChecked.Contains(c) || !frenchLetterProbability.ContainsKey(c))
                    {
                        continue;
                    }
                    probability += frenchLetterProbability[c] / wordToLower.Count(car => car == c);
                    carChecked.Add(c);
                }

                return probability;

            }

            do {

                Console.Write("Entrer un mot : ");
                string? word = Console.ReadLine();
                if (word == null || word.Length == 0) break;
                double probability = CalculeProbabilityOfWord (word);
                Console.WriteLine($"Le mot \"{word}\" à une probabilité de {probability * 100}%");
            
            } while (true);



        }

        public static void Partie3()
        {
            List<string> frenchWords = new List<string>() {
                "Merci",
                "Hotdog",
                "Oui",
                "Non",
                "Désolé",
                "Réunion",
                "Manger",
                "Boire",
                "Téléphone",
                "Ordinateur",
                "Internet",
                "Email",
                "Sandwich",
                "Hello",
                "Taxi",
                "Hotel",
                "Gare",
                "Train",
                "Bus",
                "Métro",
                "Tramway",
                "Vélo",
                "Voiture",
                "Piéton",
                "Feu rouge",
                "Cédez",
                "Ralentir",
                "gauche",
                "droite",
                "Continuer",
                "Sandwich",
                "Retourner",
                "Arrêter",
                "Stationnement",
                "Parking",
                "Interdit",
                "Péage",
                "Trafic",
                "Route",
                "Rond-point",
                "Football",
                "Carrefour",
                "Feu",
                "Panneau",
                "Vitesse",
                "Tramway",
                "Aéroport",
                "Héliport",
                "Port",
                "Ferry",
                "Bateau",
                "Canot",
                "Kayak",
                "Paddle",
                "Surf",
                "Plage",
                "Mer",
                "Océan",
                "Rivière",
                "Lac",
                "Étang",
                "Marais",
                "Forêt",
                "Hello",
                "Montagne",
                "Vallée",
                "Plaine",
                "Désert",
                "Jungle",
                "Savane",
                "Volleyball",
                "Tundra",
                "Glacier",
                "Neige",
                "Pluie",
                "Soleil",
                "Nuage",
                "Vent",
                "Tempête",
                "Ouragan",
                "Tornade",
                "Séisme",
                "Tsunami",
                "Volcan",
                "Éruption",
                "Ciel"
            };

            List<string> englishWords = new List<string>() {
        "Hotdog",
        "Internet",
        "Email",
        "Sandwich",
        "Hello",
        "Taxi",
        "Hotel",
        "Train",
        "Bus",
        "Tramway",
        "Parking",
        "Traffic",
        "Football",
        "Port",
        "Ferry",
        "Kayak",
        "Paddle",
        "Surf",
        "Volleyball",
        "Tundra",
        "Glacier",
        "Tsunami",
        "Volcano"
    };

            var sameWordsEnglishAndFrench = frenchWords.Where(englishWords.Contains);
            Console.WriteLine(string.Join('\n', sameWordsEnglishAndFrench));


        }
    }
}