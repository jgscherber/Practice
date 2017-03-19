package game;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.UIManager;

import jacob.scherber.mycomponents.TitleLabel;

public class Greedy extends JFrame {

	private static final long serialVersionUID = 1L;
	
	private int 
			points = 0,
			newPoints = 0,
			score = 0,
			round = 1,
			highScore = 0;
	
	private JLabel 
			pointsLabel = new JLabel("0"),
			scoreLabel = new JLabel("0"),
			roundLabel = new JLabel("1"),
			highScoreLabel = new JLabel("");
	
	private Font 
			smallFont = new Font("Dialog", Font.PLAIN, 12),
			bigFont = new Font("Dialog", Font.BOLD, 24);
	
	private JButton 
				rollButton = new JButton("Roll"),
				endRoundButton = new JButton("End Round");
	
	private Die[] dice = new Die[6];
	
	private static final String 
							HIGHSCORETEXT = "The previous high score was ",
							FILENAME = "GreedyHighScore.txt";

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
		add(titleLabel, BorderLayout.PAGE_START);
		
		// main panel
		JPanel mainPanel = new JPanel();
		add(mainPanel,BorderLayout.CENTER);
		
		mainPanel.setBackground(Color.GREEN);
		mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
		
		
		// score panel
		JPanel scorePanel = new JPanel();
		scorePanel.setBackground(Color.GREEN);
		mainPanel.add(scorePanel);
		
		JLabel roundTitleLabel = new JLabel("Round: ");
		roundLabel.setFont(bigFont);
		roundTitleLabel.setFont(smallFont);
		
		scorePanel.add(roundTitleLabel);		
		scorePanel.add(roundLabel);
		
		JLabel scoreTitleLabel = new JLabel("Score: ");
		scoreTitleLabel.setFont(smallFont);
		scoreLabel.setFont(bigFont);
		
		scorePanel.add(scoreTitleLabel);
		scorePanel.add(scoreLabel);
		
		
		// dice row panel
		JPanel diceRowPanel = new JPanel();
		diceRowPanel.setBackground(Color.GREEN);
		mainPanel.add(diceRowPanel);
		
						
		// points panel
		JPanel pointsPanel = new JPanel();
		pointsPanel.setBackground(Color.GREEN);
		pointsPanel.setLayout(new BoxLayout(pointsPanel,BoxLayout.Y_AXIS));
		pointsPanel.setPreferredSize(new Dimension(70,70));
		
		diceRowPanel.add(pointsPanel);
		
		JLabel pointsTitleLabel = new JLabel("Points");
		pointsTitleLabel.setAlignmentX(JLabel.CENTER_ALIGNMENT);
		pointsLabel.setAlignmentX(JLabel.CENTER_ALIGNMENT);
		
		pointsTitleLabel.setFont(smallFont);
		pointsLabel.setFont(bigFont);
		
		pointsPanel.add(pointsTitleLabel);
		pointsPanel.add(pointsLabel);
		
		
		// dice panel
		JPanel dicePanel = new JPanel();
		dicePanel.setBackground(Color.GREEN);
		
		diceRowPanel.add(dicePanel);
		
		for(int i = 0; i<dice.length;i++) {
			dice[i] = new Die();
			dice[i].addMouseListener(new MouseAdapter() {
				public void mouseReleased(MouseEvent e) {
					clickedDie();
				}
			});
			dicePanel.add(dice[i]);
		}
		
		
		// button panel
		JPanel buttonPanel = new JPanel();
		add(buttonPanel, BorderLayout.PAGE_END);
		
