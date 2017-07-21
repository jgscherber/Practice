package LongestPrefix;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;


class SolutionTest {

    String[] test1 = new String[] {"c", "c"};
    String[] test2 = new String[] {"c", "d"};
    String[] test3 = new String[] {"a"};

    Solution soln = new Solution();

    @Test
    void longestCommonPrefix() {
        System.out.println(soln.longestCommonPrefix(test1));
        System.out.println(soln.longestCommonPrefix(test2));
        System.out.println(soln.longestCommonPrefix(test3));
    }

}