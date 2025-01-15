using System;

namespace BoucleForEach
{
    class Program
    {
        public static void Main(string[] args)
        {
            //foreach tableau
            string[] noms = new string[] {"Raymond", "Sarah", "Kate"};

            //foreach parcours la collection
            Console.WriteLine("[Tableau]");
            foreach (var nom in noms)
            {
                Console.WriteLine(nom);
            }
            Console.WriteLine();

            //foreach list
            List<string> listeNoms = new List<string> { "Laura", "Francis", "Justine", "Martin" };
            Console.WriteLine("[Liste]");
            foreach (var nom in listeNoms)
            {
                Console.WriteLine(nom);
            }
            Console.WriteLine();

            var dictionnaire = new Dictionary<string, string>();

            dictionnaire.Add("Jean", "+33628153467");
            dictionnaire.Add("Henry", "+33652439481");
            dictionnaire.Add("Marie", "+33665483518");
            dictionnaire.Add("Edouard", "+33656841835");
            Console.WriteLine("[Dictionnaire]");
            foreach (var element in dictionnaire)
            {
                Console.WriteLine("Clef : "+element.Key+" - Valeur : "+element.Value);
            }
        }
    }
}
