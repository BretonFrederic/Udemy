namespace cs10_structs
{
    // Pas possible d'afficher valeurs avec le nom de l'objet en paramètre console.write(ps1)
    // Pas de == d'objets mais .Equals() valide, plus lent utilise reflexion pré-généré 
    struct PersonneStruct
    {
        public string nom { get; set; }
        public int age { get; set; }

        //cs 10 permet de surcharger le constructeur par défaut
        public PersonneStruct()
        {
            this.nom = "Inconnu";
            this.age = -1;
        }
    }

    // reference / valeur
    // une des fonctionnalité du record test == des valeurs et non de l'adresse comme les classes
    record PersonneRecord // Equivalent à record class PersonneRecord
    {
        public string? nom { get; set; }
        public int age { get; set; }
    }

    // record struct permet d'accéder à de nouvelles fonctionnalités, afficher valeurs avec le nom
    // de l'objet en paramètre console.write(ps1), == plus rapide si beaucoup de comparaison que Equals()
    // Possibilité d'utiliser l'héritage, syntaxe positionnelle, record mutable ou immutable et accès au
    // déconstructeur qui permet de récupérer toutes les valeurs contrairement au struct
    record struct PersonneRecordStruct // record struct mutable possibilité d'altérer les valeurs
    {
        public string? nom { get; set; }
        public int age { get; set; }
    }

    // record immutable - pas possible de modifier les champs après construction - Possible de "cloner" et avec with modifier les champs du "clone"
    record PersonneRecordImmutable(string nom, int age); // Syntaxe positionnelle

    // Rendre record struct immutable - readonly record struct
    readonly record struct PersonneReadOnlyRecordStruct(string nom, int age); // Rendu immutable avec readonly
    class Program
    {
        public static void Main(string[] args)
        {
            /*----------------------------------------- struct ---------------------------------------------------------*/

            // var ps1 = new PersonneStruct();

            /*----------------------------------------- record ---------------------------------------------------------*/

            var pr1 = new PersonneRecord { nom = "Paul", age = 20 };
            //var pr2 = new PersonneRecord { nom = "Pierre", age = 20 }; // Egalité pr1 == pr2 vaut false valeur nom différentes
            var pr2 = pr1;

            pr1.nom = "Toto"; //pr2.nom vaut également "Toto" pr2 est une référence à pr1, il n'y qu'un seul objet

            Console.WriteLine(pr2.nom);
            Console.WriteLine(pr1 == pr2);// true car on compare les valeurs d'un seul objet

            /*----------------------------------------- record struct -------------------------------------------------*/

            var prs1 = new PersonneRecordStruct { nom = "Paul", age = 20 };
            
            var prs2 = prs1; // Avec record struct prs1 est un nouvel objet

            prs1.nom = "Toto"; //pr2.nom vaut toujours "Paul" et pr1.nom vaut "Toto"

            Console.WriteLine(prs1);
            Console.WriteLine(prs2);
            Console.WriteLine(prs1 == prs2);// false car les valeurs des champs nom des 2 objets sont différentes

            /*----------------------------------------- record immutable ----------------------------------------------*/

            var pri1 = new PersonneRecordImmutable("Paul",20 );

            var pri2 = pri1 with { nom="Tata" }; // pri2 est un nouvel objet copie de pri1, with permet de modifier la valeur des champs

            Console.WriteLine(pri1);
            Console.WriteLine(pri2);
            Console.WriteLine(pri1 == pri2);// false car les valeurs des champs nom des 2 objets sont différentes

            /*----------------------------------------- record déconstruction(récupérer valeurs) ----------------------*/

            var prors1 = new PersonneReadOnlyRecordStruct("Paul", 20);

            var prors2 = prors1 with { nom = "Tata" }; // pri2 est un nouvel objet copie de pri1, with permet de modifier la valeur des champs

            Console.WriteLine(prors1);
            Console.WriteLine(prors2);
            Console.WriteLine(prors1 == prors2);// false car les valeurs des champs nom des 2 objets sont différentes

            // Flexibilité déclaration
            string nom1 = "";
            //int age1 = 0;

            //var (nom1, age1) = prors1;

            (nom1, var age1) = prors1;
            Console.WriteLine(nom1);
            Console.WriteLine(age1);
        }
    }
}
