package ReverseInteger;

public class Solution {
    public int reverse(int x) {

        // input is 32-bit signed int, return 0 if overflows
        String number = Integer.toString(x);
        StringBuilder out = new StringBuilder();
        boolean negative = ('-' == number.charAt(0));

        int start = 0;
        if(negative) start = 1;

        for(int i = number.length()-1; i > start; i--){


        }

        String reversed = out.toString();
        if(reversed.compareTo(
                Integer.toString(Integer.MAX_VALUE)) > 0) {
            return 0;
        }


        return 1;
    }
}
