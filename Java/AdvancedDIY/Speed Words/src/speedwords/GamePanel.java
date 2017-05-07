package speedwords;

import java.awt.Dimension;
import java.awt.Graphics;

import javax.swing.JPanel;

public class GamePanel extends JPanel {
	private static final long serialVersionUID = 1L;
	
	private static final int WIDTH = 500;
	private static final int HEIGHT = 300;
	
	private SpeedWords speedWords;
	
	public GamePanel(SpeedWords speedWords) {
		this.speedWords = speedWords;
	}
	
	@Override
	protected void paintComponent(Graphics g) {
		// drawing the background
		g.setColor(SpeedWords.TAN);
		g.drawRect(0, 0, WIDTH, HEIGHT);

        LetterTile tile = new LetterTile("A");
        tile.draw(g, 100, 100);

    }
	
	@Override
	public Dimension getPreferredSize() {
		return (new Dimension(WIDTH, HEIGHT));
	}

}
