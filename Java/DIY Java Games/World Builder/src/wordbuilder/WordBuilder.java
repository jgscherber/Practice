package wordbuilder;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Component;
import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.Box;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.UIManager;


import jacob.scherber.mycomponents.TitleLabel;

public class WordBuilder extends JFrame {
	private static final long serialVersionUID = 1L; // required

	// static variables
	private static final int 
			ROWS = 8,
			COLS = 12,
			MAX = 15;
	
	private static final String FILENAME = "highScores.txt";
		
	private static final Color TAN = new Color(222, 191, 168);
	
	private static final Font 
			SMALLFONT = new Font(Font.DIALOG,Font.PLAIN, 12),
			BIGFONT = new Font(Font.DIALOG, Font.BOLD, 18);
	
	// instance variables
	private String word = "";	
	
	private Dictionary dictionary = new Dictionary();
	
	private int 
			points = 0,
			score = 0;

	private LetterPanel[][] board = new LetterPanel[ROWS][COLS];
	private LetterPanel[] played = new LetterPanel[MAX];
	
	private JPanel
			mainPanel = new JPanel(),
			boardPanel = new JPanel(),
			scorePanel = new JPanel(),
			playPanel = new JPanel();
	
	private JLabel 
			pointsTitleLabel = new JLabel("Points: "),
			scoreTitleLabel = new JLabel("Score: "),
			pointsLabel = new JLabel("0"),
			scoreLabel = new JLabel("0");
	
	private JButton 
			acceptButton = new JButton("Accept"),
			undoButton = new JButton("Undo"),
			clearBuuton = new JButton("Clear"),
			endButton = new JButton("End Game");
	
	
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
		mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
		mainPanel.setBackground(TAN);
		
		// score panel
		scorePanel.setLayout(new BoxLayout(scorePanel, BoxLayout.X_AXIS));
		scorePanel.setBackground(TAN);
		mainPanel.add(scorePanel);
		
		pointsTitleLabel.setFont(SMALLFONT);
		scorePanel.add(pointsTitleLabel);
		pointsLabel.setFont(BIGFONT);
		scorePanel.add(pointsLabel);
		
		// insert a spacer component into the box layout
		Component box = Box.createRigidArea(new Dimension(20,0));
		scorePanel.add(box);
		
		scoreTitleLabel.setFont(SMALLFONT);
		scorePanel.add(scoreTitleLabel);
		scoreLabel.setFont(BIGFONT);
		scorePanel.add(scoreLabel);
		
		// play panel
		playPanel.setLayout(new GridLayout(1,MAX));
		playPanel.setBackground(TAN);
		mainPanel.add(playPanel);
		for(int i=0; i<MAX; i++) {
			played[i] = new LetterPanel();
			playPanel.add(played[i]);
		}
		
		// board panel
		boardPanel.setBackground(Color.BLACK);
		boardPanel.setLayout(new GridLayout(ROWS, COLS));
		int panelSize = played[0].getPanelSize();
		
		// keep the boardPanel from being stretched to the play panels size
		boardPanel.setMaximumSize(new Dimension((panelSize*COLS),(panelSize*ROWS)));
		mainPanel.add(boardPanel);
		
		BagOfLetters letters = new BagOfLetters();
		for(int row=0; row<ROWS; row++) {
			for(int col=0; col<COLS; col++) {
				board[row][col] = letters.pickALetter();
				board[row][col].setColumn(col);
				boardPanel.add(board[row][col]);
			}
		}
		
		// first row of letters needs to be actionable
		for(int col = 0; col < COLS; col++) {
			board[0][col].addMouseListener(new MouseAdapter() {
				
				@Override
				public void mouseReleased(MouseEvent e) {
					LetterPanel letterPanel = (LetterPanel)e.getComponent();
					click(letterPanel);
				}
				
			});;
		}
		
		
		// button panel
		JPanel buttonPanel = new JPanel();
		buttonPanel.setBackground(Color.BLACK);
		mainPanel.add(buttonPanel,BorderLayout.PAGE_END);
		
		acceptButton.setEnabled(false);
		undoButton.setEnabled(false);
		clearBuuton.setEnabled(false);
		
		buttonPanel.add(acceptButton);
		buttonPanel.add(undoButton);
		buttonPanel.add(clearBuuton);
		buttonPanel.add(endButton);
		
		// listeners
		
		pack();
	}
	
	private void click(LetterPanel letterPanel) {
		int wordLength = word.length();
		if(letterPanel.getLetter() != "" )
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
