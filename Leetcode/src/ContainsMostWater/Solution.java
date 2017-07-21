package ContainsMostWater;

public class Solution {
    // O(n): come from both ends, moving the short of the 2 (decrease in width, must be accompanied by increase in height)
    //       untill the 2 pointers cross
    public int maxArea(int[] height) {
        // brute force is n^2
        int max = 0;
        // height will be of the shorter of 2 lines * width between the 2 points
        // v =  min(h[i],h[j]) * (j-i)
        for(int i = 0; i < height.length-1; i ++) {
            for(int j = i+1; j < height.length; j++) {
                int h = Math.min(height[i], height[j]);
                int w = j - i;
                int current = h * w;
                if(current > max) max = current;
            }
        }
        return max;
    }
}

