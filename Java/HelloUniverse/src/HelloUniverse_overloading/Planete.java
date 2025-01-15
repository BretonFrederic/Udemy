package HelloUniverse_overloading;

public class Planete {
    String nom;
    long diametre;
    String matiere;
    int totalVisiteurs;
    
    int revolution(int degres){
        System.out.println("Je suis la planète "+nom+" et je tourne autour de mon étoile de "+degres+" degrés.");
        return degres/360;
    }
    
    int rotation(int degres){
        System.out.println("Je suis la planète "+nom+" et je tourne sur moi-même de "+degres+" degrés.");
        return degres/360;
    }
    
    void accueillirVaisseau(int _nbHumains){
        totalVisiteurs += _nbHumains;
    }
    // Surcharge de la méthode accueillirVaisseau()
    void accueillirVaisseau(String _typeVaisseau){
        if(_typeVaisseau.equals("CHASSEUR")){
           totalVisiteurs += 3; 
        }else if(_typeVaisseau.equals("FREGATE")){
           totalVisiteurs += 12; 
        }else if(_typeVaisseau.equals("CROISEUR")){
           totalVisiteurs += 50; 
        }
    }
}
