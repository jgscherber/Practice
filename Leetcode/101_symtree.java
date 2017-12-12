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
    public boolean isSymmetric(TreeNode root) {
        // symetric is left node == reversed right node
	// reflection if roots are equal and left subtree is mirror of right
	return isMirror(root,root);
	
    }

    private boolean isMirror(TreeNode t1, TreeNode t2) {
	if(t1 == null && t2 == null) return true;
	// trees aren't same depth
	if(t1 == null || t2 == null) return false;

	return (t1.val == t2.val) // roots equal
	    && isMirror(t1.right, t2.left)
	    && isMirror(t1.left, t2.right);
    }
}
