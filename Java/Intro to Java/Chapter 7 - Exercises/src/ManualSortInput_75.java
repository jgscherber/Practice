import java.util.Scanner;


public class ManualSortInput_75 {
	static int[] input() {
		Scanner stdin = new Scanner(System.in);
		int value = 1;
		int counter = 0;
		int[] values = new int[100]; // all blank spots are default to 0
		while(value!=0 && counter < 100) {
			System.out.print("Enter the next integer: ");
			value = stdin.nextInt();
			values[counter] = value;
			counter++;			
			
		}//end while		
		return values;
	}//end input
	
	public static void main(String[] args) {
		int[] unsorted = input(); // could copy the input store length information passed back from input
		TimedSort_73.insertionSort(unsorted);
		for(int i = 0;i<unsorted.length;i++){
			System.out.print(unsorted[i]);
		}
	}//end main

}//end class
