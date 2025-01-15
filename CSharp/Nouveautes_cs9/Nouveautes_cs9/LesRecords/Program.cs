using System;

namespace InitOnlyProperties
{
    internal class Program
    {
        // Pas d'héritage avec la structure s'utilise avec très peu de données, possibilité de comparer des champs de données
        struct PersonneStruct
        {
            public string nom { get; set; }
            public int age { get; set; }

            public void Afficher()
            {
                Console.WriteLine("nom : " + nom + " - age : " + age + " ans");
            }
        }
        // Héritage, objet de grande taille mais pas fait pour comparer l'égalité des champs de données
        class PersonneClass
        {
            public string nom { get; set; }
            public int age { get; set; }

            public void Afficher()
            {
                Console.WriteLine("nom : " + nom + " - age : " + age + " ans");
            }
        }

        // Record
        record PersonneRecord
        {
            public string nom { get; set; }
            public int age { get; set; }

            public void Afficher()
            {
                Console.WriteLine("nom : " + nom + " - age : " + age + " ans");
            }
        }

        static void Main(string[] args)
        {
            // PASSAGE PAR VALEUR
            Console.WriteLine("PASSAGE PAR VALEUR.");
            Console.WriteLine();
            int a = 5;
            int b = 10;

            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine();

            b = a;
            a = 6;

            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine();

            // Structure --> passage par valeur
            var personneStruct1 = new PersonneStruct() { nom = "toto", age = 20 };
            var personneStruct2 = personneStruct1;
            personneStruct1.Afficher();
            personneStruct2.Afficher();
            Console.WriteLine();

            // Console.WriteLine(personneStruct1 == personneStruct2);   // <-- on ne peut pas comparer avec == 2 Struct

            // Comparaison par valeur
            Console.WriteLine("Struct comparaison par valeur : " + personneStruct1.Equals(personneStruct2)); // <-- on peut comparer 2 Struct avec Equals()
            Console.WriteLine();

            personneStruct1.nom = "tata";

            personneStruct1.Afficher();
            personneStruct2.Afficher();
            Console.WriteLine();

            

            // Class --> PASSAGE PAR RÉFÉRENCE
            Console.WriteLine("PASSAGE PAR RÉFÉRENCE.");
            Console.WriteLine();

            var personneClass1 = new PersonneClass() { nom = "toto", age = 20 };
            var personneClass2 = personneClass1;
            personneClass1.Afficher();
            personneClass2.Afficher();
            Console.WriteLine();

            personneClass1.nom = "tata";

            personneClass1.Afficher();
            personneClass2.Afficher();
            Console.WriteLine();

            // Comparaison Class (par référence)
            var personneClass3 = new PersonneClass() { nom = "titi", age = 23 };
            var personneClass4 = new PersonneClass() { nom = "titi", age = 23 };
            Console.WriteLine("Class comparaison par référence : " + personneClass3.Equals(personneClass4)); // <-- Faux car adresses et objets différents (2 new)
            Console.WriteLine();

            // Comparaison Class (par référence)
            var personneClass5 = new PersonneClass() { nom = "Dédé", age = 32 };
            var personneClass6 = personneClass5;
            Console.WriteLine("Class comparaison par référence : " + personneClass5.Equals(personneClass6)); // <-- Vrai car même adresse et même objet (1 new)
            Console.WriteLine();

            // record est un reference type mais avec certaines fonctionnalités des value type
            var personneRecord7 = new PersonneRecord() { nom = "Gégé", age = 27 };
            var personneRecord8 = personneRecord7 with { nom = "Riri" }; // clone de personneRecord7 avec nom altéré

            personneRecord7.Afficher();
            personneRecord8.Afficher();

            // Comparaison par valeurs de record qui est un reference type
            Console.WriteLine("record comparaison par référence : " + personneRecord7.Equals(personneRecord8)); // <-- Vrai car même adresse et même objet (1 new)
            Console.WriteLine();

            /*
             *  Type simple -->  (int, float, char...) value Type (Valeur)
             *  Structures  -->  value Type (valeur = les valeurs des champs)
             *  Class       -->  Reference Type (valeur = adresse de l'objet)
             *  list<>      -->  Reference type (valeur = adresse de l'objet)
             *  records     -->  Reference Type avec des fonctionnalités Value Type
            */
        }
    }
}
