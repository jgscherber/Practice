class Solution {
    public int firstUniqChar(String s) {
	int[] counts = new int[26];
	int l = s.length();
	for(int i = 0; i < l; i++) {
	    int cIndex = s.charAt(i) - 'a';
	    counts[cIndex]++;
	}
	for(int i = 0; i < l; i++) {
	    int cIndex = s.charAt(i) - 'a';
	    if(counts[cIndex] < 2) return i;
	}

	return -1;
        
    }
}
