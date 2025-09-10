using Newtonsoft.Json;
using System.ComponentModel;

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

        public enum Categories
        {
            NA,
            Faible,
            Normal,
            Eleve
        }
       ;

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

            Func<string, string> AnonymiseName = name => name.First() + name.Length.ToString() + name.Last();

            var i18n = new Dictionary<string, string>()
                {
                    { "Pommes","Apples"},
                    { "Poires","Pears"},
                    { "Pastèques","Watermelons"},
                    { "Melons","Melons"},
                    { "Noix","Nuts"},
                    { "Raisin","Grapes"},
                    { "Pruneaux","Plums"},
                    { "Myrtilles","Blueberries"},
                    { "Groseilles","Berries"},
                    { "Tomates","Tomatoes"},
                    { "Courges","Pumpkins"},
                    { "Pêches","Peaches"},
                    { "Haricots","Beans"}
                };


            Func<string, string> TranslateProductName = productName => i18n.ContainsKey(productName) ? i18n[productName] : productName;



            Func<int?, Categories> CategorizeProduct = stock =>
                {
                    if (stock == null) return Categories.NA;
                    else if (stock < 10) return Categories.Faible;
                    else if (stock <= 15) return Categories.Normal;
                    else return Categories.Eleve;
                };

            Func<double, double, double> CalculeCA = (qty, price) => qty * price;

            Func<double, Categories, double> CalculePrice = (basePrice, category) =>
            {
                switch (category)
                {
                    case Categories.Faible:
                        return basePrice * 1.15;
                    case Categories.Normal:
                        return basePrice * 1.05;
                    default:
                        return basePrice;
                }
            };


            var livrable1 = listeProduits.Select(x =>
            {
                var category = CategorizeProduct(x.Quantite);
                var ca = CalculeCA(Convert.ToDouble(x.Quantite), Convert.ToDouble(x.PrixParUnite));
                return (
                    seller: x.Producteur == null ? "" : AnonymiseName(x.Producteur),
                    product: x.NomProduit == null ? "" : TranslateProductName(x.NomProduit),
                    Category: category,
                    price: CalculePrice(Convert.ToDouble(x.PrixParUnite), category),
                    CA: ca,
                    rentabilite : ca > 100 ? "Premium" : "Standard"

                );
            }).ToList();

            Console.WriteLine($"{"Seller",15} | {"Product",15} | {"CA",15} | {"Category",15} | {"Indicateur de Rentabilité",15}");
            Console.WriteLine(new String('=', Console.WindowWidth));
            livrable1.ForEach(x => Console.WriteLine($"{x.seller,15} | {x.product,15} | {x.CA,15} | {"Stock " + x.Category.ToString(),15} | {x.rentabilite,15}"));

            List<string> json = new();

            json.Add("[");
            json.AddRange(livrable1.Select(x => $"{{ \"Seller\" : \"{x.seller}\", \"Product\" : \"{x.product}\", \"CA\" : \"{x.CA}\", \"Category\" : \"{x.Category}\"}}, \"Indicateur de Rentabilité\" : \"{x.rentabilite}\"}},"));  // TODO : Enlever derniere ,
            json.Add("]");

            File.WriteAllLines("export.json", json);

        }
    }
}