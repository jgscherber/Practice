package speedwords;

import javax.swing.JPanel;

public class LetterTile extends JPanel {
	private static final long serialVersionUID = 1L;
	
	public static final int SIZE = 40;
	private String letter;
	
	public LetterTile(String letter) {
		this.letter = letter;
	}

}