		buttonPanel.setBackground(Color.BLACK);
		buttonPanel.add(rollButton);
		rollButton.setEnabled(false);
		rollButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent arg0) {
				updatePoints();
				rollRemainingDice();
				rollButton.setEnabled(false);
				
			}
		});
		buttonPanel.add(endRoundButton);
		endRoundButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent arg0) {
				endRound();				
			}
		});
		
		// high score
		getPreviousHighScore();
		highScoreLabel.setText(HIGHSCORETEXT + highScore);
		highScoreLabel.setFont(smallFont);
		mainPanel.add(highScoreLabel);
		
	} // end initGUI()
	
	private void endRound() {
		if(isValidSelection()) {
			score += (points + newPoints);			
			scoreLabel.setText(""+score);			
		} 
		points = 0;
		newPoints = 0;
		pointsLabel.setText("0");
	
		if(round != 5) {
			round++;
			roundLabel.setText(""+round);
			rollAllDice();				
		} else {
			String message = "Do you want to play again?";
			
			if(score > highScore) {
				message = "Congratulations, you set a new high score! \n" + message;
				highScore = score;
				highScoreLabel.setText(HIGHSCORETEXT + highScore);
				saveScore();
			}				
			
			int option = JOptionPane.showConfirmDialog(this,message,"Play again?"
					,JOptionPane.YES_NO_OPTION);
			if(option == JOptionPane.YES_OPTION) {
				score = 0;
				round = 1;
				scoreLabel.setText("0");
				roundLabel.setText("1");
				rollAllDice();
			} else {System.exit(0);}

		}
	}
	
	private void updatePoints() {
		points += newPoints;
		pointsLabel.setText("" + points);
		newPoints = 0;

		
	}
	
	private void rollRemainingDice() {
		int count = 0;
		for(Die die : dice) {
			if(die.isSelected()) die.hold();
			if(!die.isHeld()) {
				die.roll();
				count++;
			}
		}
		if(count == 0) rollAllDice();	
	} // end rollRemainingDice()
	
	private void rollAllDice() {
		for(Die die : dice) {
			die.makeAvailable();
			die.roll();
		}
		rollButton.setEnabled(false);
	}
	
	private void clickedDie() {
		boolean valid = isValidSelection();
		if(valid) rollButton.setEnabled(true);
		else rollButton.setEnabled(false);
		
		pointsLabel.setText("" + (points + newPoints));
	}
	
	private boolean isValidSelection() {
		int[] count = { 0, 0, 0, 0, 0, 0 };
		int totalCount = 0;
		boolean valid = true;
		newPoints = 0;
		for(Die die : dice) {
			if(die.isSelected()) {
				int value = die.getValue();
				count[value-1]++;
				totalCount++;
			}
		}
		if(totalCount == 0) return false;
		// count location is one less than the die value
		if(count[0]==1 && count[1]==1 && count[2]==1
				&& count[3]==1 && count[4]==1 && count[5]==1) newPoints += 250;
		else {
			for(int i = 0; i < count.length; i++) {
				switch(count[i]) {
				case 1:
					if(i == 0) newPoints += 10;
					else if(i == 4) newPoints += 5;
					else return false;
					break;
				case 2:
					if(i == 0) newPoints += 20;
					else if(i == 4) newPoints += 10;
					else return false;
					break;
				case 3:
					if(i == 0) newPoints += 100;
					else newPoints+=((i+1)*10);
					break;
				case 4:
					newPoints += 200;
					break;
				case 5:
					newPoints += 300;
					break;
				case 6:
					newPoints += 500;				
			
				}
			}
		}		
		
		return true;
	}
	
	private void saveScore() {
		try{		
			BufferedWriter out = new BufferedWriter(new FileWriter(new File(FILENAME)));
			out.write(""+highScore);
			out.close();
		} catch(IOException e) {
			JOptionPane.showMessageDialog(this, "High score couldn't be saved.");
		}
	}
	
	private void getPreviousHighScore() {
		try {
			BufferedReader in = new BufferedReader(new FileReader(new File(FILENAME))); // holy nesting!
			String s = in.readLine();
			highScore = Integer.parseInt(s);
			in.close();
		} catch(FileNotFoundException e) {
			JOptionPane.showMessageDialog(this, "File not found.");
		} catch(IOException e) {
			JOptionPane.showMessageDialog(this, "File could not be opened.");
		} catch(NumberFormatException e) {
			JOptionPane.showMessageDialog(this, "File contains invalid data.");
		}
		
		
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
