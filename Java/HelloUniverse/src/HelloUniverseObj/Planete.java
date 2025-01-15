package HelloUniverseObj;

public class Planete {
    //attributs
    private String nom;
    private String matiere;
    private long diametre;

    //méthodes

    public void Afficher(){
        System.out.println("Le nom de la planete est : "+this.nom);
        System.out.println("C'est une planète de type : "+this.matiere);
        System.out.println("Le diamètre de la planete est : "+this.diametre+" kilomètres");
    }

    //constructeurs

    Planete(){
        nom = "Mars";
        matiere = "tellurique";
        diametre = 6779;
    }

    Planete(String _nom, String _matiere, long _diametre){
        nom = _nom;
        matiere = _matiere;
        diametre = _diametre;
    }
}
