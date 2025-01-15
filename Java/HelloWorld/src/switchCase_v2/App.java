package switchCase_v2;
import java.util.Scanner;
public class App {
    public static void main(String[] args){
        int mois;

        Scanner userInput = new Scanner(System.in);
        System.out.println("Saisir un nombre entre 1 et 12 : ");
        mois = userInput.nextInt();

        switch (mois){
            case 1 :
            case 2 :
            case 3 :
                System.out.println("C'est l'hiver");
                break;
            case 4 :
            case 5 :
            case 6 :
                System.out.println("C'est le printemps");
                break;
            case 7 :
            case 8 :
            case 9 :
                System.out.println("C'est l'été");
                break;
            case 10 :
            case 11 :
            case 12 :
                System.out.println("C'est l'automne");
                break;
            default :
                System.out.println("Ce mois n'existe pas !");
        }
        userInput.close();
    }
}
