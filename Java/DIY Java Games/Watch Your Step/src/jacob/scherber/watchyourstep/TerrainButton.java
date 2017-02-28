package jacob.scherber.watchyourstep;

import java.awt.Color;
import java.awt.Dimension;

import javax.swing.JButton;

public class TerrainButton extends JButton {

	private static final long serialVersionUID = 1L;
	
	private static final int SIZE = 50;
	
	private int row=0;
	private int col=0;
	private int nextToHoles=0;
	
	private boolean revealed = false;
	private boolean hole = false;
	
	public TerrainButton(int row, int col) {
		this.row = row;
		this.col = col;
		Dimension size = new Dimension(SIZE,SIZE);
		setPreferredSize(size);
		
		
		
		
	}
	
	
	// getters
	public int getRow() { 
		return row;
	}
	
	public int getCol() {
		return col;
	}
	
	public boolean hasHole() {
		return hole;
	}
	
	public boolean isRevealed() {
		return revealed;
	}
	
	// setters
	public void setHole(boolean hasHole) {
		hole = hasHole;
	}

	public void increaseHoleCount() {
		nextToHoles++;
	}
	
	public boolean isNextToHoles() {
		return nextToHoles > 0;
	}
	
	public void reveal(boolean reveal) {
		revealed = reveal;
		if (revealed) {
			if(hole) {
				setBackground(Color.BLACK);
				setText("");
			}
			else {
				setBackground(Color.CYAN);
				if (isNextToHoles()) setText(Integer.toString(nextToHoles));
			}
		
			
		}
		else {
			setBackground(null);
			setText("");
		}
		setFocusPainted(false);
	} //end reveal

	public void reset() {
		//row=0;
		//col=0;
		nextToHoles=0;
		
		revealed = false;
		hole = false;
		
		setBackground(null);
		setText("");
	} // end reset



} //end class
