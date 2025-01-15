using System;
using System.Globalization;

namespace ProgrammeDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Now;

            //Afficher le format souhaité quel que soit le système, fr, en, etc...

            CultureInfo formatDate = CultureInfo.GetCultureInfo("fr_FR");
            //CultureInfo formatDate = CultureInfo.GetCultureInfo("en_US");

            //différentes possibilités de format d'affichage avec la chaîne en paramètre
            Console.WriteLine(date.ToString("dddd dd MMMM yyyy HH:mm:ss", formatDate));

            //Ajoute des jours à la date actuelle
            DateTime dateDemain = date.AddDays(1);

            Console.WriteLine("Demain : " + dateDemain.ToString("dddd dd MMMM yyyy HH:mm:ss", formatDate));

            var diff = dateDemain - date;

            Console.WriteLine("Différence nombre d'heure(s) : " + diff.TotalHours);
        }
    }
}
