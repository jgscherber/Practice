import java.util.Scanner;

public class Capitalize {
	
	// encapsulation of pure function
	
	public static String printCapitalized(String sentence){
		String n_sentence = new String(); // declaring vs. initializing
		boolean inWord = false;
		for(int i=0;i<sentence.length();i++)
		{
			if(Character.isLetter(sentence.charAt(i)) && !inWord)
			{
				n_sentence += Character.toUpperCase(sentence.charAt(i));
				inWord=true;
			}
			else
			{
				n_sentence += sentence.charAt(i);
			}
			if(!Character.isLetter(sentence.charAt(i)))
					inWord=false;
			
		}
		
		return n_sentence;
	}
	
	
	public static void main(String[] args) {
		Scanner stdin = new Scanner(System.in);
		System.out.print("Enter String to capitalize: ");
		String o_sentence = stdin.nextLine();
		String n_sentence = printCapitalized(o_sentence); // static functions can only reference other static functions
		System.out.print("The capitalized sentence is \"" + n_sentence +"\"");
		stdin.close();
	}

}
