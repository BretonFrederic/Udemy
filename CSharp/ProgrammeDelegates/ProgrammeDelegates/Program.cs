using System;

namespace ProgrammeDelegates
{
    class Program
    {
        //Avec delegate, ValidationChaine devient un type qui dans le cas actuel prend et retourne un string
        public delegate string ValidationChaine(string s);

        static void Main(string[] args)
        {
            //Demander nom utilisateur
            //Demander numéro de tel utilisateur

            string nomUtilisateur = DemanderInfoUtilisateur("Quel est votre nom ?", CheckValidationNom);
            string numeroUtilisateur = DemanderInfoUtilisateur("Quel est votre numéro de téléphone ?", CheckValidationNumero);

            Console.WriteLine("Bonjour " + nomUtilisateur + ", vous êtes joignable au " + numeroUtilisateur);

            //La fonction DemanderInfoUtilisateur prend en paramètre une fonction de type ValidationChaine
            static string DemanderInfoUtilisateur(string message, ValidationChaine fonctionValidation = null)
            {
                Console.Write(message + " ");
                string reponse = Console.ReadLine();
                if(fonctionValidation != null)
                {
                    string erreur = fonctionValidation(reponse);
                    if (erreur != null)
                    {
                        Console.WriteLine("ERREUR : " + erreur);
                        return DemanderInfoUtilisateur(message, fonctionValidation);
                    }
                }
                return reponse;
            }

            static string CheckValidationNom(string s)
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    return "Le nom ne doit pas être vide.";
                }
                //Si il y a au moins un des caractères qui serait un chiffre
                if (s.Any(char.IsDigit))
                {
                    return "Le nom ne doit pas contenir de chiffre.";
                }
                return null;
            }

            static string CheckValidationNumero(string s)
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    return "Le numéro de téléphone ne doit pas être vide.";
                }
                if(s.Length != 10)
                {
                    return "Le numéro de téléphone doit contenir 10 chiffres.";
                }
                //Si il y a au moins un des caractères qui serait un chiffre
                if (!s.All(char.IsDigit))
                {
                    return "Le numéro de téléphone doit contenir uniquement des chiffres.";
                }
                return null;
            }
        }
    }
}
