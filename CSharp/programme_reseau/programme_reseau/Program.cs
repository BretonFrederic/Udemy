using System;
using System.Net;
using static System.Net.WebRequestMethods;

namespace programme_reseau
{
    class program
    {
        static void Main(string[] args)
        {
            //string url = "https://codeavecjonathan.com/res/exemple.html";//extension .html récupère code html
            //string url = "https://codeavecjonathan.com/res/exemple.txt";//extension .txt récupère texte
            string url = "https://codeavecjonathan.com/res/pizzas1.json";//extension .json récupère json (sérialisé)

            //Synchrone attend que l'instruction soit fini pour continuer le programme
            var webClient = new WebClient();

            //Download des contenus de pages au format texte
            string reponse = webClient.DownloadString(url);

            Console.WriteLine("Accès réseau...");
            Console.WriteLine(reponse);
        }
    }
}
