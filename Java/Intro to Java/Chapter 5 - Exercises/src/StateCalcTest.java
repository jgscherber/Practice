// Exercise 5.2

import java.util.Scanner;

public class StateCalcTest {

	/**
	 * Small program used to test the StateCalc class 
	 */	
	public static void main(String[] args) {
		StatCalc calc = new StatCalc(); // Object to be used to process the data
		double data; // Reference to hold the entered data
		boolean working = true; // flag for when the user is done entering information
		Scanner stdin = new Scanner(System.in); // Scanner object to get data from command line
		
		while(working){
			System.out.print("Enter the next number: ");
			try{ 
				data = stdin.nextDouble();
				calc.enter(data);
				}
			catch(java.util.InputMismatchException e) {
				working = false;
			}
			}
		stdin.close();
		System.out.println("Max: "+ calc.getMax());
		System.out.println("Min: " + calc.getMin());
		
		}
	}
