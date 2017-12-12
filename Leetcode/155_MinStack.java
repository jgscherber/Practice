class MinStack {

    LinkedList<Integer> stack;
    LinkedList<Integer> minIndexes;
    LinkedList<Integer> minValues;
    int minIndex;
    int minValue;

    /** initialize your data structure here. */
    public MinStack() {
	// underlying data structure
        stack = new LinkedList<>();
	// track replaced min values
	minIndexes = new LinkedList<>();
	minValues  = new LinkedList<>();
	// need index track to know when min has left stack
	// and where in stack next min is located
        minIndex = -1;
        minValue = Integer.MAX_VALUE;
    }
    
    public void push(int x) {
        stack.push(x);
	if(x < minValue) {
	    minIndexes.push(minIndex);
	    minValues.push(minValue);
	    minIndex = -1;
	    minValue = x;
	}
	minIndex++;
    }
    
    public void pop() {
        stack.pop();
	minIndex--;
	if(minIndex < 0) {
	    minIndex = minIndexes.pop();
	    minValue = minValues.pop();
	}
    }
    
    public int top() {
        return stack.getFirst();
    }
    
    public int getMin() {
        return minValue;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.push(x);
 * obj.pop();
 * int param_3 = obj.top();
 * int param_4 = obj.getMin();
 */
