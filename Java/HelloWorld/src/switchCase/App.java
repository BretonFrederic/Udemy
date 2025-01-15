package switchCase;
import java.util.Scanner;

public class App {
    public static void main(String[] args){
        int mois;

        Scanner userInput = new Scanner(System.in);

        System.out.println("Saisir un nombre entre 1 et 12 :");
        mois = userInput.nextInt();

        switch (mois){
            case 1 :
                System.out.println("C'est le mois de janvier");
                break;
            case 2 :
                System.out.println("C'est le mois de février");
                break;
            case 3 :
                System.out.println("C'est le mois de mars");
                break;
            case 4 :
                System.out.println("C'est le mois de avril");
                break;
            case 5 :
                System.out.println("C'est le mois de mai");
                break;
            case 6 :
                System.out.println("C'est le mois de juin");
                break;
            case 7 :
                System.out.println("C'est le mois de juillet");
                break;
            case 8 :
                System.out.println("C'est le mois de août");
                break;
            case 9 :
                System.out.println("C'est le mois de septembre");
                break;
            case 10 :
                System.out.println("C'est le mois de octobre");
                break;
            case 11 :
                System.out.println("C'est le mois de novembre");
                break;
            case 12 :
                System.out.println("C'est le mois de décembre");
                break;
            default :
                System.out.println("Ce mois n'existe pas !");
        }
        userInput.close();
    }
}
