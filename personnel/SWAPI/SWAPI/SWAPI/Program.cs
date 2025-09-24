using System;
using System.Collections;
using Newtonsoft.Json;

namespace MyApp
{
    public static class Extensions
    {
        public static void Write(this IEnumerable values, char separator = ',')
        {
            Console.WriteLine(string.Join(separator, values));
        }
    }

    public class Api
    {
        private const string BASE_URL = "https://swapi.dev/api/";

        // TODO : A terminer
        private async Task<object?> Call(string url)
        {
            var client = new HttpClient();
            return JsonConvert.DeserializeObject<Object>((await client.GetAsync(BASE_URL + url)).Content.ReadAsStringAsync().Result);

        }

        // People
        public Object GetPeoples()
        {
           return this.Call("people/");

        }
        public Object GetPeople(int id)
        {
            return this.Call($"people/{id}/");
        }

        // Films
        public async Task<object?> GetFilms()
        {
            return await this.Call("films/");
        }
        public Object GetFilm(int id)
        {
            return this.Call($"films/{id}/");
        }


        // Planètes
        public Object GetPlanets()
        {
            return this.Call("planets/");

        }
        public Object GetPlanet(int id)
        {
            return this.Call($"planets/{id}/");
        }

        // Spaceships
        public Object GetStarships()
        {
            return this.Call("starships/");
        }
        public Object GetStarship(int id)
        {
            return this.Call($"starships/{id}/");
        }

        // Vehicles
        public Object GetVehicles()
        {
            return this.Call("vehicles/");
        }
        public Object GetVehicle(int id)
        {
            return this.Call($"vehicles/{id}/");
        }

        // Species
        public Object GetSpecies()
        {
            return this.Call("species/");
        }
        public Object GetSpecie(int id)
        {
            return this.Call($"species/{id}/");
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Api api = new Api();

            Console.WriteLine("Questions - Réponses");
            Console.WriteLine("--------------------");

            Console.WriteLine("Quel est le film Star Wars dont le titre est le plus long ?");

            Console.WriteLine("Quel est le personnage qui est présent dans le plus de films ?");


            Console.WriteLine("Quelle est la planète la plus peuplée ?");


            Console.WriteLine("Combien de starfighter X-Wing est-ce que je peux m'acheter si je vends un Star Destroyer ?");


            Console.WriteLine("Est-ce qu'Obi-wan Kenobi peut piloter un Millennium Falcon ?");


            Console.WriteLine("Quel est le vaisseau le plus rapide en vitesse lumière (vmax = vitesse atmosphérique max * ratio hyperespace) ?");


            Console.WriteLine("Combien de vaisseaux sont plus rapides que la moyenne de la vitesse atmosphérique de tous les vaisseaux ?");


            Console.WriteLine("Quel est le budget nécessaire (en franc suisse (1 crédit = 0.778 CHF)) à l’achat de la flotte totale ?");


            Console.WriteLine("Générer un CSV (vaisseau.txt) contenant les infos suivantes des vaisseaux : Nom du vaisseau, Prix, Longueur, Films dans lesquels ils apparaissent (nom des films en minuscule séparés par des tirets), Nom des planètes survolées (nom des planètes en minuscule séparées par des tirets)");

        }
    }
}