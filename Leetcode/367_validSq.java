class Solution {
    public boolean isPerfectSquare(int num) {
	// all perfect squares end in 1,4,5,6,9, or 00
	int end = num % 10;
	switch (end) {
	case 2:
	case 3:
	case 7:
	case 8:
	    return false;
	}
	int i = 1;
	int iSq = i * i;
	while(iSq <= num) {
	    if(num == iSq) return true;
	    i++;
	    iSq = i*i;
	}
	return false;
    }
}
