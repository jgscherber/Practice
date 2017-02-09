package jacob.scherber.watchyourstep;

import java.awt.BorderLayout;

import javax.swing.JFrame;

import jacob.scherber.mycomponents.TitleLabel;

public class WatchYourStep extends JFrame {
	
	private static final long serialVersionUID = 1L;
	
	public WatchYourStep() {
		initGUI();
		pack();
		setVisible(true);
		
		
		
	}
	
	public void initGUI() {
		TitleLabel titleLabel = new TitleLabel("Watch Your Step");
		add(titleLabel, BorderLayout.PAGE_START);
		
		
	}
	
	
	public static void main(String[] args) {
		new WatchYourStep();

	}

}
