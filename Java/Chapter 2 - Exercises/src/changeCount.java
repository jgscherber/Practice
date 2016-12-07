import java.util.Scanner;

public class changeCount {
	public static void main(String[] args){
		Scanner stdin = new Scanner(System.in);
		int quarters;
		int dimes;
		int nickles;
		int pennies;
		
		System.out.print("Enter the number of quarters: ");
		quarters = stdin.nextInt();
		System.out.print("Enter the number of dimes: ");
		dimes = stdin.nextInt();
		System.out.print("Enter the number of nickles: ");
		nickles = stdin.nextInt();
		System.out.print("Enter the number of pennies: ");
		pennies = stdin.nextInt();
		
		double total = (quarters * 0.25) + (dimes * 0.1) + (nickles * 0.05) + (pennies * 0.1);
		System.out.printf("You have $%1.2f",total); // 1.2f at least one before decimal and 2 after it
		stdin.close();
	}
}
