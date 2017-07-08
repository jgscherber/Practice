package babybird;


import jacob.scherber.mycomponents.FileIO;

import java.awt.*;
import java.awt.image.BufferedImage;

public class Bird {
    private static final String
            BIRD_FLAP_UP = "/babyBirdFlapUp.gif",
            BIRD_GLIDE = "/babyBirdGlide.gif",
            BIRD_FLAP_DOWN = "/babyBirdFlapDown.gif";

    private static final int
            FLAP_UP = 0,
            FLAP_GLIDE = 1,
            FLAP_DOWN = 2;

    private BufferedImage[] birds = new BufferedImage[3];
    private int width;
    private int height;
    private int x = 10;
    private int y = 10;
    private int flap = FLAP_GLIDE;
    private boolean flapping = false;
    private int panelHeight;

    public Bird(int panelHeight) {
        birds[FLAP_UP] = FileIO.readImageFile(this, BIRD_FLAP_UP);
        birds[FLAP_GLIDE] = FileIO.readImageFile(this, BIRD_GLIDE);
        birds[FLAP_DOWN] = FileIO.readImageFile(this, BIRD_FLAP_DOWN);
        width = birds[0].getWidth(); // BufferedImage.getWidth()
        this.height = birds[0].getHeight();
        this.panelHeight = panelHeight;
    }

    public void draw(Graphics g) {
        // flap, x, y are instance variables
        g.drawImage(birds[flap], x, y, null);

    }

    private static final int FLAP_FORCE = -8; // 0 is the top

    public void startFlapping() {
        flapping = true;
        changeY = FLAP_FORCE;

    }

    private static final float GRAVITY = 0.5f;
    private float changeY = 0f;

    public void move() {
        // Y - movement
        int changeYint = (int) changeY;
        int distanceFromTop = y + height + changeYint;
        if (distanceFromTop > panelHeight) {
            y = panelHeight-height;
            changeY=0;
        } else {
            y += changeY;
            changeY += GRAVITY;
            // no flapping while falling
            if (changeY > 0) {
                flapping = false;
            }
        }
        // X - movement


        if (flapping) {
            flap += 1;
            flap %= 3;
        } else {
            flap = FLAP_GLIDE;
        }
    }

}
