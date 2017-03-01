package mazegenerator;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;

import javax.swing.JPanel;

public class Cell extends JPanel {

	private static final long serialVersionUID = 1L;
	
	public static final int 
					SIZE = 20, 
					TOP=0, 
					RIGHT=1, 
					BOTTOM=2, 
					LEFT=3;
	
	private int 
			row = -1, 
			col=-1;
	
	private boolean[] 
			wall = {true, true, true, true}, // top, right, bottom, left
			path = {false, false, false, false};
	
	private boolean 
				current = false,
				end = false;
	
	public Cell(int row, int col) {
		this.row = row;
		this.col = col;
		
	}
	
	public void addPath(int side) {
		path[side] = true;
		repaint();
	}
	
	public void setCurrent(boolean current) {
		this.current = current;
		repaint();
	}
	
	public void setEnd(boolean end) {
		this.end = end;
		repaint();
	}
	
	public int getRow() {
		return row;
	}
	
	public int getCol() {
		return col;
	}
	
	public boolean isWall(int index) {
		return wall[index];
	}
	
	// if it has been added to the maze, at least one side will have been changed
	public boolean hasAllWalls() {
		return (wall[TOP] && wall[RIGHT] && wall[BOTTOM] && wall[LEFT]);
	}
	
	public void removeWall(int w) {
		wall[w] = false;
		repaint(); // inherited
	}
	
	public void openTo(Cell neighbor) {
		if(neighbor.getRow() > row) {
			removeWall(BOTTOM);
			neighbor.removeWall(TOP);
		}
		else if (neighbor.getRow() < row) {
			removeWall(TOP);
			neighbor.removeWall(BOTTOM);
		}
		else if (neighbor.getCol() > col) {
			removeWall(RIGHT);
			neighbor.removeWall(LEFT);
		}
		else if (neighbor.getCol() < col) {
			removeWall(LEFT);
			neighbor.removeWall(RIGHT);
		}
		
	}
	

	// overridden
	public void paintComponent(Graphics g) {
		// draws background
		g.setColor(Color.WHITE);
		g.fillRect(0, 0, SIZE, SIZE);
		
		// draws walls
		g.setColor(Color.BLACK);
		if(wall[TOP]) g.drawLine(0, 0, SIZE, 0);
//		if(wall[RIGHT]) g.drawLine(SIZE, 0, SIZE, SIZE);
//		if(wall[BOTTOM]) g.drawLine(0, SIZE, SIZE, SIZE);
		if(wall[LEFT]) g.drawLine(0, 0, 0, SIZE);
		
		// draws path (top, right, bottom, left)
		int MID = SIZE/2; 		
		g.setColor(Color.GREEN);
		if(path[TOP]) g.drawLine(MID, 0, MID, MID);
		if(path[RIGHT]) g.drawLine(SIZE, MID, MID, MID);
		if(path[BOTTOM]) g.drawLine(MID, SIZE, MID, MID);
		if(path[LEFT]) g.drawLine(0, MID, MID, MID);
		
		// draws balls
		if(current) {
			g.setColor(Color.GREEN);
			g.fillOval(3,3,SIZE-6,SIZE-6);
		}
		
		if(end) {
			g.setColor(Color.RED);
			g.fillOval(3,3,SIZE-6,SIZE-6);
		}
	}
	
	// overridden
	public Dimension getPreferredSize() {
		return new Dimension(SIZE, SIZE);
	}
	

}
