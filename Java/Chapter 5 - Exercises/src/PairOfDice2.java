
public class PairOfDice2 {
	// instantiation
	private int die1;
	private int die2;
	
	public PairOfDice2(){
		die1 = (int)(Math.random()*5.9)+1;
		die2 = (int)(Math.random()*5.9)+1;
	}
	public PairOfDice2(int die1, int die2){
		this.die1 = die1;
		this.die2 = die2;
	}	
	// getter methods	
	public int getDie1(){
		return die1;
	}
	
	public int getDie2(){
		return die2;		
	}
	
	public String toString(){
				return (String.valueOf(die1) + ":" + String.valueOf(die2));		
						}
	
	// public methods
	public void roll(){
		die1 = (int)(Math.random()*5.9)+1;
		die2 = (int)(Math.random()*5.9)+1;
	}

}
