using System;

namespace InitOnlyProperties
{
    internal class Program
    {
        class Personne
        {
            // Assigner la valeur à la construction du projet
            public string nom { get; init; }
            public int age { get; set; }

            public void Afficher()
            {
                Console.WriteLine("nom : " + nom + " - age : " + age + " ans");
            }
        }
        static void Main(string[] args)
        {
            var personne1 = new Personne() { nom = "toto", age = 20 }; // Pas obligé de créer un constructeur, on peut garder cette syntaxe
            // personne1.nom = "tata";
            personne1.Afficher();
            Console.WriteLine("nom de la personne1 : " + personne1.nom);
        }
    }
}
