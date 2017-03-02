package mazegenerator;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.util.ArrayList;
import java.util.Random;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.UIManager;

import jacob.scherber.mycomponents.TitleLabel;

public class MazeGenerator extends JFrame {

	private static final long serialVersionUID = 1L;

	private TitleLabel titleLabel = new TitleLabel("Maze");
	
	// really like this formatting...
	private int 
			rows=30,
			cols=rows, 
			row=0, 
			col=0, 
			endRow = rows-1, 
			endCol = cols-1;
	
	
	private Cell[][] cell; 
	
	private JPanel mazePanel = new JPanel();
	
	public static void main(String[] args) {
		
		try {
			String className = UIManager.getCrossPlatformLookAndFeelClassName();
			UIManager.setLookAndFeel(className);
		}
		catch(Exception e) {}
		
		EventQueue.invokeLater(new Runnable() {
			
			@Override
			public void run() {
				new MazeGenerator();
				
			}
		});
		
		

	}
	
	public MazeGenerator() {
		initGUI();
		setTitle("Maze Generator");
		setResizable(false);
		setVisible(true);
		setLocationRelativeTo(null);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		pack();
	}
	
	private void initGUI(){
		add(titleLabel,BorderLayout.PAGE_START);
		
		// center panel
		JPanel centerPanel = new JPanel();
		centerPanel.setBackground(Color.BLACK);
		add(centerPanel,BorderLayout.CENTER);
		// maze panel
		newMaze();
		centerPanel.add(mazePanel);
		// button panel
		JPanel buttonPanel = new JPanel();
		buttonPanel.setBackground(Color.black);
		add(buttonPanel, BorderLayout.PAGE_END);
		JButton newMazeButton = new JButton("New Maze");
		buttonPanel.add(newMazeButton,BorderLayout.CENTER);
		newMazeButton.setFocusable(false); // allow the listener to hold focus
		newMazeButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				newMaze();
				
			}
		});
		
		
		// listeners
		addKeyListener(new KeyAdapter() {
		 
						
			@Override
			public void keyReleased(KeyEvent e) {
				int keyCode = e.getKeyCode();
				moveBall(keyCode);
				
			}
			

			
		});
		
		
	} // end initGUI
	
	private void moveBall(int direction) {
		switch(direction) {
		case(KeyEvent.VK_UP):
			if(!cell[row][col].isWall(Cell.TOP)){
				moveTo(row-1, col,Cell.TOP,Cell.BOTTOM);
				
				while(!cell[row][col].isWall(Cell.TOP) 
						&& cell[row][col].isWall(Cell.LEFT) 
						&& cell[row][col].isWall(Cell.RIGHT)) { // can't go out of index because outside walls always exist
					moveTo(row-1, col,Cell.TOP,Cell.BOTTOM);				
				}
			}
			break;
		case(KeyEvent.VK_DOWN):
			if(!cell[row][col].isWall(Cell.BOTTOM)) { // can't go out of index because outside walls always exist
				moveTo(row+1, col,Cell.BOTTOM,Cell.TOP);
				while(!cell[row][col].isWall(Cell.BOTTOM) 
						&& cell[row][col].isWall(Cell.LEFT) 
						&& cell[row][col].isWall(Cell.RIGHT)) { 
					moveTo(row+1, col,Cell.BOTTOM,Cell.TOP);
				}
			}
			break;
		case(KeyEvent.VK_RIGHT):
			if(!cell[row][col].isWall(Cell.RIGHT)) { // can't go out of index because outside walls always exist
				moveTo(row, col+1,Cell.RIGHT,Cell.LEFT);			
				while(!cell[row][col].isWall(Cell.RIGHT) 
						&& cell[row][col].isWall(Cell.TOP) 
						&& cell[row][col].isWall(Cell.BOTTOM)) { 
					moveTo(row, col+1,Cell.RIGHT,Cell.LEFT);
				}
			}
			break;
		case(KeyEvent.VK_LEFT):
			if(!cell[row][col].isWall(Cell.LEFT)) { // can't go out of index because outside walls always exist
				moveTo(row, col-1,Cell.LEFT,Cell.RIGHT);
				while(!cell[row][col].isWall(Cell.LEFT) 
						&& cell[row][col].isWall(Cell.TOP) 
						&& cell[row][col].isWall(Cell.BOTTOM)) { 
					moveTo(row, col-1,Cell.LEFT,Cell.RIGHT);
				}
			}		
			break;
		}
	}
	
	private void moveTo(int nextRow, int nextCol, int fDir, int sDir) { // can't go out of index because outside walls always exist
		cell[row][col].setCurrent(false);
		cell[row][col].addPath(fDir);
		row = nextRow;
		col = nextCol;
		cell[row][col].addPath(sDir);
		cell[row][col].setCurrent(true);
		if(row==endRow && col==endCol) {
			String message = "You won!";
			JOptionPane.showMessageDialog(this, message);
		}
	}
	
	private void newMaze(){
		
		mazePanel.removeAll();
		mazePanel.setLayout(new GridLayout(rows, cols));
		cell = new Cell[rows][cols];
		
		
		
		for(int r = 0; r < rows; r++) {
			for(int c = 0; c < cols; c++) {
				cell[r][c] = new Cell(r,c);				
				mazePanel.add(cell[r][c]);
			}
		}
		
		generateMaze();
		
		row = 0;
		col = 0;
		endRow = rows-1;
		endCol = cols-1;
		cell[row][col].setCurrent(true);
		cell[endRow][endCol].setEnd(true);
		
		mazePanel.revalidate();
		
	} // END newMaze
	
	private void generateMaze() {
		// USE COMMENTS TO ROUGH OUT CODE LOGIC, THEN FILL IN WITH CODE
		
		ArrayList<Cell> tryLaterCells = new ArrayList<>();
		int totalCells = rows * cols;
		int visitedCells =  1;
		// start at random cell
		Random rand = new Random();
		int r = rand.nextInt(rows);
		int c = rand.nextInt(cols);
		
		// while theres cells that havent been visited
		while(visitedCells<totalCells) {
		
			// find all neighbors with walls intact
			ArrayList<Cell> neighbors = new ArrayList<Cell>();
			if(isAvailable(r-1, c)) neighbors.add(cell[r-1][c]);
			if(isAvailable(r+1, c)) neighbors.add(cell[r+1][c]);
			if(isAvailable(r, c-1)) neighbors.add(cell[r][c-1]);
			if(isAvailable(r, c+1)) neighbors.add(cell[r][c+1]);
			// if one or more found
			if(neighbors.size() > 0) {
				// more than one: add to try later list
				if(neighbors.size() > 1) {
					tryLaterCells.add(cell[r][c]); // only do one neighbor per pass
				}				
				// pick a neighbor, remove walls between
				Cell neighbor = neighbors.get(rand.nextInt(neighbors.size()));
				cell[r][c].openTo(neighbor);
				
				// goto neighbor and increment number visited
				r = neighbor.getRow();
				c = neighbor.getCol();
				visitedCells++;
				
				
			
			} else {
			// if none found, try one from the later list
				Cell nextCell = tryLaterCells.remove(0);
				r = nextCell.getRow();
				c = nextCell.getCol();
				
				
			}
		} // end while
		
	} // end generateMaze
	
	private boolean isAvailable(int r, int c) {
		// prevent index errors
		if(r < 0 || c < 0 || r >= rows || c >= cols) return false;
		
		if(!cell[r][c].hasAllWalls()) return false;
		
		return true;
		
	}
	

}
