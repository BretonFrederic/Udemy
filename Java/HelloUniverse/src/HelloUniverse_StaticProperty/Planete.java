package HelloUniverse_StaticProperty;

public class Planete {
    String nom;
    int diametre;
    String matiere;
    int totalVisiteurs;
    Atmosphere atmosphere;
    Vaisseau vaisseauAccoste;
    static String forme = "Sphérique";
    
    int revolution(int degres){
        System.out.println("Je suis la planète "+nom+" et je tourne autour de mon étoile de "+degres+" degrés.");
        return degres/360;
    }
    
    int rotation(int degres){
        System.out.println("Je suis la planète "+nom+" et je tourne sur moi-même de "+degres+" degrés.");
        return degres/360;
    }
    
    Vaisseau accueillirVaisseau(Vaisseau nouveauVaisseau){
        
        totalVisiteurs+=nouveauVaisseau.nbPassagers;
        
        Vaisseau vaisseauPrecedent=vaisseauAccoste;
        
        vaisseauAccoste=nouveauVaisseau;
        
        return vaisseauPrecedent;
        
    }

    static String expansion(double dist){
        if(dist < 14){
            return "Oh la la mais c'est super rapide !";
        }
        else{
            return "Je rêve ou c'est plus rapide que la lumière ?";
        }
    }
}
