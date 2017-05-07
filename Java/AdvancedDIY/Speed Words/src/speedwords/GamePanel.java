package speedwords;

import java.awt.Dimension;
import java.awt.Graphics;
import java.util.ArrayList;
import java.util.Random;

import javax.swing.JPanel;

import jacob.scherber.mycomponents.FileIO;

public class GamePanel extends JPanel {
	private static final long serialVersionUID = 1L;
	
	private static final int WIDTH = 500;
	private static final int HEIGHT = 300;
	
	private static final int START_X = WIDTH/2 - (LetterTile.SIZE * 7)/2;
	private static final int  START_Y = HEIGHT/2 - (LetterTile.SIZE/2);
	
	private static final String FILE_NAME = "/enable1_7.txt";
	private ArrayList<TileSet> tileSets = new ArrayList<TileSet>();
	private ArrayList<String> sevenLetterWords = new ArrayList<String>();
	
	private Random rand = new Random();
	
	private SpeedWords speedWords;
	
	public GamePanel(SpeedWords speedWords) {
		this.speedWords = speedWords;
		sevenLetterWords = FileIO.readTextFile(this, FILE_NAME);
		restart();
	}
	
	@Override
	protected void paintComponent(Graphics g) {
		// drawing the background
		g.setColor(SpeedWords.TAN);
		g.drawRect(0, 0, WIDTH, HEIGHT);
		
        // drawing all curent tile sets
		for(TileSet tileSet : tileSets) {
			tileSet.draw(g);
		}

    }
	
	@Override
	public Dimension getPreferredSize() {
		return (new Dimension(WIDTH, HEIGHT));
	}
	
	public void restart() {
		// removes existing tilesets, gets a new word, creates a tileset with it, adds it
		tileSets.clear();
		int range = sevenLetterWords.size();
		int choose = rand.nextInt(range);
		String s = sevenLetterWords.get(choose);
		
		TileSet tileSet = new TileSet(s, START_X, START_Y);
		tileSets.add(tileSet);
		repaint();
	}

}
