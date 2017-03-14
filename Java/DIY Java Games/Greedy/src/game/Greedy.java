package game;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.UIManager;

import jacob.scherber.mycomponents.TitleLabel;

public class Greedy extends JFrame {

	
	private static final long serialVersionUID = 1L;

	Greedy() {
		setResizable(false);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setLocationRelativeTo(null);
		initGUI();
		pack();
		setVisible(true);
	}
	
	private void initGUI() {
		TitleLabel titleLabel = new TitleLabel("Greedy");
		add(titleLabel);
		
		// main panel
		JPanel mainPanel = new JPanel();
		add(mainPanel,BorderLayout.CENTER);
		Die die = new Die();
		
		mainPanel.add(die);
		
		
		// score panel
		
		// dice row panel
		
		// points panel
		
		// dice panel
		
		// button panel
		
	}
	
	public static void main(String[] args) {
		try {
			String className = UIManager.getCrossPlatformLookAndFeelClassName();
			UIManager.setLookAndFeel(className);			
			
		} catch(Exception e) {}
		
		EventQueue.invokeLater(new Runnable() {
			
			@Override
			public void run() {
				new Greedy();
				
			}
		});

	}

}
