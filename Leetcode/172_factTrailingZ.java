class Solution {
    public int trailingZeroes(int n) {
	if(n==0) return 0;
	// 5! = 5 * 4 * 3 *2 *1 = 120 --> (5, 2, 2)
	// 10,9,8,7,6,5,4,3,2 --> (5,5,2,2,2,2 ...)
	// 5's will always be deficient, only need to count them
	// and their multiples (5,25,125, etc.)
	int countFive = 0;
	// once our power of 5 is greater than n, it won't be part of
	// the factorial
	for(int i=5; n>=i; i*=5) {
	    countFive += (n/i);
	}
	return countFive;
    }
}
