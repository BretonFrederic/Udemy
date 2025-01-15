using System;
using System.Text;

namespace Fichier_performances
{
    class program
    {
        static void Main(string[] args)
        {
            //Ecrire une liste de noms
            string fileName = "fichierPerformances.txt";

            //Immutable création d'une nouvelle string en mémoire à chaque ajout de caractère, lent
            //string texte = "";
            //int nbLignes = 20000;

            //Mutable alloue un gros bloque de mémoire utilisable pour plusieurs tour de boucle autant de fois que nécessaire, rapide

            /*-----------------------------------------------------------------------------------------
            
            DateTime t1 = DateTime.Now; //temps au début de l'itération

            StringBuilder texte = new StringBuilder();
            int nbLignes = 20000000;

            Console.Write("Préparation des données...");

            for (int i = 1; i <= nbLignes; i++)
            {
                texte.Append("Ligne " + i + "\n");
            }

            Console.WriteLine("OK");

            Console.Write("Ecriture des données...");

            File.WriteAllText(fileName, texte.ToString());

            Console.WriteLine("OK");

            DateTime t2 = DateTime.Now; //temps fin itération
            var diff = (int)(t2 - t1).TotalMilliseconds;
            Console.WriteLine("Durée en (ms) : " + diff);

             -----------------------------------------------------------------------------------------*/
            //stream : flux

            DateTime t1 = DateTime.Now; //temps au début de l'itération

            Console.Write("Ecriture des données...");
            int nbLignes = 10000000;

            //using utilisation du stream pour l'instruction donc la boucle puis libérer le stream
            using (var writeStream = File.CreateText(fileName))
            {
                for (int i = 1; i <= nbLignes; i++)
                {
                    writeStream.Write("Ligne " + i + "\n");
                }
            }
            Console.WriteLine("OK");
            DateTime t2 = DateTime.Now; //temps fin itération
            var diff = (int)(t2 - t1).TotalMilliseconds;
            Console.WriteLine("Durée en (ms) : " + diff);

            //Lecture avec un stream si contenu sinon on break, tête de lecture disque
            using (var readStream = File.OpenText(fileName))
            {
                while (true)
                {
                    var line = readStream.ReadLine();
                    if(line == null)
                    {
                        break;
                    }
                    Console.WriteLine(line);
                }
            }

            //Gestion d'exceptions fichierNoms.txt
            /*try
            {
                //Afficher chaque string de la liste
                var result2 = File.ReadAllLines(fileName);
                foreach (string nom in result2)
                {
                    Console.WriteLine(nom);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Erreur ce fichier n'existe pas (" + ex.Message + ")");
            }
            catch
            {
                Console.WriteLine("Une erreur inconnue est arrivée");
            }*/

        }
    }
}
