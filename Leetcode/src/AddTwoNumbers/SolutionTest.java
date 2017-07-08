package AddTwoNumbers;

import org.junit.jupiter.api.Test;

import java.util.List;

import static org.junit.jupiter.api.Assertions.*;


class SolutionTest {

    private ListNode create(int... args) {
        ListNode out = new ListNode(0);
        ListNode current = out;
        current.val = args[0];
        for(int i = 1; i < args.length; i++) {
            current.next = new ListNode(args[i]);
            current = current.next;
        }

        return out;
    }

    Solution obj = new Solution();

    @Test
    void addTwoNumbers() {
//        ListNode out = obj.addTwoNumbers(create(2,4,3)
//                                        ,create(5,6,4));

//        ListNode out = obj.addTwoNumbers(create(1,8)
//                ,create(0));

        ListNode out = obj.addTwoNumbers(create(9),
                create(1,9,9,9,9,9,9,9,9,9));
        printList(out);

    }

    void printList(ListNode out) {
        System.out.print("[");
        while(out != null) {
            System.out.print(out.val +",");
            out = out.next;
        }
        System.out.print("]");
    }

}