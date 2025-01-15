using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace programme_fichiers
{
    class program
    {
        static void Main(string[] args)
        {
            //Ecrire et sauvegarder dans un chemin existant
            var path1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName4 = "monFichier4.txt";
            string pathAndFile1 = Path.Combine(path1, fileName4);
            File.WriteAllText(pathAndFile1, "texte sauvegardé dans un chemin spécifique");
            Console.WriteLine(pathAndFile1);

            //Créer un répertoire écrire et sauvegarder
            var path2 = "out";
            Directory.CreateDirectory(path2);
            string fileName5 = "monFichier5.txt";
            string pathAndFile2 = Path.Combine(path2, fileName5);
            File.WriteAllText(pathAndFile2, "texte sauvegardé dans un répertoire créé");
            Console.WriteLine(pathAndFile2);

            //Ecrire ou écraser le contenu
            string fileName1 = "monFichier.txt";
            File.WriteAllText(fileName1, "Voici mon premier texte que j'écris dans monFichier.txt");

            //Rajouter du texte
            File.AppendAllText(fileName1, " Je rajoute du texte.");
            File.AppendAllText(fileName1, " Je rajoute du texte.");

            //Ecrire une liste de noms
            string fileName2 = "fichierNoms.txt";
            var noms = new List<string>() 
            { "Paul", 
              "Henry", 
              "Grégoire" 
            };

            File.WriteAllLines(fileName2, noms);

            //Gestion d'exceptions monFichier.txt
            try
            {
                //afficher le texte
                string result1 = File.ReadAllText(fileName1);
                Console.WriteLine(result1);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Erreur ce fichier n'existe pas (" + ex.Message + ")");
            }
            catch
            {
                Console.WriteLine("Une erreur inconnue est arrivée");
            }

            //Gestion d'exceptions fichierNoms.txt
            try
            {
                //Afficher chaque string de la liste
                var result2 = File.ReadAllLines(fileName2);
                foreach(string nom in result2)
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
            }

            // Gestion de fichier existant ou pas
            var path3 = "out";

            //le dossier est créer si il n'existe pas
            if(!Directory.Exists(path3))
            {
                Directory.CreateDirectory(path3);
            }
            
            string fileName6 = "monFichier6.txt";
            string fileName7 = "monFichier6_copie.txt";

            string pathAndFile3 = Path.Combine(path3, fileName6);
            string pathAndFile4 = Path.Combine(path3, fileName7);

            File.WriteAllText(pathAndFile3, "Le dossier est créer si il n'existe pas, le fichier est créer ou écrasé si il existe.");
            Console.WriteLine(pathAndFile3);

            if (File.Exists(pathAndFile3))
            {
                Console.WriteLine("Le fichier existe déjà, on va écraser son contenu.");
            }
            else
            {
                Console.WriteLine("Le fichier n'existe pas on va le créer.");
            }

            //Copier fichier
            //File.Copy(pathAndFile3, pathAndFile4);

            //Supprimer fichier
            //File.Delete(pathAndFile4);

            //Renommer ou déplacer dans un nouveau répertoire
            //File.Move(pathAndFile3, pathAndFile4);
        }
    }
}
