import java.util.Scanner;

public class capitalHI {
	public static void main(String[] args){
		Scanner stdin = new Scanner(System.in);
		System.out.println("Enter your name: ");
		String name = stdin.next();
		name = name.toUpperCase();
		stdin.close();
		System.out.println("Hello, "+name+", nice to meet you!");
						
		
	} // end main
} // end class
