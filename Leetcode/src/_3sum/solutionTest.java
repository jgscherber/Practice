package _3sum;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Jacob on 7/6/2017.
 */

import java.util.Collections;
class solutionTest {


    int[] test = new int[] {0,0,0};
    Solution obj = new Solution();
    List<List<Integer>> compare = new ArrayList<>();
    List<Integer> one = new ArrayList<>();
    List<Integer> two = new ArrayList<>();
    {
        one.add(-1);
        one.add(0);
        one.add(1);
        two.add(-1);
        two.add(-1);
        two.add(2);
        compare.add(two);
        compare.add(one);
    }

    @org.junit.jupiter.api.Test
    void normal() {
        List out = obj.threeSum(test);

        for(Object one : out) {
            one = (List<Integer>) one;
            ((List<Integer>) one).forEach(System.out::print);
            System.out.println();
        }


    }


}