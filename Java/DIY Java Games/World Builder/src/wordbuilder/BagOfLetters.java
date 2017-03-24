package wordbuilder;

import java.util.ArrayList;
import java.util.Random;

public class BagOfLetters {
	
	private ArrayList<LetterPanel> letterPanels = new ArrayList<>();
	
	private String letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	
	private int[] quantity = {8, 2, 2, 4, 12, 2, 3, 2, 9, 1, 1,
			4, 2, 6, 8, 2, 1, 6, 4, 6, 4, 1, 2, 1, 2, 1 };
	
	private int[] points = {1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 
			3, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 4, 10};
	
	private Random rand = new Random();
	
	public BagOfLetters() {
		for(int i = 0; i < 26; i++) {
			char letter = letters.charAt(i);
			int currentQuant = quantity[i];
			int letterPoints = points[i];
			
			for(int j = 0; j < currentQuant; j++) {
				letterPanels.add(new LetterPanel(""+letter, letterPoints));
			}
		}
	} // end BagOfLetters()
	
	public LetterPanel pickALetter() {
		int size = letterPanels.size();
		if(size > 0) {
			int pick = rand.nextInt(size);
			return letterPanels.remove(pick);
		}
		return null;
	}
	
}
