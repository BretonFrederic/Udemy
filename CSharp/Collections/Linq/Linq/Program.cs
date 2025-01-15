using System;

namespace Linq
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> listeNoms = new List<string> { "Laura", "Francis", "Justine", "Martin", "Emilie", "Raymond", "Sarah", "Kate", "Charles" };

            listeNoms = listeNoms.OrderBy(element => element).ToList();

            //Sélectionner les éléments du nom qui correspondent à un critère
            listeNoms = listeNoms.Where(element => element.Length > 5).ToList();

            foreach(var element in listeNoms)
            {
                Console.WriteLine(element);
            }

            //Utilisation avec les nombres
            var notes = new List<int>() { 5, 9, 3, 7, 6, 8, 2 };

            notes = notes.OrderBy(element => element).ToList();

            //Sélectionner les nombres qui correspondent à un critère
            notes = notes.Where(element => element > 5).ToList();

            foreach (var element in notes)
            {
                Console.WriteLine(element);
            }
        }
    }
}
