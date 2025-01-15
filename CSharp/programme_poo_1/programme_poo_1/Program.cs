using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace programme_poo_1
{
    class Enfant : Etudiant
    {
        //Variables d'instance
        private string nom;
        private int age;
        public string classeEnfant { get; init; }
        private Dictionary<string, float> notes;

        //Constructeur
        public Enfant(string nom, int age, Dictionary<string, float> notes) : base(nom, age, null)
        {
            this.nom = nom;
            this.age = age;
            this.notes = notes;
        }

        //Méthodes
        public override void Afficher()
        {
            AfficherNomEtAge();
            Console.WriteLine("  Enfant en classe de : " + classeEnfant);
            if ((notes != null) && (notes.Count > 0))
            {
                Console.WriteLine("Notes par matière : ");
                foreach (var note in notes)
                {
                    Console.WriteLine("    " + note.Key + " : " + note.Value + "/10");
                }
            }
            AfficherProfesseurprincipal();
        }
    }
    class Etudiant : Personne
    {
        //Variables d'instance
        private string infoEtudiant;
        public Personne professeurPrincipal { get; init; }

        //Constructeur
        public Etudiant(String nom, int age, string infoEtudiant) : base(nom, age)
        {
            this.infoEtudiant = infoEtudiant;
        }

        //méthodes
        public override void Afficher()
        {
            AfficherNomEtAge();
            Console.WriteLine("  Etudiant en : " + infoEtudiant);
            AfficherProfesseurprincipal();
        }

        protected void AfficherProfesseurprincipal()
        {
            if (professeurPrincipal != null)
            {
                Console.WriteLine("  Le professeur principal est : ");
                professeurPrincipal.Afficher();
            }
        }
}
    class Personne
    {
        //Variable de class
        private static int nombrePersonnes;//static variable commune à toutes les instances

        //variable d'instance
        protected string nom;
        protected int age;
        private string emploi;
        protected int numeroPersonne = 0;

        //Constructeur
        public Personne(string nom, int age, string emploi = null)
        {
            this.nom = nom;
            this.age = age;
            this.emploi = emploi;
            nombrePersonnes++;
            this.numeroPersonne = nombrePersonnes;
        }

        //Méthodes static (utiliser avec la class Personne.AfficherPersonnes();)
        public static void AfficherNombrePersonnes()
        {
            Console.WriteLine("Nombre total de personnes : " + nombrePersonnes);
        }

        //méthodes
        protected void AfficherNomEtAge()
        {
            Console.WriteLine("Personne N° " + numeroPersonne);
            Console.WriteLine("  NOM : " + nom);
            Console.WriteLine("  AGE : " + age + " ans");
        }
        public virtual void Afficher()
        {
            AfficherNomEtAge();
            if (this.emploi == null)
            {
                Console.WriteLine("  non spécifié");
            }
            else
            {
                Console.WriteLine("  EMPLOI : " + emploi);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Etudiant etudiant1 = new Etudiant("Richard", 21, "Ecole d'ingénieur informatique")
            {
                professeurPrincipal = new Personne("Greg", 38, "Professeur d'informatique")
            };
            
            etudiant1.Afficher();

            Enfant enfant1 = new Enfant("sophie", 7, new Dictionary<string, float> ()
                             { 
                                { "mathématique", 9.5f }, 
                                { "géographie", 6.8f }, 
                                { "dictée", 4.5f }, 
                                { "conjuguaison", 8.7f } 
                             }) 
            { 
                classeEnfant = "CP", professeurPrincipal = new Personne("Sylvie", 42, "Professeur des Ecoles")
            };

            enfant1.Afficher();
        }
    }
}