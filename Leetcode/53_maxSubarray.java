

// [-2,1,-3,4,-1,2,1,-5,4]
// [4,-1,2,1]

class Solution {
    public int maxSubArray(int[] nums) {

	// max sub-vector initially only the first element
	int maxSoFar = nums[0];

	// Suppose solved for A[0...i-1], how to extend to A[1...i]
	// (base case: i=1)
	int maxEndingHere = nums[0];
	

	for(int i=1; i<nums.length; ++i) {
	    // max sub-vector either includes A[i] with all previous entries
	    // or with all subsequent entries
	    maxEndingHere = Math.max(maxEndingHere+nums[i], nums[i]);
	    maxSoFar = Math.max(maxSoFar, maxEndingHere); // (easier check of new max)	    
	}
	return maxSoFar;
    }// end maxSubArray()
}
