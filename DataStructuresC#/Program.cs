using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

/// <summary>
/// caesar cipher encryption, shifting each letter by k positions.
/// </summary>
class CaesarCipherProgram
{
    static string CaesarCipher(string s, int k)
    {
        k = k % 26;  // Normalize shift to within alphabet range
        char[] result = new char[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (char.IsLower(c))
            {
                // Shift lowercase letters within 'a'-'z'
                result[i] = (char)((c - 'a' + k) % 26 + 'a');
            }
            else if (char.IsUpper(c))
            {
                // Shift uppercase letters within 'A'-'Z'
                result[i] = (char)((c - 'A' + k) % 26 + 'A');
            }
            else
            {
                // Non-alphabet characters are not changed
                result[i] = c;
            }
        }

        return new string(result);
    }
}

/// <summary>
/// inorder traversal done on a binary tree of integers.
/// </summary>
public class _094_BinaryTreeInorderTraversal
{
    public IList<int> InorderTraversal(NewTreeNode root)
    {
        IList<int> result = new List<int>();
        InorderTraversal(root, result);
        return result;
    }

    // recursive helper method
    public void InorderTraversal(NewTreeNode node, IList<int> result)
    {
        if (node == null) return;

        InorderTraversal(node.left, result);   // visit left subtree
        result.Add(node.val);                  // visit current node
        InorderTraversal(node.right, result);  // visit right subtree
    }
}

/// <summary>
/// node structure for binary tree with integer values.
/// </summary>
public class NewTreeNode
{
    public int val;
    public NewTreeNode left;
    public NewTreeNode right;

    public NewTreeNode(int x) { val = x; }
}

/// <summary>
/// node structure for binary tree with character values (used for LCA).
/// </summary>
public class TreeNode
{
    public char value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(char value)
    {
        this.value = value;
        Left = Right = null;
    }
}

public class Solution
{
    /// <summary>
    /// finds the Lowest Common Ancestor (LCA) of two nodes in a binary tree.
    /// </summary>
    public static TreeNode FindLCA(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q)
            return root;

        TreeNode left = FindLCA(root.Left, p, q);
        TreeNode right = FindLCA(root.Right, p, q);

        if (left != null && right != null)
            return root;

        // Return whichever subtree has a match
        return left ?? right;
    }

    /// <summary>
    /// returns the list of medians from all sliding windows of given size in an array.
    /// </summary>
    public static List<double> SlidingWindowMedian(int[] nums, int windowSize)
    {
        var medians = new List<double>();

        if (nums == null || nums.Length == 0 || windowSize <= 0 || windowSize > nums.Length)
            return medians;

        for (int i = 0; i <= nums.Length - windowSize; i++)
        {
            var window = new List<int>();

            // fill window
            for (int j = i; j < i + windowSize; j++)
                window.Add(nums[j]);

            window.Sort(); // sorting to get median easily

            int mid = windowSize / 2;

            if (windowSize % 2 == 0)
            {
                // average of two middle values
                double median = (window[mid - 1] + window[mid]) / 2.0;
                medians.Add(median);
            }
            else
            {
                // single middle value
                medians.Add(window[mid]);
            }
        }

        return medians;
    }

    /// <summary>
    /// merges two sorted arrays A and b into A in-place.
    /// </summary>
    public void MergeSortedArrays(int[] A, int m, int[] b, int n)
    {
        int i = m - 1;            // Last element of actual A data
        int j = n - 1;            // Last element of b
        int k = m + n - 1;        // Last position in A

        // Merge from back to avoid overwriting
        while (j >= 0)
        {
            if (i >= 0 && A[i] > b[j])
            {
                A[k--] = A[i--];
            }
            else
            {
                A[k--] = b[j--];
            }
        }
    }
}
