/**
Given preorder and inorder traversal of a tree, construct the binary tree.

Note:
You may assume that duplicates do not exist in the tree.

For example, given

preorder = [3,9,20,15,7]
inorder = [9,3,15,20,7]
Return the following binary tree:

    3
   / \
  9  20
    /  \
   15   7
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
import java.util.*;
class ConstructTree {
    public TreeNode buildTree(int[] preorder, int[] inorder) {
        if(preorder.length == 0 || inorder.length == 0) return null;

        TreeNode n = new TreeNode(preorder[0]);
        int breakpoint = 0;
        for (int i = 0; i < inorder.length; i ++)
        {
            if (inorder[i] == preorder[0])
            {
                breakpoint = i;
                break;
            }
        }
            n.left = buildTree(Arrays.copyOfRange(preorder, 1, breakpoint+1),
                     Arrays.copyOfRange(inorder, 0, breakpoint));
            n.right = buildTree(Arrays.copyOfRange(preorder, breakpoint+1, inorder.length),
                     Arrays.copyOfRange(inorder, breakpoint+1, inorder.length));
        return n;
    }
}
