// Exercise 5.4


public class DiceWithStatCalc_53 {

	/**
	 * Re-make of the problem from exercise 4.4
	 * Roll the dice 10,000 times and reports the average rolls for each number (2-12)
	 * Also report the max number it took and the standard dev for each number
	 * @param none
	 */
	public static void main(String[] args) {
		StatCalc[] data = new StatCalc[11]; // array  to hold the data for each experiment
		PairOfDice2 dice = new PairOfDice2();
		for (int face = 2; face < 13; face++) { // run the experiment for each die
			
			int trial = 0;
			int index = face - 2; // shift dice faces to index positions
			data[index] = new StatCalc(); // create a StatCalc object for the current face
			while (trial < 100000) {
				int rTotal = 0; // holds the die roll total on each attempt
				int rCount = 0; // counts the number of rolls before success
				while (rTotal != face) // roll until get current face
				{
					dice.roll();
					rTotal = dice.getDie1() + dice.getDie2();
					rCount ++;
					  
				}
				data[index].enter(rCount); // add the previous trial to the db
				trial ++;
			} // end trial			
		} // end faces
		
		for (int i = 0; i < 11; i++){
			System.out.println("____ Data for dice roll " + (i+2) + " ____");
			System.out.println("Average: " + data[i].getMean());
			System.out.println("Max: " + data[i].getMax());
			System.out.println("Std. Dev: " + data[i].getStandardDeviation());			
			
		} // end print
		

	} // end main

}
