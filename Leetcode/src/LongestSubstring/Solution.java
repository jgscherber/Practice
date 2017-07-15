package LongestSubstring;

import java.util.HashMap;
import java.util.Map;

public class Solution {
    public int lengthOfLongestSubstring(String s) {

        int length = s.length();
        int currentLength = 0;
        int maxLength = 0;
        Map<Character, Integer> currentLetters = new HashMap<>();
        for(int i = 0; i < length; i++) {
            char current = s.charAt(i);
            if(currentLetters.containsKey(current)) {
                i = currentLetters.get(current);
                currentLetters = new HashMap<>();
                if(currentLength > maxLength) maxLength = currentLength;
                currentLength = 0;
            } else {
                currentLetters.put(current,i);
                currentLength++;
            }
        }

        if(currentLength > maxLength) maxLength = currentLength;
        return maxLength;
    }
}