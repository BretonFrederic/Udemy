package HelloUniverse_ObjProperty;

public class App {
    public static void main(String... args) {
        Planete mercure = new Planete();
        mercure.nom = "Mercure";
        mercure.diametre = 4880;
        mercure.matiere = "Tellurique";
        Planete venus = new Planete();
        venus.nom = "Venus";
        venus.diametre = 12100;
        venus.matiere = "Tellurique";
        Planete terre = new Planete();
        terre.nom = "Terre";
        terre.diametre = 12756;
        terre.matiere = "Tellurique";
        Planete mars = new Planete();
        mars.nom = "Mars";
        mars.diametre = 6792;
        mars.matiere = "Tellurique";
        Planete jupiter = new Planete();
        jupiter.nom = "Jupiter";
        jupiter.diametre = 142984;
        jupiter.matiere = "Gazeuse";
        Planete saturne = new Planete();
        saturne.nom = "Saturne";
        saturne.diametre = 120536;
        saturne.matiere = "Gazeuse";
        Planete uranus = new Planete();
        uranus.nom = "Uranus";
        uranus.diametre = 51118;
        uranus.matiere = "Gazeuse";
        Planete neptune = new Planete();
        neptune.nom = "Neptune";
        neptune.diametre = 49532;
        neptune.matiere = "Gazeuse";
        
        Atmosphere atmosphereUranus = new Atmosphere();
        atmosphereUranus.tauxHydrogene = 83f;
        atmosphereUranus.tauxMethane = 2.5f;
        atmosphereUranus.tauxHelium = 15f;

        uranus.atmosphere = atmosphereUranus;

        Vaisseau nouveauVaisseau = new Vaisseau();
        nouveauVaisseau.type = "FREGATE";
        nouveauVaisseau.nbPassagers = 9;

        mars.accueillirVaisseau(nouveauVaisseau);

        Vaisseau autreVaisseau = new Vaisseau();
        autreVaisseau.type = "CROISEUR";
        autreVaisseau.nbPassagers = 42;

        mars.accueillirVaisseau(autreVaisseau);

        System.out.println("Le nombre d'humains ayant déjà séjourné sur Mars est actuellement de " +  mars.nbTotalHumains);

        System.out.println("L'atmosphère d'Uranus est compoée : ");
        System.out.println("A " + uranus.atmosphere.tauxHydrogene + "% d'hydrogène");
        System.out.println("A " + uranus.atmosphere.tauxArgon + "% d'argon");
        System.out.println("A " + uranus.atmosphere.tauxAzote + "% d'azote");
        System.out.println("A " + uranus.atmosphere.tauxDioxydeCarbon + "% de dioxyde de carbone");
        System.out.println("A " + uranus.atmosphere.tauxHelium + "% d'hélium");
        System.out.println("A " + uranus.atmosphere.tauxMethane + "% de méthane");
        System.out.println("A " + uranus.atmosphere.tauxSodium + "% de sodium");
    }
}
