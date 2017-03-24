package worldbuilder;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

import javax.swing.JOptionPane;

public class Dictionary {

	private static final String 
			FILENAME = "enable1_3-15.txt",
			ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	
	@SuppressWarnings("unchecked")
	private ArrayList<String>[] wordList = (ArrayList<String>[]) new ArrayList[26]; 
	
	public Dictionary() {
		for(int i = 0; i < 26; i++) {
			wordList[i] = new ArrayList<String>();
		}
		
		// read in the words from file
		try {
			BufferedReader in = new BufferedReader(new FileReader(new File(FILENAME)));
			
			String word = in.readLine();
			while(word != null) {
				// get the correct list
				char letter = word.charAt(0);
				int list = ALPHABET.indexOf(letter);
				wordList[list].add(word);
				
				word = in.readLine();
				
			}
			in.close();
		} catch (FileNotFoundException e) {
			String message = "File not found";
			JOptionPane.showMessageDialog(null, message); // no observer window
		} catch (IOException e) {
			String message = "Could not open file";
			JOptionPane.showMessageDialog(null, message);
			}
		
	} // end Dictionary()
	
	public boolean isAWord(String word) {
		if(word == null
				|| word.length() == 0 ) return false;		
		word = word.toUpperCase();
		
		// get the correct list
		char letter = word.charAt(0);
		int list = ALPHABET.indexOf(letter);
		ArrayList<String> current = wordList[list];
		
		// check if the word within
		int i = 0;
		String word2 = "";
		while(i < current.size()) {
			word2 = current.get(i);
			int relate = word.compareTo(word2);
			if(relate == 0) return true;
			if(relate < 0) return false;
			i++;
		}
		
		return false;
	}
	
	public static void main(String[] args) {
		Dictionary dictionary = new Dictionary();
		String word = null;
		
		System.out.println(dictionary.isAWord(word));

	}

}
