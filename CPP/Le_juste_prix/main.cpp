#include <iostream>
#include <string>

using namespace std;

int main()
{
    // Localisation fr pour les accents
    setlocale(LC_ALL, "fra");

    // VARIABLES
    int nbreUtilisateur = -1;
    int justePrix {3'518} ; // Apostrophe ignoré lors de l'exécution utilisé pour plus de lisibilité dans le code
    int nbrEssais = 0;
    const int NBRE_ESSAIS_MAX = 10;
    int prixMin = 0;
    int prixMax = 5000;
    bool prixValide = false;


    // TRAITEMENT
    cout << "Bienvenue au juste prix !" << endl;
    cout << justePrix << endl;

    do
    {
        prixValide = false;

        while(!prixValide)
        {
            cout << "Entrer une valeur : ";
            cin >> nbreUtilisateur;
            if(nbreUtilisateur >= prixMin && nbreUtilisateur <= prixMax)
            {
               prixValide = true;
            }
            else
            {
                cout << "La valeur doit être comprise entre " << prixMin << " et " << prixMax << " ! " << endl;
            }
        }

        nbrEssais++;
        if(nbreUtilisateur == justePrix)
        {
            cout << "Gagné ! Le juste prix est bien : " << nbreUtilisateur << ". Nombre d'essais : " << nbrEssais;
        }
        else if(nbreUtilisateur < justePrix)
        {
            prixMin = nbreUtilisateur;
            cout << "Le juste prix est compris entre " << prixMin << " et " << prixMax << ". Nombre d'essais : " << nbrEssais << endl<<endl;
        }
        else if(nbreUtilisateur > justePrix)
        {
            prixMax = nbreUtilisateur;
            cout << "Le juste prix est compris entre " << prixMin << " et " << prixMax << ". Nombre d'essais : " << nbrEssais << endl<<endl;
        }
    }while(nbrEssais < NBRE_ESSAIS_MAX && nbreUtilisateur != justePrix);

    if(nbreUtilisateur != justePrix)
    {
        cout << " Perdu !";
    }

    // AFFICHAGE
}
