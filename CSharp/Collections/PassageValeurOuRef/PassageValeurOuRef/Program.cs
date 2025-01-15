using System;

namespace PassageValeurOuRef
{
    class Program
    {
        /* FONCTIONS */

        static void MaFonction1(int _nb)
        {
            _nb = 50;
            Console.WriteLine("Passage par valeur (reste locale à la fonction void): "+_nb);
        }
        static void MaFonction2(List<int> _nombres)
        {
            _nombres[0] = 20;
        }

        static void MaFonction3(out int _nb)
        {
            _nb = 50;
        }

        /* FONCTION PRINCIPALE */
        public static void Main(string[] args)
        {
            int nombreA = 3;
            Console.WriteLine(nombreA);

            MaFonction1(nombreA);

            Console.WriteLine("Appel de la fonction void dans Main. La valeur reste inchagée : "+nombreA);

            //Modification du contenu d'une liste par référence avec fonction void
            //On modifie la collection et pas une variable locale à la fonction
            List<int> liste = new List<int>() { 5, 8, 12 };

            Console.WriteLine("Liste avant appel de la fonction void : "+liste[0]);

            MaFonction2(liste);

            Console.WriteLine("Liste après appel de la fonction void : " + liste[0]);

            //Mot clef out
            int nombreB = 18;
            Console.WriteLine("Nombre avant appel de la fonction void mot clef out : " + nombreB);

            MaFonction3(out nombreB);//Passage par référence

            Console.WriteLine("Nombre après appel de la fonction void mot clef out : " + nombreB);

            //La fonction .TryParse() renvoye une boolean et modifie la valeur par référence après un try catch
            Console.WriteLine("Utilisation TryParse() modifie la valeur par référence après un try catch.");
            int nombreC = 0;
            Console.WriteLine("nombreC : "+nombreC);
            Console.WriteLine("Entrer un nombre: ");
            string nombreUtilisateur = "";
            nombreUtilisateur = Console.ReadLine();
            if(int.TryParse(nombreUtilisateur, out nombreC)){
                Console.WriteLine("Le nombreC a bien été modifié : "+nombreC);
            }
            else
            {
                Console.WriteLine("ERREUR : La valeur saisie n'est pas un nombre.");
            }

        }
    }
}
