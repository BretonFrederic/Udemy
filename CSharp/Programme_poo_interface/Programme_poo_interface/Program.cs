using System;
using System.Collections.Generic;
using System.Linq;

namespace programme_poo_interface
{

    // 1 - Créer une classe Enfant (Etudiant)
    // 2 - Constructeur : nom et l'age ;  infoEtudes = null
    // 3 - Main -> Créer un enfant "Sophie", 7 -> Afficher

    // 4 - ClasseEcole  "CP"
    // 5 - Afficher  Enfant en classe de CP
    // 6 - AfficherProfesseurPrincipal

    class Enfant : Etudiant
    {
        string classeEcole;
        Dictionary<string, float> notes;
        public Enfant(string nom, int age, string classeEcole, Dictionary<string, float> notes) : base(nom, age, null)
        {
            this.classeEcole = classeEcole;
            this.notes = notes;
        }

        public override void Afficher()
        {
            AfficherNomEtAge();
            Console.WriteLine("  Enfant en classe de " + classeEcole);
            if ((notes != null) && (notes.Count > 0))
            {
                Console.WriteLine("  Notes moyennes :");
                foreach (var note in notes)
                {
                    Console.WriteLine("    " + note.Key + " : " + note.Value + " / 10");
                }
            }
            //                "  Notes moyennes"
            //    foreach     "    Maths : 5 / 10"
            AfficherProfesseurPrincipal();
        }
    }

    // Maths : 5 / 10
    // Geo : 8,5 / 10
    // clef : string / valeur : float
    // Dictionary<string, float>
    // Dictionary<string, float> { { "Maths", 5f},  { "Geo", 8.5f} }

    class Etudiant : Personne
    {
        string infoEtudes;
        public Personne professeurPrincipal { get; init; }

        public Etudiant(string nom, int age, string infoEtudes) : base(nom, age, null)
        {
            this.infoEtudes = infoEtudes;
        }

        public override void Afficher()
        {
            AfficherNomEtAge();
            Console.WriteLine("  Etudiant en " + infoEtudes);
            AfficherProfesseurPrincipal();
        }

        protected void AfficherProfesseurPrincipal()
        {
            if (professeurPrincipal != null)
            {
                Console.WriteLine("  Le professeur principal est :");
                professeurPrincipal.Afficher();
            }
        }

    }

    class Personne : IAffichable
    {
        static int nombreDePersonnes = 0;

        public string nom { get; init; }
        public int age { get; init; }
        string emploi;

        protected int numeroPersonne;


        public Personne(string nom, int age, string emploi = null)
        {
            this.nom = nom;
            this.age = age;
            this.emploi = emploi;

            nombreDePersonnes++;
            this.numeroPersonne = nombreDePersonnes;
        }

        public virtual void Afficher()
        {
            AfficherNomEtAge();
            if (emploi == null)
            {
                Console.WriteLine("  Aucun emploi spécifié");
            }
            else
            {
                Console.WriteLine("  EMPLOI : " + emploi);
            }
        }

        // AfficherNomEtAge

        protected void AfficherNomEtAge()
        {
            Console.WriteLine("PERSONNE N°" + numeroPersonne);
            Console.WriteLine("  NOM : " + nom);
            Console.WriteLine("  AGE : " + age + " ans");
        }

        public static void AfficherNombreDePersonnes()
        {
            Console.WriteLine("Nombre total de personnes : " + nombreDePersonnes);
        }
    }

    class TableMultiplication : IAffichable
    {
        int numero;
        public TableMultiplication(int numero)
        {
            this.numero = numero;
        }

        public void Afficher()
        {
            Console.WriteLine("Table de multiplication de " + numero);

            // 1 x 2 = 2
            // 2 x 2 = 4
            // ...
            // 10 x 2 = 20
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i + " x " + numero + " = " + (i * numero));
            }
        }
    }

    interface IAffichable
    {
        void Afficher();
    }

    class Program
    {
        static void Main(string[] args)
        {

            // Personne -> Etudiant -> Enfant  (Afficher)
            // TableMultiplication (Afficher)

            var elements = new List<IAffichable> {
                new Personne("Paul", 30, "Développeur"),
                new Personne("Jacques", 35, "Professeur"),
                new Etudiant("David", 20, "philo"),
                new Enfant("Juliette", 8, "CP", null),
                new TableMultiplication(2)
            };

            foreach (var element in elements)
            {
                element.Afficher();
            }

            //var table2 = new TableMultiplication(2);
            //table2.Afficher();
        }
    }
}
