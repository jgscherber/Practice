package babybird;


import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.util.ArrayList;

public class FlightPanel extends JPanel {

    public static final int WIDTH = 600;
    public static final int HEIGHT = 600;
    private BabyBird babyBird;
    private Bird bird = new Bird(HEIGHT);
    private Timer timer;
    private ArrayList<Wall> walls = new ArrayList<>();

    public FlightPanel(BabyBird babyBird) {
        this.babyBird = babyBird;
        setFocusable(true);
        requestFocusInWindow();


        // listeners
        addKeyListener(new KeyAdapter() {
            @Override
            public void keyReleased(KeyEvent e) {
                char key = e.getKeyChar();
                if (key == ' ') {
                    bird.startFlapping();
                }
            }
        });

        // timer
        timer = new Timer(40, new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                timedAction();
                for (int i = 0; i < walls.size(); i++) {
                    Wall wall = walls.get(i);
                    if(wall.isPastWindowEdge()) walls.remove(i);
                }
            }
        });
        // build walls
        Wall wall = new Wall();
        walls.add(wall);

        timer.start();
    }

    private void timedAction() {
        // move bird
        bird.move();
        // move walls

        // collisioin check

        // new wall?

        // repaint
        repaint(); // always need to repaint after changing something
    }

    public Dimension getPreferredSize() {
        return new Dimension(WIDTH, HEIGHT);
    }

    public void paintComponent(Graphics g) {
        // background
        g.setColor(Color.BLUE);
        g.fillRect(0, 0, WIDTH, HEIGHT);

        // bird
        bird.draw(g);

        // walls
        for (Wall wall: walls) {
            wall.draw(g);
        }
    }

}
