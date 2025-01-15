using System;

namespace Dictionnaire
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Dictionary
            //Clef -> valeur
            //nom numéro
            //Pas besoin de boucle pour chercher un numéro

            var dictionnaire = new Dictionary<string, string>();
            string personneAChercher = "Edouard";

            //Méthode 1 pour ajouter valeur
            dictionnaire.Add("Jean", "+33628153467");
            dictionnaire.Add("Henry", "+33652439481");

            //Méthode 2 pour ajouter valeur
            dictionnaire["Marie"] = "+33665483518";
            dictionnaire["Edouard"] = "+33656841835";

            Console.WriteLine(dictionnaire["Marie"]);

            //Gestion erreur de clef ou affichage de la valeur si la clef existe
            if (dictionnaire.ContainsKey(personneAChercher))
            {
                Console.WriteLine(dictionnaire[personneAChercher]);
            }
            else
            {
                Console.WriteLine("Cette personne n'est pas dans le dictionnaire.");
            }
        }
    }
}
