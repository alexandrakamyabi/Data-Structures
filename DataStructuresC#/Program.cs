using System;
using System.Collections.Generic;

/// <summary>
/// Main entry point for running multiple algorithm, data structure demos and HackerRank/LeetCode problems.
/// Simulates a C++ style `main()` structure in C#.
/// </summary>
class Program
{
    static void Main()
    {
        // ---------------- Caesar Cipher Test ----------------
        string encrypted = CaesarCipher("middle-Outz", 2);
        Console.WriteLine("Caesar Cipher: " + encrypted);

        // ---------------- Binary Tree Inorder Traversal ----------------
        var root = new NewTreeNode(1)
        {
            right = new NewTreeNode(2)
            {
                left = new NewTreeNode(3)
            }
        };
        var traversal = new BinaryTreeInorderTraversal();
        IList<int> inorder = traversal.InorderTraversal(root);
        Console.WriteLine("Inorder Traversal: " + string.Join(",", inorder));

        // ---------------- Sliding Window Median ----------------
        int[] nums = { 1, 2, 3, 4, 5 };
        List<double> medians = Solution.SlidingWindowMedian(nums, 3);
        Console.WriteLine("Sliding Window Medians: " + string.Join(", ", medians));

        // ---------------- Merge Sorted Arrays ----------------
        int[] A = { 1, 2, 3, 0, 0, 0 };
        int[] B = { 2, 5, 6 };
        var sol = new Solution();
        sol.MergeSortedArrays(A, 3, B, 3);
        Console.WriteLine("Merged Array: " + string.Join(", ", A));

        // ---------------- Lowest Common Ancestor ----------------
        TreeNode a = new TreeNode('D');
        TreeNode b = new TreeNode('E');
        TreeNode rootLCA = new TreeNode('B') { Left = a, Right = b };
        TreeNode lca = Solution.FindLCA(rootLCA, a, b);
        Console.WriteLine("LCA of D and E: " + lca.value);
        // ---------------- Which cat will catch the mouse first? ----------------
        var solver = new CatAndMouseSolver();

        int queries = int.Parse(Console.ReadLine());

        for (int i = 0; i < queries; i++)
        {
            var parts = Console.ReadLine().Split();
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);
            int z = int.Parse(parts[2]);

            Console.WriteLine(solver.GetWinner(x, y, z));
        }
        // ---------------- How many beautiful triplets? ----------------
        var inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int d = int.Parse(inputs[1]);

        var arr = new List<int>();
        foreach (var s in Console.ReadLine().Split())
            arr.Add(int.Parse(s));

        var solve = new BeautifulTriplets();
        Console.WriteLine(solve.CountBeautifulTriplets(d, arr));
    }

    /// <summary>
    /// Caesar cipher encryption: shifts each letter by a given offset.
    /// Non alphabet characters remain unchanged.
    /// </summary>
    /// <param name="s">Original string</param>
    /// <param name="k">Shift amount</param>
    /// <returns>Encrypted string</returns>
    static string CaesarCipher(string s, int k)
    {
        k %= 26;
        char[] result = new char[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (char.IsLower(c))
                result[i] = (char)((c - 'a' + k) % 26 + 'a');
            else if (char.IsUpper(c))
                result[i] = (char)((c - 'A' + k) % 26 + 'A');
            else
                result[i] = c;
        }

        return new string(result);
    }
}
/// <summary>
/// Binary tree node structure for integers.
/// </summary>
public class NewTreeNode
{
    public int val;
    public NewTreeNode left;
    public NewTreeNode right;

    public NewTreeNode(int x) => val = x;
}

/// <summary>
/// Performs recursive inorder traversal on a binary tree of integers.
/// </summary>
public class BinaryTreeInorderTraversal
{
    /// <summary>
    /// Public method that initializes the result list and calls the traversal.
    /// </summary>
    public IList<int> InorderTraversal(NewTreeNode root)
    {
        IList<int> result = new List<int>();
        InorderTraversal(root, result);
        return result;
    }

    /// <summary>
    /// Recursive helper method for inorder traversal.
    /// </summary>
    private void InorderTraversal(NewTreeNode node, IList<int> result)
    {
        if (node == null) return;
        InorderTraversal(node.left, result);
        result.Add(node.val);
        InorderTraversal(node.right, result);
    }
}

/// <summary>
/// Node structure for character based binary trees.
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

/// <summary>
/// Determines which cat will catch the mouse first or if the mouse escapes.
/// </summary>
/// <param name="catA">Position of Cat A</param>
/// <param name="catB">Position of Cat B</param>
/// <param name="mouse">Position of the Mouse</param>
/// <returns>"Cat A", "Cat B", or "Mouse C"</returns>
public class CatAndMouseSolver
{
    public string GetWinner(int catA, int catB, int mouse)
    {
        int distanceA = Math.Abs(catA - mouse);
        int distanceB = Math.Abs(catB - mouse);

        if (distanceA < distanceB)
            return "Cat A";
        else if (distanceB < distanceA)
            return "Cat B";
        else
            return "Mouse C";
    }
}
/// <summary>
/// Given an increasing sequenc of integers and the value of d
/// count the number of beautiful triplets in the sequence.
/// </summary>
///
public class BeautifulTriplets
{
    public int CountBeautifulTriplets(int d, List<int> arr)
    {
        var set = new HashSet<int>(arr);
        int count = 0;

        foreach (int num in arr)
        {
            if (set.Contains(num + d) && set.Contains(num + 2 * d))
                count++;
        }

        return count;
    }
}
public class Solution
{
    /// <summary>
    /// Finds the Lowest Common Ancestor (LCA) of two nodes in a binary tree.
    /// </summary>
    public static TreeNode FindLCA(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q) return root;
        TreeNode left = FindLCA(root.Left, p, q);
        TreeNode right = FindLCA(root.Right, p, q);
        return (left != null && right != null) ? root : left ?? right;
    }

    /// <summary>
    /// Computes median values for all sliding windows of a fixed size in the array.
    /// </summary>
    public static List<double> SlidingWindowMedian(int[] nums, int windowSize)
    {
        var medians = new List<double>();
        if (nums == null || nums.Length == 0 || windowSize <= 0 || windowSize > nums.Length)
            return medians;

        for (int i = 0; i <= nums.Length - windowSize; i++)
        {
            var window = new List<int>();
            for (int j = i; j < i + windowSize; j++)
                window.Add(nums[j]);

            window.Sort();
            int mid = windowSize / 2;
            medians.Add(windowSize % 2 == 0
                ? (window[mid - 1] + window[mid]) / 2.0
                : window[mid]);
        }

        return medians;
    }

    /// <summary>
    /// Merges two sorted arrays in place into array A.
    /// </summary>
    public void MergeSortedArrays(int[] A, int m, int[] b, int n)
    {
        int i = m - 1, j = n - 1, k = m + n - 1;
        while (j >= 0)
        {
            if (i >= 0 && A[i] > b[j])
                A[k--] = A[i--];
            else
                A[k--] = b[j--];
        }
    }
}
