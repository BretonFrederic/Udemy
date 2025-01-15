public class Voiture {
    int nbPortes = 5;
    boolean automatique;
    String couleur;
    int rapportCourant;
    int vitesse;
    Moteur moteur;
    static int nbRoues = 4;

    // Constructeur par defaut et sans paramètre qui existe même si on ne l'écrit pas
    Voiture(){
        System.out.println("Une voiture est en cours de construction");
    }

    static void Klaxonner(){
        System.out.println("Tutut!!!");
    }

    int Accelerer(){
        System.out.println("J'accélère");
        return 100;
    }

    int Accelerer(int _vitesse){
        System.out.println("j'accélère");
        this.vitesse = this.vitesse + _vitesse;
        return this.vitesse;
    }

    int PasserRapport(boolean _augmenter){
        if(_augmenter){
            rapportCourant++;
        }else{
            rapportCourant--;
        }
        return rapportCourant;
    }

    static void Tourner(boolean droite, int angle){
        String droiteOuGauche = null;
        if(droite){
            droiteOuGauche = "droite";
        }
        else{
            droiteOuGauche = "gauche";
        }
        System.out.println("Les " + nbRoues + " roues de la voiture tournent à " + droiteOuGauche + " d'un angle de " + angle);
    }

    void Tourner(String droiteOuGauche, int angle){
        System.out.println("La voiture va tourner à " + droiteOuGauche + " d'un angle de " + angle);
    }

    Ville Transporter(Passager _passager, Ville _VilleDeDepart){
        System.out.println("Je transporte un passager qui s'appelle " + _passager.prenom + " " + _passager.nom);
        System.out.println("Le passager est parti de la ville " + _VilleDeDepart.nom);

        Ville villeDeDestination = new Ville();
        villeDeDestination.nom = "Wellington";

        return villeDeDestination;
    }
}
