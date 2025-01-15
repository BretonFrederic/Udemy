using System;
using System.Linq;
using AsciiArt;

namespace Jeu_du_pendu
{
    class Program
    {
        /* FONCTIONS */

        static bool DemanderRejouer()
        {
            var reponse = ' ';
            Console.Write("Voulez-vous rejouer ?(o/n) ");
            reponse = DemanderUneLettre();
            if (reponse == 'O' || reponse == 'o')
            {
                return true;
            }
            else if (reponse == 'N' || reponse == 'n')
            {
                return false;
            }
            else
            {
                Console.WriteLine("Erreur : vous devez entrer o(oui) ou n(non)");
                return DemanderRejouer();
            }
        }

        static string[] ChargerLesMots(string _nomFichier)
        {
            try
            {
                return File.ReadAllLines(_nomFichier);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erreur de lecture du fichier" + _nomFichier + " (" + ex.Message + ")");
            }
            return null;
        }
        static bool ToutesLettresTrouvees(string _mot, List<char> _lettresTrouvees)
        {
            foreach(char lettre in _lettresTrouvees)
            {
                _mot = _mot.Replace(lettre.ToString(), "");
            }
            if (_mot.Length == 0)
            {
                return true;
            }
            return false;
        }
        static void DevinerMot(string _mot)
        {
            var lettresTrouvees = new List<char>();
            var lettresInvalides = new List<char>();
            const int NB_VIES = 6;
            int viesRestantes = NB_VIES;

            while (viesRestantes > 0)
            {
                Console.WriteLine(Ascii.PENDU[NB_VIES-viesRestantes]);
                Console.WriteLine();
                AfficherMot(_mot, lettresTrouvees);
                Console.WriteLine();
                
                char lettreUtilisateur = DemanderUneLettre();

                    Console.Clear();
                if (_mot.Contains(lettreUtilisateur))
                {
                    lettresTrouvees.Add(lettreUtilisateur);
                    Console.WriteLine("Cette lettre est dans le mot.");
                    if (ToutesLettresTrouvees(_mot, lettresTrouvees))
                    {
                        break;
                    }
                }
                else
                {
                    if (!lettresInvalides.Contains(lettreUtilisateur))
                    {
                        lettresInvalides.Add(lettreUtilisateur);
                        viesRestantes--;
                    }
                    
                    Console.WriteLine("Il vous reste : " + viesRestantes + " vie(s).");
                }
                if(lettresInvalides.Count > 0)
                {
                    Console.WriteLine("Le mot ne contient pas les lettres : " + string.Join(", ", lettresInvalides));
                }
                Console.WriteLine();
            }
            Console.WriteLine(Ascii.PENDU[NB_VIES - viesRestantes]);
            if (viesRestantes == 0)
            {
                Console.WriteLine("Perdu !");
                Console.WriteLine("Le mot était : " + _mot);
            }
            else
            {
                AfficherMot(_mot, lettresTrouvees);
                Console.WriteLine();
                Console.WriteLine("Gagné !");
            }
        }
        static char DemanderUneLettre()
        {
            char lettreUtilisateur;
            bool conversion = false;
            while (true)
            {
                Console.Write("Entrer une lettre : ");
                conversion = char.TryParse(Console.ReadLine().ToUpper(), out lettreUtilisateur);
                if (!conversion)
                {
                    Console.WriteLine("ERREUR : Vous devez entrer une lettre.");
                }
                else
                {
                    return lettreUtilisateur;
                }
            }
        }
        static void AfficherMot(string _mot, List<char> _lettres)
        {
            for(int i = 0; i < _mot.Length; i++)
            {
                if (_lettres.Contains(_mot[i]))
                {
                    Console.Write(_mot[i]+" ");
                }
                else
                {
                    Console.Write("- ");
                }
            }
            Console.WriteLine();
        }

        /* FONCTION PRINCIPALE */
        public static void Main(string[] args)
        {
            Random r = new Random();
            string[] mots = ChargerLesMots("mots.txt");
            if(mots == null || mots.Length == 0)
            {
                Console.WriteLine("La liste de mots est vide");
            }
            else
            {
                bool rejouer = false;
                do
                {
                    var index = r.Next(mots.Length);
                    string mot = mots[index].Trim().ToUpper();
                    DevinerMot(mot);
                    rejouer = DemanderRejouer();
                    Console.Clear();
                } while (rejouer);
                Console.WriteLine("Fin de partie, à bientôt !");
            }
        }
    }
}
