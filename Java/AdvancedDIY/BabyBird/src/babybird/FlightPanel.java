package babybird;


import javax.swing.*;
import java.awt.*;

public class FlightPanel extends JPanel {

    public static final int WIDTH = 600;
    public static final int HEIGHT = 600;
    private BabyBird babyBird;

    public FlightPanel(BabyBird babyBird) {
        this.babyBird = babyBird;

    }

    public Dimension getPreferredSize() {
        return new Dimension(WIDTH, HEIGHT);
    }

    public void paintComponent(Graphics g) {
        // background
        g.setColor(Color.BLUE);
        g.fillRect(0,0,WIDTH,HEIGHT);

        // bird

        // walls

    }

}
