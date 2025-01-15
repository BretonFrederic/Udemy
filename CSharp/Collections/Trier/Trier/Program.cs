using System;

namespace Trier
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> listeNoms = new List<string> { "Laura", "Francis", "Justine", "Martin", "Emilie", "Raymond", "Sarah", "Kate" };

            //Fonction .Sort() pour les tableaux Array.Sort(nomDuTableau)
            //Permet de trier par ordre alphabétique ascendant A -> B -> C...
            listeNoms.Sort();

            foreach(var element in listeNoms)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();

            listeNoms = new List<string> { "Laura", "Francis", "Justine", "Martin", "Emilie", "Raymond", "Sarah", "Kate" };

            //Fonction .OrderBy() et tris personnalisé. La fonction retourne un résultat.
            var listeTriee = listeNoms.OrderBy(element => element);//par orde alphabétique
            listeTriee = listeNoms.OrderBy(element => element.Length);//par longueur chaine de caractères
            listeTriee = listeNoms.OrderBy(element => element[element.Length-2]);//par un caractère particulier exemple avant dernier caractère
            listeTriee = listeNoms.OrderByDescending(element => element);//par ordre descendant

            foreach (var element in listeTriee)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();

            //Modifier la liste d'origine ou ToArray() pour un tableau
            listeNoms = listeNoms.OrderBy(element => element).ToList();

            foreach (var element in listeNoms)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
        }
    }
}
