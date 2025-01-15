using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args) // <- Fonction Main de type async et de classe Task
        {
            // URL des fichiers à télécharger
            string url1 = "https://codeavecjonathan.com/res/dummy.txt";
            string url2 = "https://codeavecjonathan.com/res/pizzas1.json";

            Console.Write("Téléchargement...");
            var displayTask = DisplayProgress();
            var downloadTask1 = DownloadData(url1);
            var downloadTask2 = DownloadData(url2);

            // await downloadTask1;
            // await downloadTask2;

            await Task.WhenAll(downloadTask1, downloadTask2);

            Console.WriteLine("FIN DE PROGRAMME");

            static async Task DownloadData(string url)
            {
                var httpClient = new HttpClient();
                


                var resultat = await httpClient.GetStringAsync(url);


                Console.WriteLine("OK -> " + url);

                Console.WriteLine(resultat);
            }

            static async Task DisplayProgress()
            {
                while (true)
                {
                    await Task.Delay(500);
                    Console.Write(".");
                }
            }
        }
    }
}
