import java.util.Scanner;

public class eggDozens {
	public static void main(String[] args){ // need String[] args for it to recognize it as a java application
		Scanner stdin = new Scanner(System.in);
		System.out.print("How many eggs do you have? ");
		int eggs = stdin.nextInt();
		int dozens = eggs/12;
		int leftover = eggs%12; // interger division doesn't have it's own operator
		
		System.out.printf("You have %d dozen eggs with %d leftover", dozens, leftover);
		stdin.close();
			
	}
}
