using Newtonsoft.Json;
using System;

namespace programme_json
{
    class Personne
    {
        public string nom { get; private set; }
        public int age { get; private set; }
        public bool majeur { get; private set; }

        public Personne(string nom,int age, bool majeur)
        {
            this.nom = nom;
            this.age = age;
            this.majeur = majeur;
        }
        public void Afficher()
        {
            Console.WriteLine(" - Nom : " + this.nom + " - Age : " + this.age + "ans");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            /*Personne personne1 = new Personne("toto", 20, true);

            personne1.Afficher();

            //Sérialisation d'un objet
            string jsonToto = JsonConvert.SerializeObject(personne1);
            Console.WriteLine(jsonToto);

            //Déserialisation d'un json
            string jsonTiti = "{\"nom\":\"titi\",\"age\":15,\"majeur\":false}";
            Personne titi  = JsonConvert.DeserializeObject<Personne>(jsonTiti);

            titi.Afficher();*/

            //--------------------------------------------------------------------------------------------------------

            //1 - créer liste de personnes
            List<Personne> visiteurs = new List<Personne>() { 
                new Personne("Greg", 32, true),
                new Personne("Sophie", 17, false),
                new Personne("Mathilde", 32, true),
                new Personne("Damien", 15, false)
            };

            //2 - Sérialiser
            string jsonVisiteurs = JsonConvert.SerializeObject(visiteurs);

            Console.WriteLine(jsonVisiteurs);

            //3 - Ecrire json dans fichier texte
            var path1 = "json";
            Directory.CreateDirectory(path1);

            string nameFile1 = "fichierJson.txt";
            string pathAndFile1 = Path.Combine(path1, nameFile1);

            File.WriteAllText(pathAndFile1, jsonVisiteurs);

            //-------------------------------------------------------------------------------------------------------

            //1 - Lire json à partir du fichier personnesJson.txt
            string nameFile2 = "personnesJson.txt";
            string pathAndFile2 = Path.Combine(path1, nameFile2);
            string listePresonnes = File.ReadAllText(pathAndFile2);

            Console.WriteLine(listePresonnes);

            //2 - Créer personnes à partir du json (déserialiser)
            var visiteurs2 = JsonConvert.DeserializeObject<List<Personne>>(listePresonnes);

            //3 - Afficher les personnes
            foreach(var v in visiteurs2)
            {
                v.Afficher();
            }
        }
    }
}
