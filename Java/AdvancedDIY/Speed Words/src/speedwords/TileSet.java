package speedwords;

import java.awt.Graphics;
import java.util.ArrayList;

public class TileSet {
	
	private static final int HIGHLIGHT_WIDTH = 2;
	private ArrayList<LetterTile> tiles = new ArrayList<LetterTile>();
	private int x = 0;
	private int y = 0;
	
	public TileSet(String word, int x, int y) {
		// word must be all capital letters
		for(int i = 0; i < word.length(); i++) {
			String letter = word.substring(i, i+1);
			LetterTile tile = new LetterTile(letter);
			
			tiles.add(tile);						
		}
		this.x = x;
		this.y = y;
	}
	
	public void draw(Graphics g) {
		for(int i = 0; i < getNumberofTiles(); i ++) {
			LetterTile tile = getTile(i);
			int xPos = x + (LetterTile.SIZE * i);
			// draw each tile using it's draw method
			tile.draw(g, xPos, y);
		}
	}// end draw()
	
	public void changeXY(int changeX, int changeY) {
		x += changeX;
		y+= changeY;
	}
	
	private int getWidth() {
		int width = getNumberofTiles() * LetterTile.SIZE;
		return width;
	}
	
	public boolean contains(int pointX, int pointY) {
		boolean contains = false;
		int width = getWidth();
		int height = LetterTile.SIZE;
		// (0,0) is top-left corner
		if(pointX >= x && pointX < (x + width) && 
				pointY >= y && pointY < (y + height)) {
			contains = true;
		}
		return contains;
	}
	
	public String toString() {
		String s = "";
		for(int i = 0; i < getNumberofTiles(); i++) {
			s += getTile(i).getLetter();
		}
		return s;
	}
	
	public int getX() {
		return x;
	}
	
	public int getY() {
		return y;
	}
	
	public int getNumberofTiles() {
		return tiles.size();
	}
	
	public LetterTile getTile(int i) {
		return tiles.get(i);
	}
	
	public TileSet removeAndReturn1TileAt(int clickedX, int clickedY) {
		TileSet tileSet = null;
		for(int i = 0; i < getNumberofTiles() && tileSet == null; i ++) {
			// tile boundaries
			int tileLeftEdge = x + (LetterTile.SIZE * i);
			int tileRightEdge = tileLeftEdge + LetterTile.SIZE;
			int tileTopEdge = y;
			int tileBottomEdge = tileTopEdge + LetterTile.SIZE;
			// click within tile area
			if(clickedX >= tileLeftEdge && clickedX <= tileRightEdge &&
					clickedY >= tileTopEdge && clickedY <= tileBottomEdge) {
				LetterTile tile = tiles.get(i);
				String letter = tile.getLetter();
				tileSet = new TileSet(letter, tileLeftEdge, tileTopEdge);
				tiles.remove(i);
				if(i == 0) {
					x += LetterTile.SIZE;
				}
			
				
			}
		}
		return tileSet;
	}
	
	public boolean insertTiles(TileSet droppedTiles) {
		boolean inserted = false;
		// tile location information
		int droppedTilesWidth = droppedTiles.getWidth();
		int droppedTilesHeight = LetterTile.SIZE;
		int droppedTilesLeft = droppedTiles.getX();
		int droppedTilesRight = droppedTilesLeft + droppedTilesWidth;
		int droppedTilesTop = droppedTiles.getY();
		int droppedTilesBottom = droppedTilesTop + droppedTilesHeight;
		// check if the dropped tiles over the row
		if(droppedTilesBottom > y && droppedTilesTop < (y+droppedTilesHeight)) {
			// check if overlaps the left edge of 1st tile
			if(droppedTilesRight >= x && droppedTilesRight <= (x + LetterTile.SIZE)){
				// insert dropped tile before the one they were dropped on
				for(int i = 0; i < droppedTiles.getNumberofTiles(); i++) { // add them all
					LetterTile tile = droppedTiles.getTile(i); // (inmutable access to internal ArrayList)
					tiles.add(i, tile);
					inserted = true;
				}
				x -= droppedTilesWidth;
			} else {
				// check if they overlap other tiles
				for(int i = 0; i < tiles.size() && !inserted; i++) {
					int compareX = x + (i * LetterTile.SIZE);
					if(droppedTilesLeft >- compareX && droppedTilesLeft <= (compareX + LetterTile.SIZE)) {
						// insert after first overlapped tile
						for(int j = 0; j < droppedTiles.getNumberofTiles(); j++) {
							LetterTile tile = droppedTiles.getTile(j);
							tiles.add(i+j+1,tile);
							inserted = true;
						}
					}
				}

					
			}// end horizonatal check
		}// end verticle check
		return inserted;
		
	}
}
