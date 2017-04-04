package speedwords;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;

import javax.swing.BoxLayout;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.UIManager;

import jacob.scherber.mycomponents.*;

public class SpeedWords extends JFrame {
	private static final long serialVersionUID = 1L;
	
	public static final Color TAN = new Color(222, 191, 168);
	private ScorePanel scorePanel = new ScorePanel(0 , TAN);
	
	public SpeedWords() {
		initGUI();
		setTitle("Speed Words");
		setResizable(false);
		pack();
		setLocationRelativeTo(null);
		setVisible(true);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
	}
	
	
	private void initGUI() {
		TitleLabel titleLabel = new TitleLabel("Speed Words");
		add(titleLabel, BorderLayout.PAGE_START);
		
		// main panel
		JPanel mainPanel = new JPanel();
		mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.X_AXIS));
		mainPanel.setBackground(TAN);
		add(mainPanel, BorderLayout.CENTER);
		// left panel
		JPanel leftPanel = new JPanel();
		leftPanel.setLayout(new BoxLayout(leftPanel, BoxLayout.Y_AXIS));
		leftPanel.setBackground(TAN);
		mainPanel.add(leftPanel);
		// score panel
		leftPanel.add(scorePanel);
		// timer panel
		
		// game panel
		
		// text area
		
	}


	public static void main(String[] args) {
		String className = UIManager.getCrossPlatformLookAndFeelClassName();
		try {
			UIManager.setLookAndFeel(className);
		} catch (Exception e) {	} 
		
		EventQueue.invokeLater(new Runnable() {
			
			@Override
			public void run() {
				new SpeedWords();
				
			}
		});

	}

}
