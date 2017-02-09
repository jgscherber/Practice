package jacob.scherber.framed;

import java.awt.Color;
import java.awt.Dimension;

import javax.swing.JButton;


public class LightButton extends JButton {

	private static final long serialVersionUID = 1L;
	
	private static final int MAXSIZE = 50;
	
	private int row = 0;
	private int col = 0;
	
	public LightButton(int row, int col) {
		this.row = row;
		this.col = col;
		setBackground(Color.BLACK);
		Dimension size = new Dimension(MAXSIZE, MAXSIZE);
		setPreferredSize(size);
		
	}
	
	public int getRow() {
		return row;
	}
	
	public int getCol() {
		return col;
	}
	
	public boolean isLit() {
		return (getBackground().equals(Color.RED)); // RED is an Color object
	}
	
	// could use setBackground() direct, this more readable
	public void turnOn() {
		setBackground(Color.RED);
	}
	
	public void turnOff() {
		setBackground(Color.BLACK);
	}
	
	public void toggle() {
		if(isLit()) {
			turnOff();
		}
		else{
			turnOn();		
		}
	}
	
}
