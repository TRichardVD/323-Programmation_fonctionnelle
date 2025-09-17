using System;
using System.Linq;
using static MyApp.Program;

namespace MyApp
{
    internal class Program
    {
        public class Product
        {
            public int? Emplacement { get; set; }
            public string? Producteur { get; set; }
            public string? NomProduit { get; set; }
            public int? Quantite { get; set; }
            public string? Unite { get; set; }
            public double? PrixParUnite { get; set; }

            public Product(int? emplacement = null, string? producteur = null, string? nomProduit = null, int? quantite = null, string? unite = null, double? prixParUnite = null)
            {
                Emplacement = emplacement;
                Producteur = producteur;
                NomProduit = nomProduit;
                Quantite = quantite;
                Unite = unite;
                PrixParUnite = prixParUnite;
            }
        }

        

        static void Main(string[] args)
        {
            List<Product> listeProduits = new List<Product>
        {
            new Product(1, "Bornand", "Pommes", 20, "kg", 6.9),
            new Product(1, "Bornand", "Poires", 16, "kg", 3.5),
            new Product(1, "Bornand", "Pastèques", 14, "pièce", 6.0),
            new Product(1, "Bornand", "Melons", 5, "kg", 7.0),
            new Product(2, "Dumont", "Noix", 20, "sac", 8.6),
            new Product(2, "Dumont", "Raisin", 6, "kg", 5.6),
            new Product(2, "Dumont", "Pruneaux", 13, "kg", 8.1),
            new Product(2, "Dumont", "Myrtilles", 12, "kg", 8.9),
            new Product(2, "Dumont", "Groseilles", 12, "kg", 5.2),
            new Product(3, "Vonlanthen", "Pêches", 8, "kg", 8.7),
            new Product(3, "Vonlanthen", "Haricots", 6, "kg", 6.9),
            new Product(3, "Vonlanthen", "Courges", 18, "pièce", 4.3),
            new Product(3, "Vonlanthen", "Tomates", 12, "kg", 9.4),
            new Product(3, "Vonlanthen", "Pommes", 20, "kg", 3.9),
            new Product(4, "Barizzi", "Poires", 5, "kg", 6.3),
            new Product(4, "Barizzi", "Pastèques", 6, "pièce", 2.5),
            new Product(4, "Barizzi", "Melons", 14, "kg", 4.2),
            new Product(4, "Barizzi", "Noix", 20, "sac", 7.5),
            new Product(4, "Barizzi", "Raisin", 15, "kg", 3.8),
            new Product(5, "Aebischer", "Pruneaux", 20, "kg", 5.5),
            new Product(5, "Aebischer", "Myrtilles", 13, "kg", 9.8),
            new Product(5, "Aebischer", "Groseilles", 13, "kg", 6.6),
            new Product(5, "Aebischer", "Pêches", 13, "kg", 2.3),
            new Product(5, "Aebischer", "Haricots", 12, "kg", 1.8),
            new Product(6, "Favre", "Courges", 13, "pièce", 3.8),
            new Product(6, "Favre", "Tomates", 14, "kg", 1.6),
            new Product(6, "Favre", "Pommes", 6, "kg", 3.7),
            new Product(6, "Favre", "Poires", 18, "kg", 9.7),
            new Product(6, "Favre", "Pastèques", 11, "pièce", 6.4),
            new Product(7, "Berset", "Melons", 20, "kg", 8.0),
            new Product(7, "Berset", "Noix", 11, "sac", 9.4),
            new Product(7, "Berset", "Raisin", 13, "kg", 1.1),
            new Product(7, "Berset", "Pruneaux", 19, "kg", 8.5),
            new Product(7, "Berset", "Myrtilles", 12, "kg", 4.7),
            new Product(8, "Cotter", "Groseilles", 11, "kg", 3.5),
            new Product(8, "Cotter", "Pêches", 7, "kg", 9.1),
            new Product(8, "Cotter", "Haricots", 20, "kg", 8.4),
            new Product(8, "Cotter", "Courges", 11, "pièce", 2.6),
            new Product(8, "Cotter", "Tomates", 18, "kg", 6.2),
            new Product(9, "Girard", "Pommes", 12, "kg", 9.2),
            new Product(9, "Girard", "Poires", 6, "kg", 1.2),
            new Product(9, "Girard", "Pastèques", 16, "pièce", 5.1),
            new Product(9, "Girard", "Melons", 13, "kg", 9.5),
            new Product(9, "Girard", "Noix", 20, "sac", 1.8),
            new Product(10, "Dupont", "Raisin", 11, "kg", 7.4),
            new Product(10, "Dupont", "Pruneaux", 20, "kg", 6.2),
            new Product(10, "Dupont", "Myrtilles", 13, "kg", 3.3),
            new Product(10, "Dupont", "Groseilles", 11, "kg", 5.5),
            new Product(10, "Dupont", "Pêches", 8, "kg", 7.1),
            new Product(11, "Beaud", "Haricots", 19, "kg", 8.4),
            new Product(11, "Beaud", "Courges", 16, "pièce", 8.7),
            new Product(11, "Beaud", "Tomates", 18, "kg", 5.3),
            new Product(11, "Beaud", "Pommes", 8, "kg", 7.3),
            new Product(11, "Beaud", "Poires", 13, "kg", 9.2),
            new Product(12, "Corbaz", "Pastèques", 15, "pièce", 7.4),
            new Product(12, "Corbaz", "Melons", 12, "kg", 1.6),
            new Product(12, "Corbaz", "Noix", 11, "sac", 7.5),
            new Product(12, "Corbaz", "Raisin", 16, "kg", 4.5),
            new Product(12, "Corbaz", "Pruneaux", 20, "kg", 3.3),
            new Product(13, "Amaudruz", "Myrtilles", 18, "kg", 5.7),
            new Product(13, "Amaudruz", "Groseilles", 19, "kg", 8.0),
            new Product(13, "Amaudruz", "Pêches", 12, "kg", 5.5),
            new Product(13, "Amaudruz", "Haricots", 13, "kg", 5.2),
            new Product(13, "Amaudruz", "Courges", 7, "pièce", 9.6),
            new Product(14, "Bühlmann", "Tomates", 12, "kg", 7.7),
            new Product(14, "Bühlmann", "Pommes", 17, "kg", 1.9),
            new Product(14, "Bühlmann", "Poires", 7, "kg", 3.0),
            new Product(14, "Bühlmann", "Pastèques", 11, "pièce", 6.9),
            new Product(14, "Bühlmann", "Melons", 7, "kg", 4.7),
            new Product(15, "Crizzi", "Noix", 10, "sac", 1.6),
            new Product(15, "Crizzi", "Raisin", 17, "kg", 7.8),
            new Product(15, "Crizzi", "Pruneaux", 18, "kg", 9.0),
            new Product(15, "Crizzi", "Myrtilles", 12, "kg", 3.0),
            new Product(15, "Crizzi", "Groseilles", 12, "kg", 3.5),
            new Product(15, "Lea", "Groseilles,", 12, "kg", 3.5)
        };

            // 0. La quantité de groseilles disponibles sur le marché
            Console.WriteLine(listeProduits.Aggregate(new Dictionary<string, int>(), (acc, produit) =>
            {
                if (acc.ContainsKey(produit.NomProduit)) acc[produit.NomProduit]++;
                else acc.Add(produit.NomProduit, 1);
                return acc;
            }, (acc) =>
            {
                return acc["Groseilles"];
            }));


            // 1. Le chiffre d’affaire possible total pour chaque marchand (tout produit confondu)
            var res2 = listeProduits.Aggregate(new Dictionary<string, double>(), (acc, produit) =>
            {
                double res = Convert.ToDouble(produit.PrixParUnite) * Convert.ToDouble(produit.Quantite);
                if (acc.ContainsKey(produit.Producteur)) acc[produit.Producteur] += res;
                else acc.Add(produit.Producteur, res);
                return acc;
            });
            Console.WriteLine(String.Join(',', res2));

            // 2. Le plus grand, le plus petit et la moyenne de ces chiffres d’affaire
            Console.WriteLine($"{res2.Aggregate(Convert.ToDouble(0), (acc, value) => value.Value > acc ? value.Value : acc)} - {res2.Aggregate(Double.MaxValue, (acc, value) => value.Value < acc ? value.Value : acc)} - {res2.Aggregate(Convert.ToDouble(0), (acc, value) => acc += value.Value, x => x / res2.Count)}");

            // 3. Le marchand ayant le plus de noix à vendre
            Console.WriteLine(listeProduits.Aggregate((producteur: "nothing", nbr: 0), (acc, val) =>
            {
                if (val.Quantite == null || val.NomProduit != "Noix") return acc;

                return acc.nbr > val.Quantite ? acc : (producteur: val.Producteur == null ? "anonyme" : val.Producteur, nbr: Convert.ToInt32(val.Quantite));
            }));

            // 4. Le marchand ayant le plus d’affinités avec ses produits
            int Affinity(string name, string product)
            {
                return name.GroupBy(letter => letter)
                    .Union(product.GroupBy(letter => letter))
                    .Sum(group => group.Count());
            }

            Console.WriteLine(listeProduits.Aggregate((producteur: "nothing", affinity: 0), (acc, val) =>
            {
                int aff = Affinity(val.Producteur, val.NomProduit);
                return acc.affinity > aff ? acc : (producteur: val.Producteur, affinity: aff);
            }));
        }
    }
}