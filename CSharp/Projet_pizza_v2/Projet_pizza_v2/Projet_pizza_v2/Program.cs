using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Projet_pizza_v2
{
    class Program
    {
        // FONCTIONS

        // Récupérer liste pizzas du code ------------------------------------
        static List<Pizza> GetPizzasFromCode()//Les méthodes statiques sont des méthodes que l'on peut appeler sans créer d'instance d'une classe.
        {
            List<Pizza> listePizzas = new List<Pizza>()
                                        {
                                            new Pizza("4 fromages", 11.5f, true, new List<string>(){"mozzarella", "bleu", "chèvre", "gruyère"}),
                                            new Pizza("indienne", 10.5f, false, new List<string>(){"mozzarella", "viande hachée", "poulet", "curry", "poivron", "origan"}),
                                            new Pizza("ROYALE", 13f, false, new List<string>(){"mozzarella", "sauce tomate", "jambon", "champignons", "gruyère"}),
                                            new Pizza("margherita", 8f, true, new List<string>(){"mozzarella", "tomates", "basilic"}),
                                            new Pizza("calzone", 12f, false, new List<string>(){"mozzarella", "tomate", "oignon", "émmental rapé", "oeufs"}),
                                            new Pizza("complète", 9.5f, false, new List<string>(){"mozzarella", "jambon", "oeuf", "fromage"}),
                                            //new PizzaPersonnalisee(),
                                            //new PizzaPersonnalisee()
                                        };
            return listePizzas;
        }

        // Récupérer liste pizzas d'un fichier ------------------------------------
        static List<Pizza> GetPizzasFromFile(string fileName)
        {
            // 1 - Charger données fichier json
            string pizzas = null;
            try
            {
                pizzas = File.ReadAllText(fileName);
            }
            catch
            {
                //Arrêt programme si erreur nom fichier
                Console.WriteLine("Erreur de lecture du fichier : " + fileName);
                return null;
            }

            // 2 - déserialiser -> list<pizza> -> pizza
            List<Pizza> listePizzas = null;
            try
            {
                listePizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzas);
            }
            catch
            {
                //Arrêt programme si erreur données
                Console.WriteLine("Erreur données JSON invalides");
                return null;
            }
            return listePizzas;
        }

        // Récupérer liste pizzas d'une URL ------------------------------------
        static List<Pizza> GetPizzasFromUrl(string url)
        {
            var webClient = new WebClient();
            string pizzasJson = null;
            try
            {
                pizzasJson = webClient.DownloadString(url);
            }
            catch
            {
                Console.WriteLine("Erreur réseau");
                return null;
            }

            List<Pizza> listePizzas = null;
            try
            {
                listePizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzasJson);
            }
            catch
            {
                Console.WriteLine("Erreur données JSON invalides");
                return null;
            }
            return listePizzas;
        }

        //Générer JSON ---------------------------------------------------------
        static void GenerateJsonFile(List<Pizza> listePizzas, string fileName)
        {
            // 1 - pizzas -> sérialiser -> json -> string
            string listePizzasJson = JsonConvert.SerializeObject(listePizzas);

            // 2 - Ecrire dans un fichier texte "pizzas.json"
            File.WriteAllText(fileName, listePizzasJson);
        }

        //----------------------------------------------------------------------

        // CLASS
        class PizzaPersonnalisee : Pizza
        {
            static int nbPizzasPersonnalisee = 0;
            public PizzaPersonnalisee() : base("Personnalisee", 5, false, null)
            {
                nbPizzasPersonnalisee++;
                nom = "Personnalisée " + nbPizzasPersonnalisee;


                ingredients = new List<string>();

                while (true)
                {
                    Console.Write("Rentrez un ingrédient pour la pizza personnalisée " + nbPizzasPersonnalisee + " (ENTER pour terminer) : ");
                    var ingredient = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ingredient))
                    {
                        break;
                    }
                    if (ingredients.Contains(ingredient))
                    {
                        Console.WriteLine("ERREUR : Cet ingrédient est déjà présent dans la pizza.");
                    }
                    else
                    {
                        ingredients.Add(ingredient);
                        Console.WriteLine(string.Join(", ", ingredients));
                    }

                    Console.WriteLine();
                }


                prix = 5 + ingredients.Count * 1.5f;

            }
        }
        class Pizza
        {
            //variables d'instance
            public string nom { get; protected set; }
            public float prix { get; protected set; }
            public bool vegetarienne { get; private set; }
            public List<string> ingredients { get; protected set; }

            //constructeur
            public Pizza(string nom, float prix, bool vegetarienne, List<string> ingredients)
            {
                this.nom = nom;
                this.prix = prix;
                this.vegetarienne = vegetarienne;
                this.ingredients = ingredients;
            }

            //Méthodes
            public void Afficher()
            {
                /*string vegan = "";
                if (this.vegetarienne)
                {
                    vegan = " (V)";
                }*/

                //alternative notation condition if peu volumineuse
                string vegan = this.vegetarienne ? " (V)" : "";
                string nomAfficher = PremiereLettreMajuscule(this.nom);
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine(nomAfficher + vegan + " - " + prix + "€");

                /*Notation basique
                List<string> listIngredientsAfficher = new List<string>();
                foreach(var ingredient in this.ingredients)
                {
                    var ingredientAfficher = PremiereLettreMajuscule(ingredient);
                    listIngredientsAfficher.Add(ingredientAfficher);
                }
                Notation alternative*/
                var listIngredientsAfficher = ingredients.Select(i => PremiereLettreMajuscule(i)).ToList();

                Console.WriteLine(String.Join(", ", listIngredientsAfficher));
                Console.WriteLine();
            }

            private static string PremiereLettreMajuscule(string s)
            {
                /*Notation alternative condition string vide ou null
                if(s == "" || s == null)
                {
                    return s;
                }*/

                if (string.IsNullOrEmpty(s))
                {
                    return s;
                }

                string majuscules = s.ToUpper();
                string minuscules = s.ToLower();

                //string resultat = majuscules[0] + minuscules.Substring(1); //Notation alternative tous caractères à partir de l'index
                string resultat = majuscules[0] + minuscules[1..];
                return resultat;
            }
        }

        // FONCTION PRINCIPALE
        static void Main(string[] Args)
        {
            var fileName = "jsonPizzas.json";

            // Récupère pizzas du code
            //var listePizzas = GetPizzasFromCode();

            // Génère fichier JSON -> "jsonPizzas.json" à partir d'une liste -> List<Pizza>
            //GenerateJsonFile(listePizzas, fileName);

            // Récupère pizzas d'un fichier
            //var listePizzas = GetPizzasFromFile(fileName);

            // Récupère pizzas d'une URL
            var listePizzas = GetPizzasFromUrl("https://codeavecjonathan.com/res/pizzas2.json");

            if(listePizzas != null)
            {
                foreach (var pizza in listePizzas)
                {
                    pizza.Afficher();
                }
            }
            
        }
    }
}
