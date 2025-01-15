using System;

namespace Premier_programme
{
    public class Program
    {
        static int DemanderAge(String nom)
        {
            int monAge = 0;
            while (monAge <= 0)
            {
                Console.WriteLine("Quel est ton âge "+nom+" ?");
                try
                {
                    monAge = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    if (monAge < 0)
                    {
                        Console.WriteLine("Erreur : Vous ne pouvez pas entrer un âge négatif.");
                    }
                    else if (monAge == 0)
                    {
                        Console.WriteLine("Erreurr : L'âge ne peut pas être 0.");
                    }

                }
                catch
                {
                    Console.WriteLine("Erreur : Vous devez entrer un âge valide.");
                }
            }
            return monAge;
        }

        static String DemanderNom(int numeroPersonne)
        {
            String nom = "";
            while (nom == "")
            {
                String alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzéèçàù' -";
                int counter = 0;
                Console.WriteLine("Quel est le nom de la personne numéro "+numeroPersonne+" ?");
                nom = Console.ReadLine();
                
                //Supprimer les espaces d'une chaîne de charactères : .Trim()
                //nom = nom.Trim();

                Console.WriteLine("");
                if (nom == "")
                {
                    Console.WriteLine("Erreur : Vous devez entrer un nom.");
                }
                if (nom != "")
                {
                    for (int i = 0; i <= nom.Length - 1; i++)
                    {
                        for (int j = 0; j <= alphabet.Length - 1; j++)
                        {
                            if (nom[i].Equals(alphabet[j]))
                            {
                                counter++;
                            }
                        }
                    }
                    if (counter != nom.Length)
                    {
                        Console.WriteLine("Erreur : Vous ne pouvez pas utiliser les charactères spéciaux.");
                        nom = "";
                    }
                }

            }
            return nom;
        }

        static void AfficherInformation(String nomPersonne, int agePersonne)
        {
            Console.WriteLine("Bonjour, vous vous appelez " + nomPersonne + ", vous avez " + agePersonne + " ans.");
            //Console.WriteLine("Bientôt vous aurez " + (agePersonne + 1) + " ans.");
            //Affichage chaîne formaté
            Console.WriteLine($"Bientôt vous aurez {(agePersonne + 1)} ans.");

            if (agePersonne == 1 || agePersonne == 2)
            {
                Console.WriteLine("Vous êtes un bébé.\n");
            }
            else if (agePersonne < 10)
            {
                Console.WriteLine("Vous êtes un enfant.\n");
            }
            else if (agePersonne == 17)
            {
                Console.WriteLine("Vous serez bientôt majeur.\n");
            }
            else if (agePersonne == 18)
            {
                Console.WriteLine("Vous êtes tout juste majeur.\n");
            }
            else if (agePersonne >= 60)
            {
                Console.WriteLine("Vous êtes sénior.\n");
            }
            else if (agePersonne > 18)
            {
                Console.WriteLine("Vous êtes majeur.\n");
            }
            else if (agePersonne >= 12 && agePersonne < 18)
            {
                Console.WriteLine("Vous êtes un adolescent.\n");
            }
            else
            {
                Console.WriteLine("Vous êtes mineur.\n");
            }

        }
        public static void Main(String[] args)
        {
            /* VARIABLES */

            //String nom = "";
            //int age = 0;

            /* DEBUT PROGRAMME */

            //Demander nom
            //String nom1 = DemanderNom(1);
            //String nom2 = DemanderNom(2);

            String nom1 = "Paul";
            String nom2 = "Jean";


            //Demander âge
            int age1 = DemanderAge(nom1);
            int age2 = DemanderAge(nom2);

            //Afficher
            AfficherInformation(nom1, age1);
            AfficherInformation(nom2, age2);

            //Boucle simple demander et afficher infos plusieurs personnes
            /*const int NB_PERSONNE = 5;
            for (int i = 0; i < NB_PERSONNE; i++)
            {
                String nom = DemanderNom(i+1);
                int age = DemanderAge(nom);
                AfficherInformation(nom, age);
                Console.WriteLine();
                Console.WriteLine("--");
            }
            */

            /* FIN PROGRAMME */
        }
    }
}