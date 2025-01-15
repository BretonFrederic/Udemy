using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace programme_poo
{
    class Personne
    {
        //Variable de class
        private static int nombrePersonnes;//static variable commune à toutes les instances

        //variable d'instance
        public string nom { get; init; }//propriété avec initialisation (définitive) à la construction

        //les propriétés sont aussi utilisées comme fonctions. On déclare alors une variable _age pour stocker la valeur.
        private int _age;
        public int age 
        { 
            get
            {
                return _age;   
            } 
            set 
            {
                if(value >= 0)
                {
                    _age = value;
                }
            } 
        }
        public string emploi { get; set; }
        private int numeroPersonne = 0;

        //Constructeurs
        public Personne()
        {
            nombrePersonnes++;
            this.numeroPersonne = nombrePersonnes;
        }
        public Personne(string nom, int age, string emploi = null) : this()//On utilise le constructeur par défault et celui avec paramètres.
        {
            this.nom = nom;
            this.age = age;
            this.emploi = emploi;
        }

        /*Constructeur qui fait référence au premier. Dernier paramètre modifié.
        public Personne(string _nom, int _age) : this(_nom, _age, "non spécifié")
        {

        }*/

        //Méthodes static (utiliser avec la class Personne.AfficherPersonnes();)
        public static void AfficherNombrePersonnes()
        {
            Console.WriteLine("Nombre total de personnes : " + nombrePersonnes);
        }

        //méthodes
        public void Afficher()
        {
            Console.WriteLine("Personne N° " + numeroPersonne);
            Console.WriteLine("  NOM : " + nom);
            Console.WriteLine("  AGE : " + age + " ans");
            if(this.emploi == null)
            {
                Console.WriteLine("  non spécifié");
            }
            else
            {
                Console.WriteLine("  EMPLOI : " + emploi);
            }
        }

        /*getters et setters
        public string GetNom()
        {
            return this.nom;
        }

        public void SetNom(string _nom)
        {
            this.nom = _nom;
        }*/
    }

    class Program
    {
        /*static void AfficherInfosPersonne(string nom, int age, string emploi)
        {
            Console.WriteLine("NOM : " + nom);
            Console.WriteLine("  AGE : " + age + " ans");
            Console.WriteLine("  EMPLOI : " + emploi);
        }*/

        static void Main(string[] args)
        {
            // nom, age, emploi
            /*var noms = new List<string> { "Paul", "Jacques", "David", "Juliette" };
            var ages = new List<int> { 30, 35, 20, 8 };
            var emplois = new List<string> { "Développeur", "Professeur", "Etudiant", "CP" };

            for (int i = 0; i < noms.Count; i++)
            {
                AfficherInfosPersonne(noms[i], ages[i], emplois[i]);
            }

            Personne personne1 = new Personne("Paul", 30, "Développeur");
            personne1.Afficher();

            Personne personne2 = new Personne("Jacques", 35, "Professeur");
            personne2.Afficher();*/

            //liste de Class Personne
            List<Personne> listeCivile = new List<Personne>();
            listeCivile.Add(new Personne("Edouard", 28, "Mécanicien"));
            listeCivile.Add(new Personne("Nathalie", 42, "Secrétaire"));
            listeCivile.Add(new Personne("Pauline", 18, "Etudiant"));
            listeCivile.Add(new Personne("Nicolas", 8, "CP"));
            listeCivile.Add(new Personne("juliette", 24));
            listeCivile.Add(new Personne("lucas", 21));
            listeCivile.Add(new Personne() { age = 28, nom = "pierre", emploi = "Développeur"});// init, attribut nom ne pourra plus être modifié avec setter

            //Trier par nom
            listeCivile = listeCivile.OrderBy(p => p.nom).ToList();

            //Modification age si age est positif
            listeCivile[0].age = 29;

            //Afficher chaque personne de la liste
            foreach (Personne element in listeCivile)
            {
                element.Afficher();
                Console.WriteLine();
            }

            Personne.AfficherNombrePersonnes();
        }
    }
}
