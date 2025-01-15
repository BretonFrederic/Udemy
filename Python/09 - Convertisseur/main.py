"""
commentaires
"""

INCH_TO_CM = 2.54
CM_TO_INCH = 0.394
unite1 = "none"
unite2 = "none"
coefficient = 0.0
nombre = 0.0
resultat = 0.0
quitter = False

# Demander à l'utilisateur si il souhaite convertir de "pouces vers cm" ou "cm vers pouces"

while unite2 == "none":
    print("Pour convertir de pouces vers cm, entrer : A.")
    print("Pour convertir de cm vers pouces, entrer : B.")
    choix = input("Quel est votre choix ? ")
    if choix == "A":
        unite1 = "pouces"
        unite2 = "cm"
        coefficient = INCH_TO_CM
    elif choix == "B":
        unite1 = "cm"
        unite2 = "pouces"
        coefficient = CM_TO_INCH
    else:
        print("Vous devez entrer A ou B")
        print()
print()

# Demander à l'utilisateur de rentrer la valeur à convertir (en réaffichant l’unité demandée)

while quitter == False:
    while nombre == 0:
        valeur = input(f"Entrer la valeur à convertir en {unite2} : ")
        try:
            nombre = float(valeur)
        except:
            print("Vous devez entrer un nombre. Réssayez.")
        print()

    # Afficher la valeur convertie (et l'unité : cm ou pouces)
    if nombre != 0:
        resultat = round((nombre * coefficient), 2)
        print(f"Conversion : {valeur} {unite1} vaut {resultat} {unite2}")
    nombre = 0

    continuer = "none"
    while continuer == "none":
        continuer = input(f"Pour continuer à convertir en {unite2} enter Y sinon entrer N : ")
        if continuer == "N":
            quitter = True
        elif continuer == "Y":
            quitter = False
        else:
            print("Vous devez entrer Y ou N")
            continuer = "none"