
import java.util.ArrayList;
import java.util.Arrays;
/*
Given a non-negative integer represented as a non-empty array of digits, plus one to the integer.
You may assume the integer do not contain any leading zero, except the number 0 itself.
The digits are stored such that the most significant digit is at the head of the list.
*/

class Solution {
    public int[] plusOne(int[] digits) {
	int carry = 1;
	boolean nine = true;
	int i = 0;
	while(nine && i < digits.length) {
	    if(digits[i] != 9) {
		nine = false;
	    }
	    i++;
	}
	if(nine) {
	    int[] out = new int[digits.length+1];
	    out[0] = 1;
	    for(i = 1 ; i< out.length; i++) {
		out[i] = 0;
	    }
	    return out;
	}
	for(i = digits.length -1; i>-1; i--) {
	    int current = digits[i];
	    current += carry;
	    if(current >= 10) {
		carry = 1;
		current = 0;
	    } else {
		carry = 0;
	    }
	    digits[i] = current;
	}
	return digits;
    }
}
