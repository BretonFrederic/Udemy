using System;

namespace Generateur_phrases_aleatoires
{
    class Program
    {
        /* FONCTIONS */

        static string ObtenirElementAleatoire(string[] _tableau)
        {
            Random aleatoire = new Random();
            return _tableau[aleatoire.Next(_tableau.Length)];
        }

        /* FONCTION PRINCIPALE */
        public static void Main(string[] args)
        {
            var sujets = new string[] {"Un lapin",
                                      "Un grand-mère",
                                      "Un chat",
                                      "Un bonhomme de neige",
                                      "Une fée",
                                      "Une limace",
                                      "Un magicien",
                                      "Une tortue"};

            var verbes = new string[] {"mange",
                                      "détruit",
                                      "écrase",
                                      "observe",
                                      "attrape",
                                      "regarde",
                                      "avale",
                                      "nettoie",
                                      "se bat avec",
                                      "s'accroche à"};

            var complements = new string[] {"un arbre",
                                            "un livre",
                                            "la lune",
                                            "le soleil",
                                            "un serpent",
                                            "une carte",
                                            "une girafe",
                                            "le ciel",
                                            "une piscine",
                                            "un gâteau",
                                            "une souris",
                                            "un crapaud"};

            const int NB_PHRASES = 100;
            /*
            for(int i = 0; i <= NB_PHRASES; i++)
            {
                var sujet = ObtenirElementAleatoire(sujets);
                var verbe = ObtenirElementAleatoire(verbes);
                var complement = ObtenirElementAleatoire(complements);
                var phrase = sujet + " " + verbe + " " + complement + ".";
                phrase = phrase.Replace("à le", "au");//Remplacer dans cas spécial -> s'accroche à le soleil par s'accroche au soleil 
                Console.WriteLine(phrase);
            }*/

            var phrasesUniques = new List<string>();
            int nombreDoublons = 0;

            while(phrasesUniques.Count < NB_PHRASES)
            {
                var sujet = ObtenirElementAleatoire(sujets);
                var verbe = ObtenirElementAleatoire(verbes);
                var complement = ObtenirElementAleatoire(complements);
                var phrase = sujet + " " + verbe + " " + complement + ".";
                phrase = phrase.Replace("à le", "au");//Remplacer dans cas spécial -> s'accroche à le soleil par s'accroche au soleil
                if (!phrasesUniques.Contains(phrase))
                {
                    phrasesUniques.Add(phrase);
                }
                else
                {
                    nombreDoublons++;
                }
            }

            foreach(string maPhrase in phrasesUniques)
            {
                Console.WriteLine(maPhrase);
            }
            Console.WriteLine();
            Console.WriteLine("Nombre de phrases uniques : " + phrasesUniques.Count);
            Console.WriteLine("doublons évités : " + nombreDoublons);
        }
    }
}
