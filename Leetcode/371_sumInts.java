// from: https://stackoverflow.com/questions/4068033/add-two-integers-using-only-bitwise-operators

class Solution {
    public int getSum(int a, int b) {
        // which bits will result in a carry
	int carry = a & b;
	// get the basic bit pattern
	int result = a ^ b;
	while(carry != 0) {
	    // started at far right, perform the carry
	    int shifted = carry << 1;
	    // check which ones now need a carry
	    carry = result & shifted;
	    // re-compute add?
	    result ^= shifted;
	}
	return result;
    }

}
