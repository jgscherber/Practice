package _3sum;



import java.util.*;
// do 2 values equal a negated third
public class Solution {

    public List<List<Integer>> threeSum(int[] nums) {
        List<List<Integer>> output = new ArrayList<>();
        int lastIndex = nums.length - 1;
        if (lastIndex < 2) return output;
        // put all values into Map for later quick check
        Map<Integer, List<Integer>> values = new HashMap<>();
        values.put(nums[0], new ArrayList<>());
        values.get(nums[0]).add(0);

        Set<List<Integer>> oldSet = new HashSet<>();
        int j = 0;
        for (int distance = 1; distance < lastIndex; distance++) {
            for(int i = 0; i <= lastIndex - distance; i++) {
                j = i + distance;
                // add to compliment hash on first pass
                if(distance == 1) {
                    if (values.containsKey(nums[j])) {
                        values.get(nums[j]).add(j);
                    } else {
                        values.put(nums[j], new ArrayList<>());
                        values.get(nums[j]).add(j);
                    }
                } // end add
                int possible = -(nums[i] + nums[j]);
                if (values.containsKey(possible)) {
                    List indices = values.get(possible);
                    if (indices != null && !((indices.contains(i) && indices.size()==1)
                                                || (indices.contains(j) && indices.size()==1)
                                                || (indices.contains(i) && indices.contains(j) && indices.size() == 2))) {
                        List<Integer> temp = new ArrayList<>();
                        temp.add(nums[i]);
                        temp.add(nums[j]);
                        temp.add(possible);
                        Collections.sort(temp);
                        // keep track of old solutions using HashSet
                        //System.out.printf("i: %d, j: %d, possible:", i, j,possible);
                        if (!oldSet.contains(temp)) {
                            oldSet.add(temp);
                            output.add(temp);
                        } // old check
                    } // not duplicate check
                } // exists check
            } // end j

        } // end i

        return output;
    }
}