public class App {
    public static void main(String[] args) {
        Voiture voitureDeMichel = new Voiture();
        voitureDeMichel.nbPortes = 3;
        voitureDeMichel.automatique = true;
        voitureDeMichel.couleur = "Verte";

        String chaine1 = new String("leCielEstBleu");
        String chaine2 = new String("leCielEstBleu");

        boolean egauxOuPas = chaine1.equals(chaine2);
        System.out.println(egauxOuPas);

        int nouvelleVitesse = voitureDeMichel.Accelerer(50);
        System.out.println("La nouvelle vitesse est de "+nouvelleVitesse);

        Voiture voitureDeJerome = new Voiture();
        voitureDeJerome.nbPortes = 5;
        Moteur moteurDiesel = new Moteur();
        moteurDiesel.carburation = "Diesel";
        moteurDiesel.nbCylindres = 6;

        // Le moteur de la voiture de Jérôme est une référence à moteurDiesel
        voitureDeJerome.moteur = moteurDiesel;

        // Le moteur de la voiture de Michel est une référence à moteurDiesel
        voitureDeMichel.moteur = moteurDiesel;

        // En modifiant moteurDiesel le moteur de Jérôme et Michel changent ils font référence à moteurDiesel
        moteurDiesel.nbCylindres = 8;

        System.out.println("Le nombre de cylindre de la voiture de Jérôme est " + voitureDeJerome.moteur.nbCylindres);
        System.out.println("Le nombre de cylindre de la voiture de Michel est " + voitureDeMichel.moteur.nbCylindres);

        Passager passager = new Passager();
        passager.nom = "Dupont";
        passager.prenom = "Vincent";
        Ville auckland = new Ville();
        auckland.nom = "Auckland";
        Ville destination = voitureDeMichel.Transporter(passager, auckland);
        System.out.println("Le passager est arrivé dans la ville de " + destination.nom);
        System.out.println("Le nombre de roues de la voiture de Michel est " + voitureDeMichel.nbRoues);
        System.out.println("Le nombre de roues de la voiture de Jérôme est " + voitureDeJerome.nbRoues);
        System.out.println("Le nombre de roues d'une voiture en général est " + Voiture.nbRoues);
        // Voiture.nbRoues = 5;
        System.out.println("Le nombre de roues de la voiture de Michel est " + voitureDeMichel.nbRoues);
        System.out.println("Le nombre de roues de la voiture de Jérôme est " + voitureDeJerome.nbRoues);
        System.out.println("Le nombre de roues d'une voiture en général est " + Voiture.nbRoues);

        Voiture.Klaxonner();
        Voiture.Tourner(true, 45);
    }
}
