package ContainsMostWater;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;


class SolutionTest {

    int[] test1 = new int[] {4, 5,7, 2, 1};
    int[] test2 = new int[] {4, 5};

    Solution soln = new Solution();

    @Test
    void maxArea() {
        System.out.printf("test1: %d%n", soln.maxArea(test1));
        System.out.printf("test2: %d%n", soln.maxArea(test2));
    }

}