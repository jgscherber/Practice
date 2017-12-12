/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
class Solution {
    public boolean hasPathSum(TreeNode root, int sum) {
	if(root == null) return false;
	if(root.left == null && root.right==null)
	    return (root.val == sum);
	return traverseTree(root.left, sum-root.val)
	    || traverseTree(root.right, sum-root.val);
    }

    private boolean traverseTree(TreeNode root, int sum) {
	if(root == null) return false;
	int val = root.val;
	if(sum != val) {
	     return traverseTree(root.left, sum-val) ||
		traverseTree(root.right, sum-val);
	}
	else
	    if(root.left == null && root.right == null){
		return true;
	    } else {
		return traverseTree(root.left, sum-val) ||
		traverseTree(root.right, sum-val);
	    }
	
    }
}

