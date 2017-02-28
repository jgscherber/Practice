package jacob.scherber.watchyourstep;

import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.util.Random;

import javax.swing.JFrame;
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
	
	private void initGUI() {
		
		TitleLabel titleLabel = new TitleLabel("Watch Your Step");
		add(titleLabel, BorderLayout.PAGE_START);
		
		JPanel centerPanel = new JPanel(new GridLayout(GRIDSIZE,GRIDSIZE));
		add(centerPanel, BorderLayout.CENTER);	
		
		for(int row = 0; row<GRIDSIZE; row++) {
			for(int col = 0; col < GRIDSIZE; col++) {
				terrain[row][col] = new TerrainButton(row, col);
				centerPanel.add(terrain[row][col]);				
			}			
		}
		
	}// end initGUI
	
	private void setHoles(){
		Random rand = new Random();
		for( int i = 0; i<NUMBEROFHOLES;i++) {
			int pickRow = rand.nextInt(GRIDSIZE);
			int pickCol = rand.nextInt(GRIDSIZE);
			while(terrain[pickRow][pickCol].hasHole()) {
				pickRow = rand.nextInt(GRIDSIZE);
				pickCol = rand.nextInt(GRIDSIZE);
			}
			terrain[pickRow][pickCol].setHole(true);
			addToNeighborsHoleCount(pickRow, pickCol);
			//terrain[pickRow][pickCol].reveal(true);
			
		} // next i
	} // end setHoles
	
	private void addToNeighborsHoleCount(int pickRow, int pickCol) {
		
	} // end addToNeighborsHoleCount
	
	public static void main(String[] args) {
//		EventQueue.invokeLater(new Runnable() {
//			
//			@Override
//			public void run() {
//				new WatchYourStep();
//				
//			}
//		});
		new WatchYourStep();
		try{
			String classname = UIManager.getCrossPlatformLookAndFeelClassName();
			UIManager.setLookAndFeel(classname);
		}
		catch (Exception e) {}
				
		
	}

}
