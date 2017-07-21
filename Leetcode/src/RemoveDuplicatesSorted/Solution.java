package RemoveDuplicatesSorted;

public class Solution {
    public int removeDuplicates(int[] nums) {
        // mutating the array outside the function... use double pointers, shifting 1st as hit uniques
        // edge case: empty ref, empty array
        if(nums == null || nums.length == 0) return 0;
        int newLength = 0;
        // loop through and increase index at each unique element
        for(int i = 0; i < nums.length;) {
            int current = nums[i];
            newLength++;
            while(i < nums.length && nums[i] == current) {
                i++;
            }
        }
        return newLength;
    }
}
