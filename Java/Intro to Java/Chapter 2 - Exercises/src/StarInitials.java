import java.util.Scanner;


public class StarInitials {
	
	public static void main(String[] args) {
		Scanner stdin = new Scanner(System.in); 
		System.out.print("Enter your initials: ");
		String initials;
		initials = stdin.next();
		System.out.print(initials);
		stdin.close();
	}

}
