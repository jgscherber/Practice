package wordbuilder;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;
import java.awt.GridLayout;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.UIManager;


import jacob.scherber.mycomponents.TitleLabel;

public class WordBuilder extends JFrame {
	private static final long serialVersionUID = 1L; // required

	private static final int 
			ROWS = 8,
			COLS = 12,
			MAX = 15;
	
	private LetterPanel[][] board = new LetterPanel[ROWS][COLS];
	
	private JPanel 
			mainPanel = new JPanel(),
			boardPanel = new JPanel();
	
	public WordBuilder() {
		initGUI();
		
	}
	
	private void initGUI() {
		// setup
		TitleLabel title = new TitleLabel("Word Builder");
		add(title, BorderLayout.PAGE_START);
		setLocationRelativeTo(null);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setVisible(true);
		
		// main panel
		
		add(mainPanel,BorderLayout.CENTER);
		
		// score panel
		
		// play panel
		
		// board panel
		boardPanel.setBackground(Color.BLACK);
		boardPanel.setLayout(new GridLayout(ROWS, COLS));
		mainPanel.add(boardPanel);
		
		BagOfLetters letters = new BagOfLetters();
		for(int row=0; row<ROWS; row++) {
			for(int col=0; col<COLS; col++) {
				board[row][col] = letters.pickALetter();
				boardPanel.add(board[row][col]);
			}
		}
		
		
		// button panel
		
		// listeners
		
		pack();
	}
	
	public static void main(String[] args) {
		
		String classname = UIManager.getCrossPlatformLookAndFeelClassName();
		try {
			UIManager.setLookAndFeel(classname);
		} catch (Exception e) {	}
		
		EventQueue.invokeLater(new Runnable() {
			
			@Override
			public void run() {
				new WordBuilder();
				
			}
		});

	}

}
