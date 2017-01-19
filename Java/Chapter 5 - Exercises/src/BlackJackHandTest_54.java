// Exercise 5.4
import java.util.Scanner;

public class BlackJackHandTest_54 {

	/**
	 * Need BlackJackHand, Hand, Deck, and Card classes from chapter examples 
	 * Prints out blackjack hands and their value as long as the user continues
	 * @param args
	 */
	public static void main(String[] args) {
		Deck cards = new Deck(); // deal cards from
		BlackjackHand hand = new BlackjackHand(); // deal cards to
		Scanner stdin = new Scanner(System.in);
		Card cCard;
		boolean cont = true;
		while(cont) {
			cards.shuffle();
			hand.clear();
			int numCards = (int)(Math.random()*4.9) + 2; // return (0+2)to(4+2)
			System.out.print("The cards in the hand are: \n(");
			for(int i =0; i < numCards;i++){
				cCard = cards.dealCard();
				System.out.print(cCard + " ");
				hand.addCard(cCard);				
				}//end adding cards
			System.out.println(")\nTheir total value is: " + hand.getBlackjackValue());
			System.out.print("Do you want to continue (1 or 0): ");
			
			cont = (stdin.nextInt() == 1); // ask if they want to continue 				
		} // stop continuing
		stdin.close();
	} // end main
} // end class
