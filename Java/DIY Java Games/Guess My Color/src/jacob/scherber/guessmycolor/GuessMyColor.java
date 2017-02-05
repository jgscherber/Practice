package jacob.scherber.guessmycolor;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Random;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.UIManager;

import jacob.scherber.mycomponents.TitleLabel;


public class GuessMyColor extends JFrame {

	private static final long serialVersionUID = 1L; // needed for JFrame subclasses
	
	private JPanel samplePanel = new JPanel();
	private JPanel targetPanel = new JPanel();
	private int targetRed;
	private int targetBlue;
	private int targetGreen;
	int red;
	int green;
	int blue;
	
	
	
	public GuessMyColor() {
		
		initGUI();
				
		
		setTitle("Guess My Color");
		//setResizable(false);
		pack();
		setLocationRelativeTo(null);
		setVisible(true);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		generateTargetColor();
	}
	
	private void generateTargetColor() {
		
		Random rand = new Random();
		targetBlue = rand.nextInt(18)*15; // make 18 evenly spaced options
		targetGreen = rand.nextInt(18)*15;
		targetRed = rand.nextInt(18)*15;
		Color targetColor = new Color(targetRed,targetGreen,targetBlue); //RGB
		targetPanel.setBackground(targetColor);
		
	}
	
	private void initGUI() { // not static, called only when an object is created
		
//		JLabel titleLabel = new JLabel();
//		Font titleFont = new Font(Font.SERIF, Font.BOLD, 32);
//		titleLabel.setFont(titleFont);
//		titleLabel.setHorizontalAlignment(JLabel.CENTER);
//		titleLabel.setText("Guess My Color");
//		titleLabel.setOpaque(true); // needed for background to show black (JLabel's transparent by default)
//		titleLabel.setBackground(Color.BLACK);
//		titleLabel.setForeground(Color.WHITE);
//		// w/o specifying the location with the 2nd parameter, labels will overlap
//		// each other at the CENTER location (only see the last one added)
//		
//		// PAGE_START: Top
//		// PAGE_END: Bottom
//		// LINE_START: relate to orientation (left-to-right vs. right-to-left)
//		// LINE_END: right

		TitleLabel titleLabel = new TitleLabel("Guess My Color");
		
		add(titleLabel,BorderLayout.PAGE_START); 
		
		JPanel centerPanel = new JPanel();
		centerPanel.setBackground(Color.WHITE);
		add(centerPanel, BorderLayout.CENTER);
		
		samplePanel.setPreferredSize(new Dimension(50, 50)); // calling setSize will reset it on pack
		samplePanel.setBackground(new Color(targetRed,targetGreen,targetBlue));
		centerPanel.add(samplePanel);
		
		targetPanel.setPreferredSize(new Dimension(50, 50));
		targetPanel.setBackground(Color.CYAN);
		centerPanel.add(targetPanel);
		
//		JPanel leftPanel = new JPanel();
//		leftPanel.setBackground(Color.RED);
//		add(leftPanel, BorderLayout.LINE_START);
//		
//		JPanel rightPanel = new JPanel();
//		rightPanel.setBackground(Color.GREEN);
//		add(rightPanel, BorderLayout.LINE_END);
		
		JPanel buttonPanel = new JPanel();
		buttonPanel.setBackground(Color.BLACK);
		add(buttonPanel, BorderLayout.PAGE_END);
	
		Font font = new Font(Font.DIALOG, Font.BOLD, 18);
		JButton moreRedButton = new JButton("+");
		moreRedButton.setBackground(Color.RED);
		moreRedButton.setFont(font);
		buttonPanel.add(moreRedButton);
		
		JButton lessRedButton = new JButton("-");
		lessRedButton.setBackground(Color.RED);
		lessRedButton.setFont(font);
		buttonPanel.add(lessRedButton);
		
		JButton moreGreenButton = new JButton("+");
		moreGreenButton.setBackground(Color.GREEN);
		moreGreenButton.setFont(font);
		buttonPanel.add(moreGreenButton);
		
		JButton lessGreenButton = new JButton("-");
		lessGreenButton.setBackground(Color.GREEN);
		lessGreenButton.setFont(font);
		buttonPanel.add(lessGreenButton);
		
		JButton moreBlueButton = new JButton("+");
		moreBlueButton.setBackground(Color.BLUE);
		moreBlueButton.setForeground(Color.WHITE);
		moreBlueButton.setFont(font);
		buttonPanel.add(moreBlueButton);
		
		JButton lessBlueButton = new JButton("-");
		lessBlueButton.setBackground(Color.BLUE);
		lessBlueButton.setForeground(Color.WHITE);
		lessBlueButton.setFont(font);
		buttonPanel.add(lessBlueButton);
		
		
		moreRedButton.addActionListener(new ActionListener() { // defined in place
			
			@Override
			public void actionPerformed(ActionEvent e) {
				increaseRed();
				
			}
		});
		
		lessRedButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				decreaseRed();
				
			}
		});
		
		moreBlueButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				increaseBlue();
				
			}
		});
		
		lessBlueButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				decreaseBlue();
				
			}
		});
		
		moreGreenButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				increaseGreen();
				
			}
		});
		
		lessGreenButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				decreaseGreen();
				
			}
		});
		
	}// end initGUI
	private void updateColorSample() { // encapsulate resetting the color (could do in each increase/decrease method)
		Color guessColor = new Color(red, green, blue);
		Color testColor = new Color(targetRed, targetGreen,targetBlue);
		samplePanel.setBackground(guessColor);
		if(guessColor.equals(testColor))
		{
			String message = "You got it!";
			JOptionPane.showMessageDialog(this, message);
		}
	}
	private void increaseRed() {
		if(red<255)
			red += (15);
		updateColorSample();
	}
	
	private void decreaseRed() {
		if(red>0)
			red -= (15);
		updateColorSample();
		
	}
	
	private void increaseBlue() {
		if(blue<255)
			blue += (15);
		updateColorSample();
	}
	
	private void decreaseBlue() {
		if(blue>0)
			blue -= (15);
		updateColorSample();
	}
	
	private void increaseGreen() {
		if(green<255)
			green += (15);
		updateColorSample();
	}
	
	private void decreaseGreen() {
		if(green>0)
			green -= (15);
		updateColorSample();
	}
	
	public static void main(String[] args) {
		try{
			String className = UIManager.getCrossPlatformLookAndFeelClassName();
			UIManager.setLookAndFeel(className);
		}
		catch(Exception e){}	
		
		
		EventQueue.invokeLater(new Runnable() {
			
			@Override
			public void run() {
				new GuessMyColor();
				
			}
		});

	}

}
