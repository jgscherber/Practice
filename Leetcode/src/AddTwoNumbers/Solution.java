package AddTwoNumbers;


import java.math.BigInteger;

public class Solution {
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        ListNode out = new ListNode(0);

        BigInteger number1 = new BigInteger("0");
        BigInteger multiplier = BigInteger.ONE;
        ListNode current = l1;
        while (current != null) {
            BigInteger currentVal = new BigInteger(Integer.toString(current.val));
            number1 = number1.add(currentVal.multiply(multiplier));
            multiplier = multiplier.multiply(BigInteger.TEN);
            current = current.next;
        }

        BigInteger number2 = new BigInteger("0");
        current = l2;
        multiplier = BigInteger.ONE;
        while (current != null) {
            BigInteger currentVal = new BigInteger(Integer.toString(current.val));
            number2 = number2.add(currentVal.multiply(multiplier));
            multiplier = multiplier.multiply(BigInteger.TEN);
            current = current.next;
        }

        BigInteger numberOut = number1.add(number2);
//        System.out.print(number1 + " " + number2 + " " + numberOut + "\n");
        current = out;
        // 1 - 10 - 100 - 1000 - etc
        while (numberOut.compareTo(BigInteger.ZERO) > 0) {

            long val = numberOut.mod(BigInteger.TEN).longValue();
            current.val = (int) val;
            numberOut = numberOut.divide(BigInteger.TEN);
            if(numberOut.compareTo(BigInteger.ZERO) > 0) {
                current.next = new ListNode(0);
                current = current.next;
            }
        }
        current.next = null;
        return out;
    }
}
