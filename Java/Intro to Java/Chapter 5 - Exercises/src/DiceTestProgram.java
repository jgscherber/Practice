import java.util.Scanner;

public class DiceTestProgram {
	public static int rollCounter(int value, PairOfDice2 die){
		int count = 0;
		int diceRoll  = 0;
		if ((value>13) || (value<2))
			throw new IllegalArgumentException();
		while(value != diceRoll)
		{
			die.roll();
			diceRoll = die.getDie1() + die.getDie2();
			count ++;
		}
		
		return count;
	}
	
	
	public static void main(String[] args) {
		PairOfDice2 dice = new PairOfDice2();
		Scanner stdin = new Scanner(System.in);
		System.out.print("Enter the dice value: ");
		int value = stdin.nextInt();
		int count = rollCounter(value, dice);
		stdin.close();
		System.out.print("It took " + count + " tries to get a " + value);
	}

}
