using System;

namespace Jeux_de_maths
{
    class Program
    {
        enum choix_operation
        {
            ADDITION = 1, SOUSTRACTION = 2, MULTIPLICATION = 3, DIVISION = 4

        }

        /* FONCTIONS */

        static int GenererOperation(int _min, int _max)
        {
            Random nbAleatoire = new Random();
            bool operationInvalide = false;
            string operateur = " + ";
            int nb1, nb2, result = 0;
            choix_operation op;
            do
            {
                nb1 = nbAleatoire.Next(_min, _max+1);
                nb2 = nbAleatoire.Next(_min, _max+1);
                op = (choix_operation)nbAleatoire.Next(1,5);

                switch (op)
                {
                    case choix_operation.ADDITION:
                        result = nb1 + nb2;
                        operateur = " + ";
                        break;
                    case choix_operation.SOUSTRACTION:
                        result = nb1 - nb2;
                        operateur = " - ";
                        if(result < 0)
                        {
                            operationInvalide = true;
                        }
                        else
                        {
                            operationInvalide = false;
                        }
                        break;
                    case choix_operation.MULTIPLICATION:
                        result = nb1 * nb2;
                        operateur = " * ";
                        break;
                    case choix_operation.DIVISION:
                        if (nb1 % nb2 != 0)
                        {
                            operationInvalide = true;
                        }
                        else
                        {
                            result = nb1 / nb2;
                            operateur = " / ";
                            operationInvalide = false;
                        }
                        break;
                    default:
                        Console.WriteLine("ERREUR : Opération non générer.");
                        break;
                }
            } while (operationInvalide);
            
            Console.Write(nb1 + operateur + nb2 + " = ");
            return result;
        }
        static int DemanderResultat()
        {
            int nbUtilisateur = 0;
            bool nbValide = false;
            while (!nbValide)
            {
                try
                {
                    nbUtilisateur = int.Parse(Console.ReadLine());
                    nbValide = true;
                }
                catch
                {
                    Console.WriteLine("ERREUR : Vous devez entrer un nombre.\n");
                }
            }
            
            return nbUtilisateur;
        }

        static int CalculerPoints(int _reponseJoueur, int _result)
        {
            int nbPoints = 0;
            if (_reponseJoueur == _result)
            {
                Console.WriteLine("Bonne réponse.\n");
                nbPoints = 1;
            }
            else
            {
                Console.WriteLine("Mauvaise réponse.\n");
            }
            return nbPoints;
        }
        static void AfficherScore(int _nbPoints, int _questionMax)
        {
            Console.WriteLine("Nombre de points : " + _nbPoints + " / " + _questionMax);
            if (_nbPoints == _questionMax)
            {
                Console.WriteLine("Excellent !");
            }
            else if (_nbPoints == 0)
            {
                Console.WriteLine("Révisez vos maths !");
            }
            else if (_nbPoints == _questionMax / 2)
            {
                Console.WriteLine("C'est pas mal");
            }
            else if (_nbPoints < _questionMax / 2)
            {
                Console.WriteLine("Essayer de faire mieux la prochaine.");
            }
            else if (_nbPoints > _questionMax / 2)
            {
                Console.WriteLine("Pas mal.");
            }
        }

        static void Commencer()
        {
            /* CONSTRANTES */

            const int QUESTIONS_MAX = 8;
            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 10;

            /* VARIABLES */

            int reponseJoueur = 0, result = 0, score = 0, numQuestion = 0;

            for (numQuestion = 1; numQuestion <= QUESTIONS_MAX; numQuestion++)
            {
                //Afficher le numéro de question
                Console.WriteLine("Question n°" + numQuestion + "/" + QUESTIONS_MAX + " :");


                //Générer et afficher opération
                result = GenererOperation(NOMBRE_MIN, NOMBRE_MAX);

                //Demander un résultat au joueur
                reponseJoueur = DemanderResultat();

                //Calculer nombre de points
                score += CalculerPoints(reponseJoueur, result);
            }

            //Afficher le score
            AfficherScore(score, QUESTIONS_MAX);
        }


        /* FONCTIONS PRINCIPALE */
        public static void Main(String[] args)
        {

            /* DEBUT PROGRAMME */

            //Commencer le questionnaire
            Commencer();
            
            /* FIN PROGRAMME */
        }
    }
}

