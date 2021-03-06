// Exercise 5.5
import java.util.Scanner;

public class BlackjackGame_55 {
	
	/*
	 *  Uses a subrouting to play the game, return boolean about whether player won
	 *  Player can bet each round if return from game will be true or false
	 */	
	public static void main(String[] args) {
		Scanner stdin = new Scanner(System.in);
		int chips = 100;
		boolean cont = true;
		while(cont){ // keep playing until stop or out of chips
			System.out.println("How many chips to bet? You currently have " + chips);
			int bet = stdin.nextInt();			
			boolean won = game();
			if (won) {
				System.out.println("You won!");
				chips += bet;
				}
			else{
				System.out.println("You lost.");
				chips -= bet;
				}
			if(chips<=0){
				System.out.println("Out of chips!");
				break;
				}			
			System.out.print("Do you want to continue (1 or 0): ");
			cont = (stdin.nextInt() == 1); // ask if they want to continue
			
			
			
		} // end playing
		stdin.close();
		
		

	} //end main
	
	// One deck, two hands (one for player, one for dealer)
	// Deal 2 cards to each player (first two to player)
	// 21 is a win, die goes to dealer
	// Player loses over 21 or less than dealer
	// Dealer hits while less than or equal to 16
	// Return value is if player won
	private static boolean game() {
		
		// instantiations
		Deck cards = new Deck();
		BlackjackHand player = new BlackjackHand();
		BlackjackHand dealer = new BlackjackHand();
		Scanner stdin = new Scanner(System.in);
		
		// setup first hands
		cards.shuffle();
		player.addCard(cards.dealCard());
		player.addCard(cards.dealCard());
		dealer.addCard(cards.dealCard());
		dealer.addCard(cards.dealCard());
		
		// play until a winner
		while(true){
			System.out.println("The dealer has: " + dealer.getBlackjackValue());
			System.out.println("The player has: " + player.getBlackjackValue());
			if (dealer.getBlackjackValue()==21) {return false;} // player lost
			if (player.getBlackjackValue()==21) {return true;} // player wins
			System.out.print("Enter 1 to hit and 0 to stay: ");
			if (stdin.nextInt()==1){ // hitting
				player.addCard(cards.dealCard());
				System.out.println("The player has: " + player.getBlackjackValue());
				if (player.getBlackjackValue()==21) {return true;} // player wins
				if (player.getBlackjackValue() > 21){return false;}
			}
			else { // staying
				while(dealer.getBlackjackValue()<17){
					dealer.addCard(cards.dealCard());
					System.out.println("The dealer has: " + dealer.getBlackjackValue());
					
				}
				if(dealer.getBlackjackValue()<22){//dealer didnt bust
					return(player.getBlackjackValue()>dealer.getBlackjackValue()); // if players hand is higher, they win
				}
				else{ // dealer busted
					return(true); // player won
				}
				
			}
			
			
		}// loop until game returns
		
		
	} // end game
	

} // end class
