package speedwords;

import jacob.scherber.mycomponents.FileIO;

import javax.swing.JPanel;
import java.awt.*;
import java.awt.image.BufferedImage;

public class LetterTile extends JPanel {
	private static final long serialVersionUID = 1L;
	private static final String IMAGE_NAME = "/WoodTile.jpg";
	private static BufferedImage image;
    private static final Font BIG_FONT = new Font(Font.DIALOG, Font.BOLD, 30);
    private static final Font SMALL_FONT = new Font(Font.DIALOG, Font.BOLD, 12);
    private static final String ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static final int[] LETTER_POINTS = {1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 3,
            1, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 10};

    private FontMetrics bigFM = getFontMetrics(BIG_FONT);
    private FontMetrics smallFM = getFontMetrics(SMALL_FONT);
    private int points;

    public static final int SIZE = 40;
	private String letter;

	public LetterTile(String letter) {

	    this.letter = letter;
        if (image == null) {
            // encapsulated all the try-catch
            image = FileIO.readImageFile(this, IMAGE_NAME);
        }

        int index = ALPHABET.indexOf(letter);
        points = LETTER_POINTS[index];
    }

	public void draw(Graphics g, int x, int y) {
	    // draw the square
        if (image == null) {
            g.setColor(Color.WHITE);
            g.fillRect(x, y, SIZE, SIZE);
        } else {
            g.drawImage(image, x, y, SIZE, SIZE, null);
        }
	    g.setColor(Color.BLACK);
	    g.drawRect(x,y,SIZE-1,SIZE-1);

	    // draw the letter
	    g.setFont(BIG_FONT);
        int letterWidth = bigFM.stringWidth(letter);
        int letterX = x + (SIZE - letterWidth) / 2;
        // draws the string from the bottom-left corner
        int letterY = (SIZE *3 / 4) + y;
        g.drawString(letter, letterX, letterY);

        // draw the points
        g.setFont(SMALL_FONT);
        String pointsString = "" + points;
        int pointsWidth = smallFM.stringWidth(pointsString);
        int pointsX = SIZE - 2 - pointsWidth + x;
        int pointsY = (SIZE * 34 / 40) + y;
        g.drawString(pointsString,pointsX,pointsY);
    }

    @Override
    public Dimension getPreferredSize() {
        return new Dimension(SIZE,SIZE);
    }

    public String getLetter() {
        return letter;
    }

    public int getPoints() {
        return points;
    }
}
