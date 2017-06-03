package speedwords;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.Insets;
import java.util.ArrayList;

import javax.swing.*;

import jacob.scherber.mycomponents.*;

public class SpeedWords extends JFrame {
	private static final long serialVersionUID = 1L;
	
	public static final Color TAN = new Color(222, 191, 168);
	private static final Font LIST_FONT = new Font(Font.DIALOG,Font.BOLD, 14);
	private int timeLength = 20;

	
	private ScorePanel scorePanel = new ScorePanel(0 , TAN);	
	private SpeedWordsTimerPanel swTimerPanel = new SpeedWordsTimerPanel(this, timeLength);
	private JTextArea textArea = new JTextArea();
	private GamePanel gamePanel = new GamePanel(this);
	
	public SpeedWords() {
		initGUI();
		setTitle("Speed Words");
		setResizable(false);
		pack();
		setLocationRelativeTo(null);
		setVisible(true);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		swTimerPanel.start();
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
		JPanel timerPanel = new JPanel();
		timerPanel.setBackground(Color.RED);
		leftPanel.add(timerPanel);
		swTimerPanel.setBackground(Color.RED);
		timerPanel.add(swTimerPanel);
		// game panel
		leftPanel.add(gamePanel);
		// text area
		Insets insets = new Insets(4, 10, 10, 4);
		textArea.setMargin(insets);
		textArea.setEditable(false);
		textArea.setFont(LIST_FONT);
		Dimension size = new Dimension(100, 0);
		JScrollPane scrollPane = new JScrollPane(textArea);
		scrollPane.setPreferredSize(size);
		mainPanel.add(scrollPane);
	}

	public void setWordList(ArrayList<String> wordList) {
	    String s = "";
	    for(int i = 0; i < wordList.size(); i++) {
	        String word = wordList.get(i);
	        s += word + "\n";
        }
        textArea.setText(s);
    }

	public void addToScore(int newPoints) {
	    //scorePanel from myComponents package
	    scorePanel.addToScore(newPoints);
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

    public void outOfTime() {
	    gamePanel.setOutOfTime(true);

        String message = "Do you want to play again?";
        int option = JOptionPane.showConfirmDialog(this, message,
                "Play again?", JOptionPane.YES_NO_CANCEL_OPTION);
        if (option == JOptionPane.YES_OPTION) {
            textArea.setText("");
            scorePanel.reset();
            gamePanel.restart();
            swTimerPanel.setTime(timeLength);
            swTimerPanel.run();
        } else {
            System.exit(0);
        }
    }
}
