import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.CheckBox;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.scene.text.Text;
import javafx.stage.Stage;

import java.util.ArrayList;
import java.util.HashSet;

public class TotoGUI extends Application {
    public void start(Stage stage) {

        // 9.feladat a.)
        Text felirat = new Text("Kérem a forduló eredményeit [1, 2, X]:");
        TextField eredmenyInput = new TextField("12X12X12X12X12");
        eredmenyInput.setPrefWidth(40);

        CheckBox nemMegfeleloKiemnetekSzamaCheckbox = new CheckBox("Nem megfelelő a kimenetek száma (14)");
        nemMegfeleloKiemnetekSzamaCheckbox.setDisable(true);
        CheckBox helytelenKarakterekCheckbox = new CheckBox("Helytelen karakter(ek) a kimenetben ()");
        helytelenKarakterekCheckbox.setDisable(true);

        Button mentesGomb = new Button("Eredmények mentése");

        GridPane gridPane = new GridPane();
        gridPane.add(felirat, 0, 0);
        gridPane.add(eredmenyInput, 0, 1);
        gridPane.add(nemMegfeleloKiemnetekSzamaCheckbox, 0, 2);
        gridPane.add(helytelenKarakterekCheckbox, 0, 3);
        gridPane.add(mentesGomb, 0, 4);

        // 9.feladat b.) és c.)
        eredmenyInput.textProperty().addListener((obs, oldText, newText) -> {
            char[] karakterek = newText.toCharArray();
            ArrayList<Character> hibak = new ArrayList<>();
            for (char c : karakterek) {
                if ("12X".indexOf(c) < 0) {
                    hibak.add(c);
                }
            }
            boolean hibasKimenetSzam = newText.length() != 14;
            boolean hibasKarakterek = hibak.size() > 0;

            nemMegfeleloKiemnetekSzamaCheckbox.setSelected(hibasKimenetSzam);
            helytelenKarakterekCheckbox.setSelected(hibasKarakterek);

            nemMegfeleloKiemnetekSzamaCheckbox.textProperty().setValue("Nem megfelelő a kimenetek száma (" + newText.length() + ")");
            StringBuilder hibakOsszefuzve = new StringBuilder();
            for (Character c : hibak) {
                hibakOsszefuzve.append(c);
                hibakOsszefuzve.append(";");
            }
            helytelenKarakterekCheckbox.textProperty().setValue("Helytelen karakter(ek) a kimenetben (" + hibakOsszefuzve + ")");

            // 9.feladat d.)
            mentesGomb.setDisable(hibasKimenetSzam || hibasKarakterek);
        });

        gridPane.setPadding(new Insets(20, 20, 20, 20));
        gridPane.setVgap(10);
        gridPane.setAlignment(Pos.BASELINE_LEFT);
        Scene scene = new Scene(gridPane, 420, 180);
        stage.setTitle("Totó eredmény ellenőrző");
        stage.setScene(scene);
        stage.show();
    }
}
