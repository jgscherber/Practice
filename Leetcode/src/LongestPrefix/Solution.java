package LongestPrefix;

public class Solution {
    // brute force is easiest, but n^2
    public String longestCommonPrefix(String[] strs) {
        // edge cases: null array (emptry reference), empty array, empty string
        if (strs == null
                || strs.length == 0
                || strs[0].equals("")) return "";
        // edge case: array has one one entry
        if( strs.length == 1) return strs[0];

        int longest = 0;

        int index = -1;
        boolean matching = true;
        while(matching) {
            index++;
            if(strs[0].length() == index) break;
            char currentLetter = strs[0].charAt(index);
            for(String str: strs) {
                if(index == str.length() || str.charAt(index) != currentLetter) matching = false;
            }


        }
        if(index == 0) return "";
        else return strs[0].substring(0,index);
    }
}
/*
- horizontal scanning: assume whole 1st word is the longest prefix. Use indexOf() to see if it exists in each
    other word. If it doesn't remove the last character. If all characters are removed, return empty string

- verticle scanning: method used above, "brute force" -> same speed as horizontal scanning

-

    */