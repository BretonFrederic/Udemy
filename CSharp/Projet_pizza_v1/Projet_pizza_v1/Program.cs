using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projet_pizza_v1
{
    class Program
    {
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
            protected string nom;
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
        static void Main(string[] Args)
        {
            //class Pizza
            //nom(4 fromages)
            //prix 11.5
            //vegetarienne(vrai ou faux)
            //constructeur
            //Afficher
            //4 fromages (V) - 11.5€
            //créer une liste de pizzas
            //boucler pour afficher les pizzas

            List<Pizza> listePizzas = new List<Pizza>() 
                                        { 
                                            new Pizza("4 fromages", 11.5f, true, new List<string>(){"mozzarella", "bleu", "chèvre", "gruyère"}),
                                            new Pizza("indienne", 10.5f, false, new List<string>(){"mozzarella", "viande hachée", "poulet", "curry", "poivron", "origan"}),
                                            new Pizza("ROYALE", 13f, false, new List<string>(){"mozzarella", "sauce tomate", "jambon", "champignons", "gruyère"}),
                                            new Pizza("margherita", 8f, true, new List<string>(){"mozzarella", "tomates", "basilic"}),
                                            new Pizza("calzone", 12f, false, new List<string>(){"mozzarella", "tomate", "oignon", "émmental rapé", "oeufs"}),
                                            new Pizza("complète", 9.5f, false, new List<string>(){"mozzarella", "jambon", "oeuf", "fromage"}),
                                            new PizzaPersonnalisee(),
                                            new PizzaPersonnalisee()
                                        };
            //Tri prix ordre croissant
            //listePizzas = listePizzas.OrderBy(p => p.prix).ToList();

            //Tri prix ordre décroissant
            //listePizzas = listePizzas.OrderByDescending(p => p.prix).ToList();

            Pizza pizzaMoinsCher = null;
            Pizza pizzaPlusCher = null;
            for (int i = 0; i < listePizzas.Count-1; i++)
            {
                if (listePizzas[i].prix < listePizzas[i + 1].prix)
                {
                    pizzaMoinsCher = listePizzas[i];
                }
                if (listePizzas[i].prix > listePizzas[i + 1].prix)
                {
                    pizzaPlusCher = listePizzas[i];
                }
            }

            Console.Write("La pizza la moins chère est : ");
            pizzaMoinsCher.Afficher();
            Console.Write("La pizza la plus chère est : ");
            pizzaPlusCher.Afficher();
            Console.WriteLine();
            Console.WriteLine("         ----------         ");
            Console.WriteLine();
            Console.WriteLine();

            //Afficher uniquement pizzas végétariennes
            //listePizzas = listePizzas.Where(p => p.vegetarienne == true).ToList();

            //Afficher uniquement pizzas qui contiennent de la tomate
            listePizzas = listePizzas.Where(p => p.ingredients.Where(i => i.ToLower().Contains("tomate")).ToList().Count > 0).ToList();

            foreach (var pizza in listePizzas)
            {
                pizza.Afficher();
            }
        }
    }
}
