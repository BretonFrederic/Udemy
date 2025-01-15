using System;

namespace RecordsSyntaxeCourte
{
    internal class Program
    {
        // Record syntaxe longue
        record PersonneRecordLong
        {
            public string nom { get; init; }
            public int age { get; init; }

            public PersonneRecordLong(string nom, int age)
            {
                this.nom = nom;
                this.age = age;
            }

            public void Deconstruct(out string nomL, out int ageL)
            {
                nomL = this.nom;
                ageL = this.age;
            }

            public void Afficher()
            {
                Console.WriteLine("nom : " + nom + " - age : " + age + " ans");
            }
        }

        // record syntaxe courte équivalent de la version longue
        record PersonneRecordCourt(string nomC, int ageC);

        static void Main(string[] args)
        {
            // record version longue
            var PersonneRecordLong1 = new PersonneRecordLong("Fifi", 22);

            // Utilisation syntaxe avec Deconstruct pour récupérer tout les champs
            var(nomL, ageL) = PersonneRecordLong1;

            Console.WriteLine("record version longue.");
            Console.WriteLine("Récupéré avec Deconstruct nom :" + nomL);
            Console.WriteLine("Récupéré avec Deconstruct age :" + ageL);

            PersonneRecordLong1.Afficher();
            Console.WriteLine();

            // record version courte
            var PersonneRecordCourt1 = new PersonneRecordLong("Loulou", 27);

            // Utilisation syntaxe avec Deconstruct pour récupérer tout les champs
            var (nomC, ageC) = PersonneRecordCourt1;

            Console.WriteLine("record version courte.");
            Console.WriteLine("Récupéré avec Deconstruct nom :" + nomC);
            Console.WriteLine("Récupéré avec Deconstruct age :" + ageC);

            PersonneRecordCourt1.Afficher();

            /*
             *  Type simple -->  (int, float, char...) value Type (Valeur)
             *  Structures  -->  value Type (valeur = les valeurs des champs)
             *  Class       -->  Reference Type (valeur = adresse de l'objet)
             *  list<>      -->  Reference type (valeur = adresse de l'objet)
            */
        }
    }
}

