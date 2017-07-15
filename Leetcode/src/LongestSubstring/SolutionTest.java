package LongestSubstring;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class SolutionTest {

    Solution obj = new Solution();

    String test1 = "abcabcbb";
    String test2 = "bbbbb";
    String test3 = "pwwkew";
    String test4 = "c";

    @Test
    void lengthOfLongestSubstring() {
        System.out.println(obj.lengthOfLongestSubstring(test4));
    }

}