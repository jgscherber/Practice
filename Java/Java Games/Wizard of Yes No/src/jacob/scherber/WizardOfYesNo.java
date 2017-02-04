package jacob.scherber;

import java.awt.Font;
import java.util.Random;

import javax.swing.JFrame;
import javax.swing.JLabel;

public class WizardOfYesNo extends JFrame { // use JFrame as the superclass for programs that start with a window
	
	private static final String[] ANSWER = {"Yes","No","If you must","If it pleases","Go now!", "You must!", "Never!"};
	
	public WizardOfYesNo() {
		
		
		
			
		// -- label creation --
		Random rand = new Random();
		int numberOfAnswers = ANSWER.length;
		int pick = rand.nextInt(numberOfAnswers);
		String answer = ANSWER[pick];
		//JLabel label = new JLabel("Yes"); // text set on instantiation
		JLabel label = new JLabel();
		label.setText(answer); // set text after instantiation
		add(label); // puts it in window w/o packing
		
		
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
		
		new WizardOfYesNo(); // instantiates JFrame object

	}

}
