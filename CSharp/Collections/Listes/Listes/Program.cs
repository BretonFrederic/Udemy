using System;
using System.ComponentModel;

namespace Listes
{
    class Program
    {
        /* FONCTIONS */

        static void liste()
        {
            /*List<string> listeNoms = new List<string>();

            while (true)
            {
                Console.Write("Entrer un nom (Appuyer sur enter pour finir): ");
                string nom = Console.ReadLine();
                if (nom == "")
                {
                    break;
                }
                listeNoms.Add(nom);
            }
            //Filtrer : Supprimer les noms qui terminent par le caractère 'e'
            for (int i = listeNoms.Count - 1; i >=0; i--)
            {
                if (listeNoms[i][listeNoms[i].Length-1] == 'e')
                {
                    listeNoms.RemoveAt(i);
                }
            }
            AfficherListe(listeNoms, true);*/
            //Afficher les noms en communs des 2 listes
            List<string> liste1 = new List<string>() { "Paul", "Marc", "Emilie", "Edouard", "Luc", "Sophie" };
            List<string> liste2 = new List<string>() { "Paul", "Quentin", "Emilie", "Francis", "Luc", "Jean" };
            AfficherElementCommun(liste1, liste2);


        }
        static void AfficherListe(List<string> _liste, bool _ordreDescendant)
        {
            Console.WriteLine("\nLaliste des noms est : \n");
            if(!_ordreDescendant)
            {
                for (int i = 0; i < _liste.Count; i++)
                {
                    Console.WriteLine("     - " + _liste[i]);
                }
            }
            else
            {
                for (int i = _liste.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine("     " + _liste[i]);
                }
            }
            //Afficher le nom le plus grand
            /*string nomPlusGrand = _liste[0];
            for (int i = 0; i < _liste.Count; i++)
            {
                if(nomPlusGrand.Length < _liste[i].Length)
                {
                    nomPlusGrand = _liste[i];
                }
            }
            Console.WriteLine("\nLe nom le plus grand de la liste est : " + nomPlusGrand);*/
        }

        static void AfficherElementCommun(List<string> _liste1, List<string> _liste2)
        {
            List<string> liste3 = new List<string>();
            for (int i = 0; i < _liste1.Count; i++)
            {
                if (_liste2.Contains(_liste1[i]))
                {
                    Console.WriteLine(_liste1[i]);
                }
            }
        }

        /* FONCTION PRINCIPALE */
        public static void Main(string[] args)
        {
            liste();
        }
    }
}
