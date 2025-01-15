using System;
using FormationCS;

namespace FormationCS
{
    class Program
    {
        /* FONCTIONS */

        static bool DemanderChoixBinaire(string _question)
        {
            string choix = "";
            Console.WriteLine(_question);
            Console.Write("Entrer O pour oui ou N pour non : ");
            choix = Console.ReadLine();
            Console.WriteLine();
            if (choix.Equals("o", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (choix.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                Console.WriteLine("ERREUR : Choix invalide.");
                return DemanderChoixBinaire(_question);
            }
        }
        static string GenererMotPasse()
        {
            //Demande choisir longueur mot de passe
            int longueurMotPasse = outils.DemanderNombrePositifNonNul("Longueur du mot de passe : ");

            //Différentes chaines des choix de caractères possible
            string alphabetMin = "abcdefghijklmnopqrstuvwxyz";
            string alphabetMaj = alphabetMin.ToUpper();
            string caractereNombre = "0123456789";
            string caractereSpeciaux = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            string alphabet = "";

            //Choix des caractères du mot de passe
            bool ajouterMin = DemanderChoixBinaire("Mot de passe avec minuscules ?");
            if (ajouterMin)
            {
                alphabet += alphabetMin;
            }
            bool ajouterMaj = DemanderChoixBinaire("Mot de passe avec majuscules ?");
            if (ajouterMaj)
            {
                alphabet += alphabetMaj;
            }
            bool ajouterNb = DemanderChoixBinaire("Mot de passe avec nombres ?");
            if (ajouterNb)
            {
                alphabet += caractereNombre;
            }
            bool charSpeciaux = DemanderChoixBinaire("Mot de passe avec caractères spéciaux ?");
            if (charSpeciaux)
            {
                alphabet += caractereSpeciaux;
            }

            //Génération mot de passe
            string motDePasse = "";
            Random aleatoire = new Random();
            while(motDePasse.Length < longueurMotPasse)
            {
                for (int i = 0; i < longueurMotPasse; i++)
                {
                    int nbAleatoire = aleatoire.Next(alphabet.Length);

                        motDePasse += alphabet[nbAleatoire];
                }
            }
            return motDePasse;
        }

        /* FONCTION PRINCIPALE */
        static void Main(string[] args)
        {
            bool quitter = false;
            while (!quitter)
            {

                //Générer et afficher le mot de passe
                string motDePasse = GenererMotPasse();
                Console.WriteLine("Mot de passe : " + motDePasse + "\n");

                //Continuer ou quitter
                Console.WriteLine("Appuyer sur q pour quitter ou n'importe quelle touche pour continuer.");
                string quitterStr = Console.ReadLine();

                if (quitterStr.Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    quitter = true;
                }
            }

        }
    }
}
