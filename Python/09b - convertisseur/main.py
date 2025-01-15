"""
Pour cet exercice, vous allez créer un programme de conversion d'unités, qui sera capable de convertir
des pouces (inch) en centimètres (cm), et vice-versa.


1 pouce = 2.54 cm

1 cm = 0.394 pouces


Exemple :

Un écran de 17 pouces de diagonale, correspond à 43,18 cm (=17*2.54)


Voici comment votre programme doit se comporter :

1 - Demander à l'utilisateur si il souhaite convertir de "pouces vers cm" ou "cm vers pouces"

2 - Demander à l'utilisateur de rentrer la valeur à convertir (en réaffichant l’unité demandée)

3 - Afficher la valeur convertie (et l'unité : cm ou pouces)

Boucler pour convertir plusieurs valeurs (en conservant toujours le même sens de conversion), et proposer une option
pour sortir du programme.
"""

# VARIABLES
choice = ""
unite1 = "pouces"
unite2 = "cm"
conv = 0.0
INCH_CM = 2.54
invertConv = False


# FONCTION CONVERSION ET AFFICHAGE
def display_convert(unit1: str, unit2: str, coefficient: float, reverse: bool):
    result = 0.0
    if reverse:
        unit1, unit2 = unit2, unit1
        coefficient = 1 / coefficient
    value = input(f"Quelle valeur voulez-vous convertir en {unit2} ? : ")
    if value != "0":
        try:
            number = float(value)
            result = round(number * coefficient, 2)
        except ValueError:
            print("ERREUR. Vous devez entrer un nombre.")
            reverse = False
            return display_convert(unit1, unit2, coefficient, reverse)
    print(f"Conversion : {value} {unit1} -> {result} {unit2}")
    quitter = input(f"Appuyez sur entrer pour continuer à convertir en {unit2} ou entrer q pour quitter : ")
    if quitter != "q":
        return display_convert(unit1, unit2, coefficient, reverse)
    return 0


# MENU
print("a : Convertir pouces -> cm. \nb : Convertir cm -> pouces")
# CHOIX DE CONVERSION
while choice == "":
    choice = input(f"Quel est votre choix ? : ")
    if choice == "a":
        conv = INCH_CM
    elif choice == "b":
        invertConv = True
        conv = INCH_CM
    else:
        print("ERREUR. Vous devez enter a ou b.")
        choice = ""
display_convert(unite1, unite2, conv, invertConv)
