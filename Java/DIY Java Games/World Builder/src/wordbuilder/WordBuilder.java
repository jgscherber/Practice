package wordbuilder;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Component;
import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.awt.event.ComponentListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.WindowEvent;
import java.awt.event.WindowStateListener;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

import javax.swing.Box;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
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
			clearButton = new JButton("Clear"),
			endButton = new JButton("End Game");
	
	
	public WordBuilder() {
		initGUI();
		
	}
	
	private void initGUI() {
		// setup
		TitleLabel title = new TitleLabel("Word Builder");
		add(title, BorderLayout.PAGE_START);
		setTitle("Word Builder");
		setLocationRelativeTo(null);
//		setResizable(false);
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
					LetterPanel letterPanel = (LetterPanel)e.getSource();
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
		clearButton.setEnabled(false);
		
		buttonPanel.add(acceptButton);
		buttonPanel.add(undoButton);
		buttonPanel.add(clearButton);
		buttonPanel.add(endButton);
		
		// listeners
		acceptButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				accept();
				
			}
		});	
		
		undoButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				undo();
				
			}
		});
		
		clearButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				clear();
				
			}
		});
		
		endButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				endGame();
				
			}
		});
		
		// need to listen to the window for resizing
		addComponentListener(new ComponentAdapter() {
			
			@Override
			public void componentResized(ComponentEvent e) {
				resizeWindow();
			}
			
		});
		
		addWindowStateListener(new WindowStateListener() {
			
			@Override
			public void windowStateChanged(WindowEvent e) {
				resizeWindow();
				
			}
		});
		
		
		pack();
		
	} // end initGUI()
	
	private void resizeWindow() {
		int newWidth = mainPanel.getWidth(); // JPanel method
		int newHeight = mainPanel.getHeight();
		
		int panelSize = newWidth / 15; // main panel needs to hold 15 letters
		if(panelSize > (newHeight/10)) { // main panel needs to be 10 letters high
			panelSize = newHeight/10;
		}
		
		Dimension boardSize = new Dimension(COLS * panelSize, ROWS * panelSize);
		boardPanel.setMaximumSize(boardSize);
		
		for(int row=0; row<ROWS; row++) {
			for(int col=0; col<COLS; col++) {
				board[row][col].resize(panelSize);				
			}
		}
		
		Dimension playSize = new Dimension(MAX * panelSize, panelSize);
		playPanel.setMaximumSize(playSize);
		
		for(LetterPanel p : played) {
			p.resize(panelSize);
		}
		
		
	}
	
	public void endGame() {
		ArrayList<String> records = new ArrayList<>();
		int index = 0;
		try {
			BufferedReader in = new BufferedReader(new FileReader(new File(FILENAME))); // throws FileNotFound
			String s = in.readLine(); // throws IOException
			
			while(s != null) {
				records.add(s);
				int indexOfSpace = s.indexOf(" ");
				String scoreString = s.substring(0, indexOfSpace);
				int oldScore = Integer.parseInt(scoreString);
				// find where in the highscore list to put the new score
				if(oldScore > score) {
					index++;
				}				
				s = in.readLine();
			}		
			
			in.close();
		} catch (FileNotFoundException e) {
			String message = "File not found. A new highscore list will be created.";
			JOptionPane.showMessageDialog(this, message);
		} catch (IOException e) {
			String message = "Could not read file. A new highscore list will be created.";
			JOptionPane.showMessageDialog(this, message);
		} catch(NumberFormatException e) {
			String message = "Could convert number. A new hightscore list will be created.";
			JOptionPane.showMessageDialog(this, message);
		}
		
		
		// add score if it's within the top 10
		if(index < 10) {
			DateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy");
			Date date = new Date();
			String newRecord = score + " " + dateFormat.format(date);
			records.add(index, newRecord);
			if(records.size() > 10) { records.remove(10); }
			
		}
		
		String message = "TOP 10 HIGH SCORE\n";
		for(String s : records) {
			message += (s + "\n");
		}
		
		saveRecords(records);
		
		message += "\nDo you want to play again?";
		int option = JOptionPane.showConfirmDialog(this, message, "Play again?", JOptionPane.YES_NO_OPTION);
		if(option == JOptionPane.YES_OPTION) {
			newGame();
		} else {
			System.exit(0);
		}
		
		
	} // end endGame()
	
	private void newGame() {
		clear();
		score = 0;
		points = 0;
		word = "";
		scoreLabel.setText("" + score);
		updateButtonsAndPoints();
		BagOfLetters letters = new BagOfLetters();
		for(int row=0; row<ROWS; row++) {
			for(int col=0; col<COLS; col++) {
				board[row][col].copy(letters.pickALetter());
				board[row][col].setColumn(col);				
			}
		}
		
	}
	
	private void saveRecords(ArrayList<String> records) {
		try {
			BufferedWriter out = new BufferedWriter(new FileWriter(new File(FILENAME)));
			for(String s : records) {
				out.write(s);
				out.newLine();
			}
			
			out.close();
		} catch (IOException e) {
			String message = "Could not save hightscores.";
			JOptionPane.showMessageDialog(this, message);			
		}
	}
	
	
	
	public void clear() {
		int times = word.length();
		for(int i = 0; i < times; i++) {
			undo();
		}
		// buttons and points updated in undo()
	}
	
	private void undo() {
		int last = word.length()-1;
		word = word.substring(0, last); // end is exclusive
		LetterPanel lastPlayedPanel = played[last];
		points -= lastPlayedPanel.getPoints();
		
		int col = lastPlayedPanel.getColumn();
		for(int row = ROWS-1; row > 0; row--) {
			board[row][col].copy(board[row-1][col]);
		}
		board[0][col].copy(lastPlayedPanel);
		
		lastPlayedPanel.setEmpty();
		updateButtonsAndPoints();
	}
	
	private void accept() {
		score += (word.length() * points);
		scoreLabel.setText("" + score);
		for(int i = 0; i < word.length(); i++) {
			played[i].setEmpty();
		}
		points = 0;
		word = "";
		updateButtonsAndPoints();
	}
	
	
	private void click(LetterPanel letterPanel) {
		int wordLength = word.length();
		if(!letterPanel.isEmpty() && wordLength < MAX) {
			// put the tile on the playing board
			played[wordLength].copy(letterPanel);
			word += letterPanel.getLetter();
			points += letterPanel.getPoints();
			
			// remove the tile from the board
			int col = letterPanel.getColumn();
			for(int row = 0; row < ROWS-1; row++) {
				board[row][col].copy(board[row+1][col]);
			}
			board[ROWS-1][col].setEmpty();
			
			updateButtonsAndPoints();
		}
	} // end click()
	
	private void updateButtonsAndPoints() {
		int wordLen = word.length();
		if(wordLen < 1) {
			acceptButton.setEnabled(false);
			undoButton.setEnabled(false);
			clearButton.setEnabled(false);
			pointsLabel.setText("0");
		} else if(wordLen < 3 && wordLen > 0) {
			acceptButton.setEnabled(false);
			undoButton.setEnabled(true);
			clearButton.setEnabled(true);
			pointsLabel.setText("0");
		} else {
			if(dictionary.isAWord(word)) {
				acceptButton.setEnabled(true);
			} else {
				acceptButton.setEnabled(false);
			}
			undoButton.setEnabled(true);
			clearButton.setEnabled(true);
			int newPoints = wordLen*points;
			pointsLabel.setText(""+newPoints);
		}
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
