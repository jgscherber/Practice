package speedwords;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;

import javax.swing.JOptionPane;

public class Dictionary {
	private static final String FILE_NAME = "/enable1_2-7.txt";
	private static final String ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	
	@SuppressWarnings("unchecked")
	private ArrayList<String>[] wordLists = (ArrayList<String>[]) new ArrayList[26];
	
	public Dictionary() {
		for(int i = 0; i < ALPHABET.length(); i++) {
			wordLists[i] = new ArrayList();
		}
		
		try {
			InputStream input = this.getClass().getResourceAsStream(FILE_NAME);
			BufferedReader in = new BufferedReader(new InputStreamReader(input));
			String word = in.readLine();
			while(word != null) {
				char letter = word.charAt(0);
				int list = ALPHABET.indexOf(letter);
				wordLists[list].add(word);
				word = in.readLine();
			}
			in.close();
		} catch (FileNotFoundException e) {
			String message = FILE_NAME + " not found";
			JOptionPane.showMessageDialog(null, message);
		} catch (IOException e) {
			String message = "Could not open: " + FILE_NAME;
			JOptionPane.showMessageDialog(null, message);
		}
		
	}// end Dictionary()
	
	public boolean isAWord(String word) {
		boolean found = false;
		word = word.toUpperCase();
		char letter = word.charAt(0);
		int list = ALPHABET.indexOf(letter);
		ArrayList<String> current = (ArrayList<String>)wordLists[list];
		int index = 0;
		String word2 = "";
		while(index < current.size() && word2.compareTo(word) < 0 && !found) {
			word2 = current.get(index);
			found = word2.compareTo(word) == 0;
			index++;
		}
		
		return found;
	}
	

	
	
	
}
