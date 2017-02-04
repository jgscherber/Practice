
public class AvgDiceRoll {

	public static void main(String[] args) {
		int dice1;
		int dice2;
		int[] rolls; // creates a variable of type int-array 
		rolls = new int[1000000]; // creates a new int-array of size 100 and assigns it to rolls
		boolean snakes = false;
		int trials = 0;
		int roll_num = 1;
		while((trials != rolls.length)) // use length of trials as array for end criteria, easier to do more trials
		{
			
			roll_num = 1;
			while (!snakes)
			{
			dice1 = (int)(Math.random()*5)+1;
			dice2 = (int)(Math.random()*5)+1;
			
			if (dice1+dice2== 2)
			{
				snakes = true;
				
			}
			else
			{
				roll_num += 1;
			}
			}
			rolls[trials] = roll_num;
			trials += 1;
			snakes = false;
		}
		int total = 0;
		for(int i=0;i<rolls.length;i++)
		{
			total += rolls[i];
		}
		System.out.println("The average number of rolls was " + (total/(float)rolls.length));

	}

}
