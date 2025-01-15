package HelloUniverse_ObjProperty;

public class Planete {
    String nom;
    int diametre;
    String matiere;
    int nbTotalHumains;
    Atmosphere atmosphere;
    Vaisseau vaisseauActuellementAcoste;
    
    int revolution(int degres){
        System.out.println("Je suis la planète "+nom+" et je tourne autour de mon étoile de "+degres+" degrés.");
        return degres/360;
    }
    
    int rotation(int degres){
        System.out.println("Je suis la planète "+nom+" et je tourne sur moi-même de "+degres+" degrés.");
        return degres/360;
    }

    Vaisseau accueillirVaisseau(Vaisseau _vaisseau){
        nbTotalHumains = nbTotalHumains+_vaisseau.nbPassagers;
        if(vaisseauActuellementAcoste == null){
            System.out.println("Aucun vaisseau ne s'en va.");
        }else{
            System.out.println("Un vaisseau de type " + vaisseauActuellementAcoste.type + " doit s'en aller.");
        }
        Vaisseau vaisseauPrecedent = vaisseauActuellementAcoste;
        vaisseauActuellementAcoste = _vaisseau;
        return vaisseauPrecedent;
    }
}
