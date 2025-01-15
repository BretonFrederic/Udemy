import time
import beepy

print("a) Oeufs à la coque (3 minutes)\nb) Oeufs mollets (6 minutes)\nc) Oeufs dur (9 minutes)")
def option():
    timer = 0
    recipe = input("Quel est votre choix ? : ")
    if recipe == "a":
        timer = 3*60
    elif recipe == "b":
        timer = 6*60
    elif timer == "c":
        timer = 9*60
    else:
        return option()
    print(f"Votre choix : {recipe}")
    return timer

def interval():
    for i in range(10):
        time.sleep(1)
        print(".", end="", flush=True)
    print()


# -------------------------------------MAIN -------------------------------------
d = option()
print("Cuisson en cours", end="")

while d > 0:
    interval()
    d -= 10
    minutes = int(d / 60)
    seconds = d % 60
    print(f"Durée restante : {minutes:02d}:{seconds:02d}", end="")

beepy.beep(sound="ping")
print()
print("Cuisson terminée")
