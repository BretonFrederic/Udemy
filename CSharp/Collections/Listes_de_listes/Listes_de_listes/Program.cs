using System;
using System.ComponentModel.DataAnnotations;

namespace Listes_de_listes
{
    class Program
    {
        /* FONCTIONS */

        static int DemanderNombre(string _question)
        {
            Console.WriteLine(_question);
            try
            {
                int selection = int.Parse(Console.ReadLine());
                    return selection;
            }
            catch
            {
                Console.WriteLine("ERREUR : Vous devez entrer un nombre.");
            }
            return DemanderNombre(_question);
        }
        static int DemanderUnNombreEntre(string _question, int _valeurMin, int _valeurMax)
        {
            int nombre = DemanderNombre(_question);
            if(nombre < _valeurMin || nombre > _valeurMax)
            {
                Console.WriteLine("ERREUR : Choix invalide.");
                return DemanderUnNombreEntre(_question, _valeurMin, _valeurMax);
            }
            else
            {
                return nombre;
            }
        }

        /* FONCTION PRINCIPALE */
        public static void Main(string[] args)
        {

            /* VARIABLES */

            List<string> france = new List<string>() { "France", "Paris", "Toulouse", "Nantes", "Montpellier", "Bordeaux" };
            List<string> etatUnis = new List<string>() { "Etat-unis", "Washington", "New York", "Los Angeles", "Chicago", "San Francisco" };
            List<string> espagne = new List<string>() { "Espagne", "Madrid", "Barcelone", "Malaga", "Séville", "Valence" };
            List<string> japon = new List<string>() { "Japon", "Tokyo", "Yokohama", "Osaka", "Bordeaux", "Nagoya" };

            List<List<string>> pays = new List<List<string>>() { france, etatUnis, espagne, japon };

            List<string> favoris = new List<string>();
            int selectPays = 0;
            int selectVille = 0;
            int selectAjouter = 0;
            bool quitter = false;
            string question = "";

            /* DEBUT PROGRAMME */
            while (!quitter)
            {
                //Demander le choix d'un pays
                question = "Sélectionner un pays : \n\n";
                for (int i = 0; i < pays.Count; i++)
                {
                    question += "   " + (i + 1) + " - " + pays[i][0] + "\n";
                }
                selectPays = DemanderUnNombreEntre(question, 1, pays.Count) - 1;

                //Demander le choix d'une ville
                question = "Sélectionner une ville : \n\n";
                for (int i = 1; i < pays[selectPays].Count; i++)
                {
                    question += "   " + i + " - " + pays[selectPays][i] + "\n";
                }
                selectVille = DemanderUnNombreEntre(question, 1, pays[selectPays].Count - 1);

                //Ajouter ville dans liste de favoris
                question = "Ajouter " + pays[selectPays][selectVille] + " dans vos favoris ? : \n   1 - oui\n   2 - non";
                selectAjouter = DemanderUnNombreEntre(question, 1, 2) - 1;

                if (selectAjouter == 0 && !favoris.Contains(pays[selectPays][selectVille]))
                {
                    favoris.Add(pays[selectPays][selectVille]);
                }
                else
                {
                    Console.WriteLine("Cette ville est déjà dans la liste.\n");
                }

                question = "Continuer à ajouter des villes dans vos favoris ? : \n   1 - oui\n   2 - non";
                selectAjouter = DemanderUnNombreEntre(question, 1, 2) - 1;

                if (selectAjouter == 1)
                {
                    quitter = true;
                }
            }

            //Afficher liste favoris
            Console.WriteLine("Liste des favoris :\n");
            for (int i = 0; i < favoris.Count; i++)
            {
                Console.WriteLine("   "+favoris[i]);
            }

            /* FIN PROGRAMME */
        }
    }
}
