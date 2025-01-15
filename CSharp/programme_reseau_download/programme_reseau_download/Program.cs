using System;
using System.Net;

namespace programme_reseau_download
{
    class program
    {
        static void Main(string[] args)
        {
            string url = "https://codeavecjonathan.com/res/papillon.jpg";

            var webClient = new WebClient();

            Console.WriteLine("Accès réseau...");

            try
            {
                //Téléchargement image synchrone
                webClient.DownloadFile(url, "papillon.jpg");
                Console.WriteLine("Téléchargement terminé");
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                    if (statusCode == HttpStatusCode.NotFound)
                    {
                        //Erreur accès fichier
                        Console.WriteLine("ERREUR RESEAU : Non trouvé");
                    }
                    else
                    {
                        //Erreur accès serveur
                        Console.WriteLine("ERREUR RESEAU : " + statusCode);
                    }
                }
                else
                {
                    //Erreur syntaxe
                    Console.WriteLine("ERREUR RESEAU : " + ex.Message);
                }

            }
        }
    }
}

