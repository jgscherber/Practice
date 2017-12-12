class Solution {
    public boolean canConstruct(String ransomNote, String magazine) {
	// are they sorted?
	int[] counts = new int[26];
	int longer = Math.max(ransomNote.length(),magazine.length() );
	int noteLen = ransomNote.length();
	int magLen = magazine.length();
	// get count comparison
        for(int i = 0; i < longer; i++) {
	    char current = ' ';
	    int cIndex = -1;
	    if(i < noteLen) {
		current = ransomNote.charAt(i);
		cIndex = ((int) current) - 97;
		counts[cIndex]--;  

	    }

	    if(i < magLen) {
		current = magazine.charAt(i);
		cIndex = ((int) current) - 97;
		counts[cIndex]++;
	    }
	}
	for(int i = 0; i<26; i++) {
	    if(counts[i] < 0) return false;
	}
	return true;
    }
}
