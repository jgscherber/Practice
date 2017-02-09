package jacob.scherber.framed;

import java.awt.BorderLayout;
import java.awt.EventQueue;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Random;

import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.UIManager;

import jacob.scherber.mycomponents.TitleLabel;


public class Framed extends JFrame {

	private static final long serialVersionUID = 1L;
	private static final int GRIDSIZE = 3;
	private static LightButton[][] lightButtons = new LightButton[GRIDSIZE][GRIDSIZE];
	
	
	public Framed() {
		
		initGUI();
		
		setTitle("Framed");
		setResizable(false);
		setLocationRelativeTo(null);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		pack();
		setVisible(true);
		
		newGame();
		
	}
	
	private void initGUI() {
		TitleLabel titleLabel = new TitleLabel("Framed");
		add(titleLabel, BorderLayout.PAGE_START);
		
		JPanel centerPanel = new JPanel();
		centerPanel.setLayout(new GridLayout(GRIDSIZE, GRIDSIZE));
		add(centerPanel,BorderLayout.CENTER);
		
		for(int row = 0; row<GRIDSIZE;row++){
			for (int col = 0; col<GRIDSIZE;col++){
				lightButtons[row][col] = new LightButton(row, col);
				lightButtons[row][col].turnOn();
				lightButtons[row][col].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						LightButton button = (LightButton)e.getSource();
						int row = button.getRow();
						int col = button.getCol();
						toggleLights(row,col);
						endGameIfDone();
						
					}
				});
				centerPanel.add(lightButtons[row][col]);// added column by column			
				
			}
		}
	}// end initGUI
	
	private void endGameIfDone(){ // non static?? called within class??
		
		boolean done = lightButtons[0][0].isLit()
				&& lightButtons[1][0].isLit()
				&& lightButtons[2][0].isLit()
				&& lightButtons[0][1].isLit()
				&& !lightButtons[1][1].isLit()
				&& lightButtons[2][1].isLit()
				&& lightButtons[0][2].isLit()
				&& lightButtons[1][2].isLit()
				&& lightButtons[2][2].isLit();
		
		if(done) {
			String message = "Play again?";
			int option = JOptionPane.showConfirmDialog(this, message,"You win!",
					JOptionPane.YES_NO_OPTION);
			if(option==JOptionPane.YES_OPTION){
				newGame();
			}
			else {
				System.exit(0);
			}
		}
		
	}
	
	private static void newGame() {
		
		lightButtons[1][1].toggle();
		
		Random random = new Random();
		int numberOfTimes = random.nextInt(11) + 10; // next int exclusive
		for(int i=0;i<numberOfTimes;i++) {
			lightButtons[random.nextInt(GRIDSIZE)][random.nextInt(GRIDSIZE)].toggle();
		}
	}
	
	private static void toggleLights(int row, int col) {
		
		lightButtons[row][col].toggle();
		
		
		// should use GRIDSIZE to determine corners
		// top left corner
	    if(row==0 && col==0) {
	      lightButtons[0][1].toggle();
	      lightButtons[1][0].toggle();
	      lightButtons[1][1].toggle();
	    }
	    // top right corner
	    else if(row==0 && col==2) {
		      lightButtons[0][1].toggle();
		      lightButtons[1][2].toggle();
		      lightButtons[1][1].toggle();
		    }
	    // bottom left corner
	    else if(row==2 && col==0) {
		      lightButtons[2][1].toggle();
		      lightButtons[1][0].toggle();
		      lightButtons[1][1].toggle();
		    }
	    // bottom right corner
	    else if(row==2 && col==2) {
		      lightButtons[1][2].toggle();
		      lightButtons[2][1].toggle();
		      lightButtons[1][1].toggle();
		    }
	    
	    // top middle
	    else if(row==0 && col==1) {
		      lightButtons[0][0].toggle();
		      lightButtons[0][2].toggle();
		      
		    }
	    // bottom middle
	    else if(row==2 && col==1) {
		      lightButtons[2][2].toggle();
		      lightButtons[2][0].toggle();
		      
		    }
	    // left middle
	    else if(row==1 && col==0) {
		      lightButtons[0][0].toggle();
		      lightButtons[2][0].toggle();
		      
		    }
	    // right middle
	    else if(row==1 && col==2) {
		      lightButtons[0][2].toggle();
		      lightButtons[2][2].toggle();
		      
		    }	
	    // middle button
	    else if(row==1 && col==1) {
		      lightButtons[1][0].toggle();
		      lightButtons[1][2].toggle();
		      lightButtons[0][1].toggle();
		      lightButtons[2][1].toggle();
	    }
	    
	}
	
	public static void main(String[] args) {
		try {
			String className = UIManager.getCrossPlatformLookAndFeelClassName();
			UIManager.setLookAndFeel(className);
		}
		catch(Exception e){}
		
		EventQueue.invokeLater(new Runnable() {
			
			@Override
			public void run() {
				new Framed();
				
			}
		});

	}

}
