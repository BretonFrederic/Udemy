import random

NOMBRE_MIN = 1
NOMBRE_MAX = 10
NOMBRE_QUESTIONS = 4

def poser_question():
    a = random.randint(NOMBRE_MIN, NOMBRE_MAX)
    b = random.randint(NOMBRE_MIN, NOMBRE_MAX)
    o = random.randint(0, 1)
    bool_point = False
    int_resultat = 0
    while int_resultat == 0:
        not_number = False
        operateur_str = "+"
        if o == 1:
            operateur_str = "*"
        reponse_utilisateur = input(f"Quel est le résultat de {a} {operateur_str} {b} = ? ")
        try:
            int_resultat = int(reponse_utilisateur)
        except:
            print("ERREUR : Vous devez entrer un nombre.")
            not_number = True
        calcul = a+b
        if o == 1:
            calcul = a*b
        if int_resultat == calcul and not_number == False:
            print(f"Réponse correcte {a} {operateur_str} {b} = {int_resultat}")
            bool_point = True
        elif not_number == False:
            print(f"Votre réponse est incorrecte.")
    return bool_point

nb_points = 0
for num_question in range(0, NOMBRE_QUESTIONS):
    print()
    print(f"question n°{num_question+1} sur {NOMBRE_QUESTIONS}:")
    if poser_question() == True:
        nb_points += 1
    print(f"Nombre de points {nb_points}/{NOMBRE_QUESTIONS}")

    if num_question == 3:
        print()
        moyenne = int(NOMBRE_QUESTIONS/2)
        if nb_points == NOMBRE_QUESTIONS:
            print("Excellent!")
        elif nb_points == 0:
            print("Révisez vos maths!")
        elif nb_points > moyenne:
            print("Pas mal!")
        else:
            print("Peut mieux faire.")
