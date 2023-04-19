import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

// 7.feladat
class EredmenyElemzo {
    private String eredmenyek;

    private int dontetlenekSzama() {
        return megszamol('X');
    }

    private int megszamol(char kimenet) {
        return (int) eredmenyek.chars().filter(ch -> ch == kimenet).count();
    }

    public boolean memvoltDontetlenMerkozes() {
        return dontetlenekSzama() == 0;
    }

    EredmenyElemzo(String eredmenyek) {
        this.eredmenyek = eredmenyek;
    }
}

class Fordulo {
    private int ev;
    private int het;
    private int fordulo;
    private int t13p1;
    private int ny13p1;

    public int getT13P1(){
        return t13p1;
    }

    public int getNy13p1(){
        return ny13p1;
    }

    private String eredmeny;

    public String getEredmeny() {
        return eredmeny;
    }

    Fordulo(String sor) {
        String[] darabolt = sor.split(";");
        ev = Integer.parseInt(darabolt[0]);
        het = Integer.parseInt(darabolt[1]);
        fordulo = Integer.parseInt(darabolt[2]);
        t13p1 = Integer.parseInt(darabolt[3]);
        ny13p1 = Integer.parseInt(darabolt[4]);
        eredmeny = darabolt[5];
    }

    public void kiir() {
        System.out.println("        Év: " + ev);
        System.out.println("        Hét: " + het + ".");
        System.out.println("        Forduló: " + fordulo + ".");
        System.out.println("        Telitalálat: " + t13p1 + " db");
        System.out.println("        Nyeremény: " + ny13p1 + " Ft");
        System.out.println("        Eredmények: " + eredmeny);
    }
}

public class Toto {
    public static void main(String[] args) {
        // 2.feladat
        List<Fordulo> forduloList = new ArrayList<>();
        File inputFile = new File("toto.txt");
        try (Scanner scanner = new Scanner(inputFile)) {
            scanner.nextLine();
            while (scanner.hasNextLine()) {
                String aktualisSor = scanner.nextLine();
                Fordulo fordulo = new Fordulo(aktualisSor);
                forduloList.add(fordulo);
            }
        } catch (FileNotFoundException exception) {
            System.err.print("Fájl nem található!");
        }

        // 3. feladat
        System.out.println("3. feladat: Fordulók száma: " + forduloList.size());

        // 4.feladat
        int szelvenyDb = 0;
        for (Fordulo fordulo : forduloList) {
            szelvenyDb += fordulo.getT13P1();
        }
        System.out.println("4. feladat: Telitalálatos szelvények száma: " + szelvenyDb + " db");

        // 5.feladat
        double szumma = 0.0;
        double darabszam = 0;
        for (Fordulo fordulo : forduloList) {
            if(fordulo.getNy13p1() > 0){
                darabszam += fordulo.getT13P1();
                szumma += fordulo.getNy13p1() * fordulo.getT13P1();
            }
        }
        System.out.println("5. feladat: Átlag: " + Math.round(szumma / (double) darabszam) + " Ft");

        // 6.feladat
        Fordulo max = null;
        Fordulo min = null;
        for (Fordulo fordulo : forduloList) {
            if (fordulo.getNy13p1() > 0) {
                min = fordulo;
                max = fordulo;
            }
        }

        for (Fordulo fordulo : forduloList) {
            if (fordulo.getNy13p1() > max.getNy13p1()) {
                max = fordulo;
            }
            if (fordulo.getT13P1() > 0 && fordulo.getNy13p1() < min.getNy13p1()) {
                min = fordulo;
            }
        }
        System.out.println("6. feladat:");
        System.out.println("        Legnagyobb:");
        max.kiir();
        System.out.println();
        System.out.println("        Legkisebb:");
        min.kiir();

        // 8.feladat
        boolean voltDontetlenNelkuliFordulo = false;
        for (Fordulo fordulo : forduloList) {
            EredmenyElemzo elemzo = new EredmenyElemzo(fordulo.getEredmeny());
            if (elemzo.memvoltDontetlenMerkozes()) {
                voltDontetlenNelkuliFordulo = true;
                break;
            }
        }
        System.out.println("8. feladat: " + (voltDontetlenNelkuliFordulo ? "Volt" : "Nem volt") + " döntetlen nélküli forduló!");
    }
}
