/* The guess API is defined in the parent class GuessGame.
   @param num, your guess
   @return -1 if my number is lower, 1 if my number is higher, otherwise return 0
      int guess(int num); */

public class Solution extends GuessGame {
    public int guessNumber(int n) {
	int top = n;
        int mid = n/2;
	int bot = 1;
	int correct = guess(mid);
	while(correct != 0) {	    
	    if(correct > 0) {
		bot = mid+1;
	    } else {
		top = mid-1;
	    }
	    mid = ((top-bot) / 2) + bot;
	    correct = guess(mid);
        }
	return mid;
    }
}
