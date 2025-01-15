using System;
using System.ComponentModel;
using System.Net;

namespace AsyncDelegate
{
    class Program
    {
        static bool downloading = false;
        static void Main(string[] args)
        {
            //Fonction Asynchrone ou Call Back
            var webClient = new WebClient();
            string url = "https://codeavecjonathan.com/res/bateau.jpg";
            Console.Write("Téléchargement...");

            downloading = true;
            webClient.DownloadFileCompleted += Webclient_DownloadFileCompleted;
            webClient.DownloadFileAsync(new Uri(url), "bateau.jpg");

            //Boucle qui simule le déroulement du programme tant que le téléchargement n'est pas fini
            while (downloading)
            {
                Thread.Sleep(500);
                //Condition qui permet à 100% de ne plus afficher de point après téléchargement
                if (downloading)
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine("Fin de programme");
        }


        private static void Webclient_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Téléchargement terminé.");
            downloading = false;
        }
    }
}
