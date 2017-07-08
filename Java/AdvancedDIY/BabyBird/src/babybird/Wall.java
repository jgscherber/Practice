package babybird;

import jacob.scherber.mycomponents.FileIO;

import java.awt.*;
import java.awt.image.BufferedImage;

public class Wall {

    private static final String WALL_IMAGE_FILE = "/wall.jpg";
    private static BufferedImage wallImage;
    private static int width = 72; // width of the walls
    private static int height = 600;


//    private int x = FlightPanel.WIDTH;
    private int x = 300;
    private int bottomY;
    private int topHeight;
    private int bottomHeight;

    private BufferedImage topImage;
    private BufferedImage bottomImage;

    public Wall() {
        if (wallImage == null) {
            wallImage = FileIO.readImageFile(this, WALL_IMAGE_FILE);
            width = wallImage.getWidth();
            height = wallImage.getHeight();
        }

        topHeight = 100;
        int gap = 150;
        bottomY = topHeight + gap;
        bottomHeight = FlightPanel.HEIGHT - bottomY;

        // black bars on the ends of the images
        topImage = wallImage.getSubimage(0, height - topHeight, width, topHeight);
        bottomImage = wallImage.getSubimage(0, 0, width, bottomHeight);
    }

    private static final int CHANGE_X = -10; // left-edge is 0

    public void move() {
        x += CHANGE_X;
    }

    public boolean isPastWindowEdge() {
        int rightEdgeX = x + width; // right edge of the wall
        return (rightEdgeX < 0);
    }

    public void draw(Graphics g) {
        if (wallImage == null) {
            g.setColor(Color.CYAN);
            g.fillRect(x, 0, width, topHeight);
            g.fillRect(x, bottomY, width, bottomHeight);
        } else {
            g.drawImage(topImage, x, 0, null);
            g.drawImage(bottomImage, x, bottomY, null);
        }
    }

} // end Wall class
