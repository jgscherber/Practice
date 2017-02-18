package jacob.scherber.slidingtiles;

import java.awt.Color;
import java.awt.Dimension;

import javax.swing.ImageIcon;
import javax.swing.JButton;

public class TileButton extends JButton {

	private static final long serialVersionUID = 1L;
	
	// exist across all tiles
	private static int tileSize = 0, maxTiles = 0;
	
	private ImageIcon imageIcon;
	
	// exist per tile instance
	private int imageId = 0, row = 0, col = 0;
	
	public void setImage(ImageIcon imageIcon, int imageId) {
		this.imageIcon = imageIcon;
		this.imageId = imageId;
		
		// last spot has no image to allow sliding into it
		if((maxTiles-1) == imageId) setIcon(null);
		else setIcon(imageIcon);
	}
	
	public TileButton(ImageIcon imageIcon, int imageId, int row, int col) {
		setImage(imageIcon, imageId);
		
		this.row = row;
		this.col = col;
		
		setBackground(Color.WHITE);
		setBorder(null);
		
		Dimension size = new Dimension(tileSize,tileSize);
		setPreferredSize(size);
		setFocusPainted(false);
	}
	
	
	// getters
	private ImageIcon getImage() {
		return imageIcon;
	}
	
	public int getRow() {
		return row;
	}
	
	public int getCol() {
		return col;
	}
	
	public int getImageId() {
		return imageId;
	}
	
	// setters
	public static void setTileSizeAndMaxTiles(int size, int max) {
		tileSize = size;
		maxTiles = max;
	}
	
	
}
