package jacob.scherber.slidingtiles;

import java.awt.Color;
import java.awt.Dimension;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.border.Border;

public class TileButton extends JButton {

	private static final long serialVersionUID = 1L;
	
	// exist across all tiles
	private static int tileSize = 0, maxTiles = 0;
	
	private ImageIcon imageIcon;
	
	// exist per tile instance
	private int imageId = 0, row = 0, col = 0;
	
	public TileButton(ImageIcon imageIcon, int imageId, int row, int col) {
		setImage(imageIcon, imageId);
		
		this.row = row;
		this.col = col;
		
		setBackground(Color.WHITE);
		//setBorder(null); // removes the border lines
		
		Dimension size = new Dimension(tileSize,tileSize);
		setPreferredSize(size);
		setFocusPainted(false);
	}
	
	// for the final win condition
	public void showImage() {
		
		setIcon(imageIcon);		
	}
	
	public void swap(TileButton otherTile) {
		ImageIcon otherImageIcon = otherTile.getImage();
		int otherImageId = otherTile.getImageId();
		
		// IDEs are awesome!
		otherTile.setImage(imageIcon, imageId);
		setImage(otherImageIcon, otherImageId);		
		
	}
	
	// getters
	private ImageIcon getImage() {
		return imageIcon;
	}

	// check if it's the null spot, to support sliding into it
	// every button has an imageIcon, can't check that
	// have to check if the the icon object has been applied
	public boolean hasNoImage() {
		return (getIcon() == null); 
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
	public void setImage(ImageIcon imageIcon, int imageId) {
		this.imageIcon = imageIcon;
		this.imageId = imageId;
		
		// last spot has no image to allow sliding into it
		if((maxTiles-1) == imageId) setIcon(null);
		else setIcon(imageIcon);

	}
	
	public static void setTileSizeAndMaxTiles(int size, int max) {
		tileSize = size;
		maxTiles = max;
	}
	
	
}
