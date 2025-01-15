using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS
{
    static class outils
    {
        /* FONCTIONS */

        public static int DemanderNombre(string _question)
        {
            int nombre = 0;
            while (true)
            {
                try
                {
                    //Tester si valeur numérique
                    Console.Write(_question);
                    nombre = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    return nombre;
                }
                catch
                {
                    Console.WriteLine("ERREUR : La valeur n'est pas un nombre.");
                }
            }
        }
        public static int DemanderNombreEntre(string _question, int _min, int _max, string _messageErreurPersonnalise)
        {
            int nombre = 0;

            nombre = DemanderNombre(_question);
            if (nombre >= _min && nombre <= _max)
            {
                return nombre;
            }
            else
            {
                if(_messageErreurPersonnalise != null)
                {
                    Console.WriteLine(_messageErreurPersonnalise);
                }
                else
                {
                    Console.WriteLine("Vous devez choisir un nombre entre " + _min + " et " + _max + ".");
                }
                return DemanderNombreEntre(_question, _min, _max, _messageErreurPersonnalise);
            }
        }

        public static int DemanderNombrePositifNonNul(string _question)
        {
            return DemanderNombreEntre(_question, 1, int.MaxValue, "ERREUR : Vous devez entrer un nombre positif non nul.");
        }
    }
}
