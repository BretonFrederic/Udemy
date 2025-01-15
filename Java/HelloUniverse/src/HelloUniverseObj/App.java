package HelloUniverseObj;
import java.util.Scanner;
public class App {
    public static void main(String[] args){
        //VARIABLES
        //noms planètes
        String[] nom = {"Mercure", "Vénus", "Terre", "Mars", "Jupiter", "Saturne", "Uranus", "Neptune"};
        //matières
        String matiere = "";
        //Diamètres : Mercure, Vénus, Terre, Mars, Jupiter, Saturne, Uranus, Neptune
        long[] diametre = {4880, 12104, 12756, 6805, 142984, 120536, 51312, 49922};
        //selection planète
        int selection;
        //continuer ou quitter
        String choix;
        boolean quitter=false;

        //DEBUT PROGRAMME

        do {
            Scanner saisie = new Scanner(System.in);
            System.out.println("Sélectionner une planète : ");

            System.out.println("\t1 -> Mercure\n\t2 -> Vénus\n\t3 -> Terre\n\t4 -> Mars\n\t5 -> Jupiter\n\t6 -> Saturne\n\t7 -> Uranus\n\t8 -> Neptune");
            selection = saisie.nextInt();

            for (int i = 0; i <= nom.length - 1; i++) {
                if (selection <= 4) {
                    matiere = "Tellurique";
                } else {
                    matiere = "Gazeuse";
                }
            }
            Planete planete = new Planete(nom[selection - 1], matiere, diametre[selection - 1]);
            planete.Afficher();

            System.out.println("\nAppuyer sur la touche q pour quitter ou n'importe quelle touche pour continuer : ");
            choix = saisie.next();
            if (choix.equals("q")){
                quitter = true;
                saisie.close();
            }
        }while(!quitter);
        //FIN PROGRAMME
    }
}
