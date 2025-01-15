using System;
using System.Net;

namespace programme_reseau_erreurs
{
    class program
    {
        static void Main(string[] args)
        {
            string url = "https://codeavec_jonathan.com/res/pizzass1.json";

            var webClient = new WebClient();

            Console.WriteLine("Accès réseau...");

            try
            {
                string reponse = webClient.DownloadString(url);
                Console.WriteLine(reponse);
            }
            catch(WebException ex)
            {
                if(ex.Response != null)
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
