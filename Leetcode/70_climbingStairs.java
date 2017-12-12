class Solution {
    public int climbStairs(int n) {
	HashMap<Integer, Integer> memo = new HashMap<>();
        memo.put(0,0);
        memo.put(1,1);
	memo.put(2,2);
	return climbStairsMemo(n, memo);
               
    }
    
    private int climbStairsMemo(int n, HashMap<Integer,Integer> memo) {
	if(memo.containsKey(n)) return memo.get(new Integer(n));
        else {
	    memo.put(n,
		     climbStairsMemo (n-1, memo) + climbStairsMemo (n-2,memo));
		}
	return memo.get(new Integer(n));
    }
}
