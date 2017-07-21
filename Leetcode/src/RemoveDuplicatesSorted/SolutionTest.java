package RemoveDuplicatesSorted;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Jacob on 7/15/2017.
 */
class SolutionTest {


    int[] test1 = new int[] {1,1,2};
    int[] test2 = new int[] {1,2,3,4};

    Solution soln = new Solution();

    @Test
    void removeDuplicates() {
        System.out.printf("test1: %d%n", soln.removeDuplicates(test1));
        System.out.printf("test2: %d%n", soln.removeDuplicates(test2));
    }

}