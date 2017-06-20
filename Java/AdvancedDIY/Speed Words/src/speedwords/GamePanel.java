package speedwords;

import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionAdapter;
import java.util.ArrayList;
import java.util.Random;

import javax.swing.JPanel;

import jacob.scherber.mycomponents.FileIO;

public class GamePanel extends JPanel {
	private static final long serialVersionUID = 1L;
	
	// board sizing
	private static final int WIDTH = 500;
	private static final int HEIGHT = 300;
	
	private static final int START_X = WIDTH/2 - (LetterTile.SIZE * 7)/2;
	private static final int  START_Y = HEIGHT/2 - (LetterTile.SIZE/2);
	
	// word selection
	private static final String FILE_NAME = "/enable1_7.txt";
	private ArrayList<TileSet> tileSets = new ArrayList<TileSet>();
	private ArrayList<String> sevenLetterWords = new ArrayList<String>();
	private ArrayList<String> formedWords = new ArrayList<String>();
	
	private Random rand = new Random();
	
	// tile moving
	private TileSet movingTiles;
	private int mouseX;
	private int mouseY;
    private boolean outOfTime = false;
	
	private SpeedWords speedWords;
	private Dictionary dictionary = new Dictionary();
	
	public GamePanel(SpeedWords speedWords) {
		this.speedWords = speedWords;
		sevenLetterWords = FileIO.readTextFile(this, FILE_NAME);
		restart();
		
		// clicking
		addMouseListener(new MouseAdapter() {
			
			@Override
			public void mousePressed(MouseEvent e) {
				int x = e.getX();
				int y = e.getY();
				int mouseButton = e.getButton();
				// left click moves single tile, right moves whole tileset
				boolean leftClicked = mouseButton == MouseEvent.BUTTON1;
				clicked(x,y,leftClicked);
			}
			
			@Override
			public void mouseReleased(MouseEvent e) {
				released();
			}
		});
		// dragging
		addMouseMotionListener(new MouseMotionAdapter() {
			
			@Override
			public void mouseDragged(MouseEvent e) {
				int x = e.getX();
				int y = e.getY();
				dragged(x,y);
			}
			
		});
	}// end GamePanel()
	
	private void dragged(int x, int y) {
		if(x>0 && x < WIDTH && 
				y > 0 && y < HEIGHT){
			if(movingTiles != null) {
				int changeX = x - mouseX;
				int changeY = y - mouseY;
				movingTiles.changeXY(changeX, changeY);
				mouseX = x;
				mouseY = y;
				repaint();
			}
		}
	}

	private void released() {

		// tile dropped on top of another - connect them
		if(movingTiles != null) {
			boolean addedToTiles = false;
			for(int i = 0; i < tileSets.size() && !addedToTiles; i++) {
				TileSet tileSet = tileSets.get(i);
				addedToTiles = tileSet.insertTiles(movingTiles);
				if(addedToTiles) {
					movingTiles = null;
					checkWord(tileSet);
				}
			}
			
		}
		// not dropped on top of another - add back to list of tileSets
		if(movingTiles != null) {
			String s = movingTiles.toString();
			int x = movingTiles.getX();
			int y = movingTiles.getY();
			TileSet newTileSet = new TileSet(s,x,y);
			tileSets.add(0,newTileSet);
			checkWord(newTileSet);
			movingTiles = null;
			
		}	
		repaint();
	}

	private void clicked(int x, int y, boolean leftClicked) {
		
			// no other movingTiles already selected
			if(movingTiles == null && !outOfTime) {
				mouseX = x;
				mouseY = y;
				
				for(int i = 0; i < tileSets.size() && movingTiles == null; i++) {
					TileSet tileSet = tileSets.get(i);
					if(tileSet.contains(mouseX, mouseY)) {
						if(leftClicked) {
							movingTiles = tileSet.removeAndReturn1TileAt(mouseX, mouseY);
							if(tileSet.getNumberofTiles() == 0) {
								tileSets.remove(i);
							} else {
							    checkWord(tileSet);
                            }
						} else {
							movingTiles = tileSet;
							tileSets.remove(i);
						}
					}				
				}
				
				repaint();
				
			}// end null check
		} // end clicked()

    private void checkWord(TileSet tileSet) {
	    String s = tileSet.toString();
        boolean isAWord = dictionary.isAWord(s);
        boolean foundBefore = formedWords.contains(s);

        if(isAWord && !foundBefore) {
            tileSet.setValid(true);
            int points = tileSet.getPoints();
            speedWords.addToScore(points);
            // if first word, add it
            if(formedWords.size() == 0) {
                formedWords.add(s);
            } else {
                // else insert the word before the first alphabetically less
                boolean added = false;
                for(int i = 0; i < formedWords.size() && !added; i++) {
                    String formedWord = formedWords.get(i);
                    int difference = formedWord.compareTo(s);
                    if (difference > 0) {
                        formedWords.add(i, s);
                        added = true;
                    }
                }
                // else add it to the end
                if (!added) {
                    formedWords.add(s);
                }
            }
            // speedWords is the game instance assigned in the constructor

            speedWords.setWordList(formedWords);
        } else {
            tileSet.setValid(false);
        }
    }

    public void restart() {
        // removes existing tilesets, gets a new word, creates a tileset with it, adds it
        tileSets.clear();
        formedWords.clear();
        int range = sevenLetterWords.size();
        int choose = rand.nextInt(range);
        String s = sevenLetterWords.get(choose);

        TileSet tileSet = new TileSet(s, START_X, START_Y);
        tileSets.add(tileSet);
        checkWord(tileSet);
        outOfTime = false;
        movingTiles = null;
        repaint();
    }//end restart()

    public void setOutOfTime(boolean outOfTime) {
	    this.outOfTime = outOfTime;
    }

    // overrides
    @Override
	public void paintComponent(Graphics g) {
		
		
		// drawing the background
		g.setColor(SpeedWords.TAN);
		g.fillRect(0, 0, WIDTH, HEIGHT); // was only drawing a rectangle, not filling, not covering junk in background
		
        // drawing all curent tile sets
		for(int i = tileSets.size() - 1; i > -1; i--) {
			tileSets.get(i).draw(g);
		}
		
		// drawing moving tiles
		if(movingTiles != null) {
			// uses TileSet's draw (useful definition of a "container" class)
			movingTiles.draw(g);
		}
		
    }
	
	@Override
	public Dimension getPreferredSize() {
		return (new Dimension(WIDTH, HEIGHT));
	}

}// end class
