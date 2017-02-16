package jacob.scherber.watchyourstep;

import java.awt.BorderLayout;
import java.awt.EventQueue;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Random;

import javax.swing.JDialog;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.UIManager;

import jacob.scherber.mycomponents.TitleLabel;

public class WatchYourStep extends JFrame {
	
	private static final long serialVersionUID = 1L;
	private static final int GRIDSIZE = 10;
	private final int NUMBEROFHOLES = 10; // "instance" = non static
	private int totalRevealed = 0;
	
	private TerrainButton[][] terrain = new TerrainButton[GRIDSIZE][GRIDSIZE];
	public WatchYourStep() {
		initGUI();
		setHoles();
		
		setResizable(false);
		setLocationRelativeTo(null);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		pack();
		setVisible(true);
		
		
		
	}
	
	public void initGUI() {
		
		TitleLabel titleLabel = new TitleLabel("Watch Your Step");
		add(titleLabel, BorderLayout.PAGE_START);
		
		JPanel centerPanel = new JPanel(new GridLayout(GRIDSIZE,GRIDSIZE));
		add(centerPanel, BorderLayout.CENTER);	
		
		for(int row = 0; row<GRIDSIZE; row++) {
			for(int col = 0; col < GRIDSIZE; col++) {
				terrain[row][col] = new TerrainButton(row, col);
				centerPanel.add(terrain[row][col]);
				
				terrain[row][col].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						TerrainButton button = (TerrainButton)e.getSource();
						int row = button.getRow();
						int col = button.getCol();
						clickedTerrain(row,col);
						
					}
				}); // end addActionListener()
			}			
		}
		
	}// end initGUI
	
	private void clickedTerrain(int row,int col) {
		TerrainButton button = terrain[row][col];
		if(button.hasHole()) {
			promptForNewGame();
		}
		else{
			check(row, col);
			checkNeighbors(row, col);
		}
		
		
	}
	
	private void promptForNewGame() {
		String message = "Oops! You stepped in a hole! Play again?";
		int done = JOptionPane.showConfirmDialog(this, message,"You lose!", JOptionPane.YES_NO_OPTION);
		if(done == JOptionPane.YES_OPTION) newGame(); 
		else System.exit(0);
	}
	
	private void newGame() {
		for(TerrainButton[] top : terrain) {
			for (TerrainButton button : top) {
				button.reset();
				
			}
		}
		setHoles();
	}
	
	
	private boolean validSpace(int row, int col) {
		return(row > -1 && col > -1 && row < GRIDSIZE && col < GRIDSIZE);
	}
	
	private void checkNeighbors(int row, int col) {
		for(int i = -1; i<2; i++){
			for (int j = -1; j<2; j++) {
				check(row+i, col+j);
			}				
		}
	}
	
	private void check(int row, int col) {
		if(!validSpace(row, col)) return;
		TerrainButton button = terrain[row][col];
		if(button.isRevealed()) return; // needed to stop stackOverflow
		if(!button.hasHole()) button.reveal(true);
		if(!button.isNextToHoles()) checkNeighbors(row, col);
		
	}
	
	private void setHoles() {
		
		Random rand = new Random();
		int holesCreated = 0;
		while(holesCreated<NUMBEROFHOLES) {
			int row = rand.nextInt(GRIDSIZE);
			int col = rand.nextInt(GRIDSIZE);
			if (terrain[row][col].hasHole()) continue;
			else {
				terrain[row][col].setHole(true);
				holesCreated++;
				addToNeighborsHoleCount(row,col);
				//terrain[row][col].reveal(true);
			}
			
			
		}
		
	}
	
	private void addToNeighborsHoleCount(int row, int col) {
		
		for(int i = -1; i<2; i++){
			for (int j = -1; j<2; j++) {
				if(validSpace(row+i, col+j)) terrain[row+i][col+j].increaseHoleCount();
			}				
		}		
		
	}
	
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			
			@Override
			public void run() {
				new WatchYourStep();
				
			}
		});
		
		try{
			String classname = UIManager.getCrossPlatformLookAndFeelClassName();
			UIManager.setLookAndFeel(classname);
		}
		catch (Exception e) {}
				
		
	}

}
