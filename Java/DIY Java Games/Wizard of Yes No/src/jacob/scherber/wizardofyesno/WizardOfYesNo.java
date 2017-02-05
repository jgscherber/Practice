package jacob.scherber.wizardofyesno;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.Label;
import java.util.Random;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JScrollBar;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.UIManager;

import jacob.scherber.mycomponents.TitleLabel;

public class WizardOfYesNo extends JFrame { // use JFrame as the superclass for programs that start with a window
	
	
	private static final long serialVersionUID = 1L; // required for JFrame and many other components
	private static final String[] ANSWER = {"Yes","If you must","If it pleases","Go now!", "You must!", "Never!","No","Don't","You can't!"};
	
	public WizardOfYesNo() {
		
		String disclaimer = "This is only a suggestion. Use your own good judgment. The Wizard of Yes/ No is not responsible for the consequences of your decisions.";
		
		
		TitleLabel titleLabel = new TitleLabel("Wizard of Yes/No");
		add(titleLabel, BorderLayout.PAGE_START);
		
		//JLabel disclaimerLabel = new JLabel(disclaimer);
		JTextArea disclaimerTextArea = new JTextArea(disclaimer);
		disclaimerTextArea.setLineWrap(true);
		disclaimerTextArea.setWrapStyleWord(true); // default will split words
		disclaimerTextArea.setEditable(false);
		//add(disclaimerTextArea, BorderLayout.PAGE_END);
			
		JScrollPane scrollPane = new JScrollPane(disclaimerTextArea);
		scrollPane.setPreferredSize(new Dimension(300,60));
		add(scrollPane, BorderLayout.PAGE_END);
		
		// -- label creation --
		Random rand = new Random();
		int numberOfAnswers = ANSWER.length;
		int pick = rand.nextInt(numberOfAnswers);
			
		String answer = ANSWER[pick];
		//JLabel label = new JLabel("Yes"); // text set on instantiation
		JLabel label = new JLabel();
		label.setText(answer); // set text after instantiation
		label.setOpaque(true);
		if(pick<5) {
			label.setBackground(Color.GREEN);
			}
		else {
			label.setBackground(Color.RED);
		}
		add(label,BorderLayout.CENTER); // puts it in window w/o packing
		
		
		// -- changing fonts
		Font[] font = {new Font("Serif",Font.PLAIN, 18), new Font("Times New Roman",Font.BOLD, 30)
						, new Font("Arial",Font.ITALIC, 18),new Font("Helvetica",Font.BOLD + Font.ITALIC, 18)}; // BOLD AND ITALIC are int
//		Font[] defFont = {new Font(Font.DIALOG,Font.PLAIN, 18), new Font(Font.DIALOG_INPUT,Font.BOLD, 30)
//				, new Font(Font.SANS_SERIF,Font.ITALIC, 18),new Font(Font.MONOSPACED,Font.BOLD + Font.ITALIC, 18)}; // avoids computer not having the font needed
		
		label.setFont(font[0]); // doesn't need to be done before the add() method
		label.setHorizontalAlignment(JLabel.CENTER); // don't use setAlignmentX() for labels
		
		// -- window operations -- (should be at end of constructor to include pack)
		setLocationRelativeTo(null); // relative to null is center of the screen
		setTitle("Wizard of Yes or No!");
		pack(); // has to be called after all components have been added
		setVisible(true);
		setResizable(false);
		setDefaultCloseOperation(EXIT_ON_CLOSE); // w/o main continues to run, HIDE_ON_CLOSE is defaul operation
		//setSize(200, 100);
	}
	
	public static void main(String[] args) {
		try {
			String className = UIManager.getCrossPlatformLookAndFeelClassName(); // apply "Java theme" that matches current OS
			UIManager.setLookAndFeel(className);
			
//			String className = UIManager.getSystemLookAndFeelClassName(); // apply theme that matches current OS
//			UIManager.setLookAndFeel(className);
		}
		catch(Exception e)	{}
		// main doesn't run on the EventQueue; we need our JFrame to run on it to get events form it
		// so we add it using invokeLater and a Runnable object
		EventQueue.invokeLater(new Runnable() { // inplace class definition of Runnable
			
			@Override // attribute that subclasses need to override it
			public void run() {
				new WizardOfYesNo(); // instantiates JFrame object				
			}
		});
		

	}

}
