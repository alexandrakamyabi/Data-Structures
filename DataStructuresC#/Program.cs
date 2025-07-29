using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

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
        foreach (var v in Console.ReadLine().Split())
            arr.Add(int.Parse(v));

        var solve = new BeautifulTriplets();
        Console.WriteLine(solve.CountBeautifulTriplets(d, arr));

        // ---------------- Angry Profssor ----------------
        var prof = new Professor();

        var result1 = prof.AngryProfessor(3, new List<int> { -1, -3, 4, 2 });
        var result2 = prof.AngryProfessor(2, new List<int> { 0, -1, 2, 1 });

        Console.WriteLine("Will class run: " + result1);
        Console.WriteLine("Will class run: " + result2);

        // ---------------- Matrix Multiplier ----------------
        int[,] matrixA = {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };

        int[,] matrixB = {
            { 7, 8 },
            { 9, 10 },
            { 11, 12 }
        };

        int[,] C = MatrixMultiplier.Multiply(matrixA, matrixB);

        Console.WriteLine("Resulting Matrix C:");
        for (int i = 0; i < C.GetLength(0); i++)
        {
            for (int j = 0; j < C.GetLength(1); j++)
            {
                Console.Write(C[i, j] + " ");
            }
            Console.WriteLine();
        }

        // ---------------- Climbing Leaderboard ----------------
        List<int> ranked = new List<int> { 100, 100, 50, 40, 40, 20, 10 };
        List<int> player = new List<int> { 5, 25, 50, 120 };

        List<int> result = Leaderboard.CLimbingLeaderboard(ranked, player);

        Console.WriteLine("Player ranks: " + string.Join(" ", result));

        // ---------------- Queens Attack ----------------
        // Test 1
        int n1 = 4, k1 = 0, r_q1 = 4, c_q1 = 4;
        List<List<int>> obs1 = new();
        Console.WriteLine("Test 1: " + (QueensAttack.QueensAttackChess(n1, k1, r_q1, c_q1, obs1) == 9 ? "Passed" : "Failed"));

        // Test 2
        int n2 = 5, k2 = 3, r_q2 = 4, c_q2 = 3;
        List<List<int>> obs2 = new()
    {
        new List<int>{5, 5},
        new List<int>{4, 2},
        new List<int>{2, 3}
    };
        Console.WriteLine("Test 2: " + (QueensAttack.QueensAttackChess(n2, k2, r_q2, c_q2, obs2) == 10 ? "Passed" : "Failed"));

        // Test 3
        int n3 = 1, k3 = 0, r_q3 = 1, c_q3 = 1;
        List<List<int>> obs3 = new();
        Console.WriteLine("Test 3: " + (QueensAttack.QueensAttackChess(n3, k3, r_q3, c_q3, obs3) == 0 ? "Passed" : "Failed"));

        var tests = new Dictionary<string, string>
    {
        { "haveaniceday", "hae and via ecy" },
        { "feedthedog", "fto ehg ee dd" },
        { "chillout", "clu hlt io" },
        { "iffactsdontfittotheorychangethefacts", "isieae fdtonf fotrga anoyec cttctt tfhhhs" }
    };

        // ---------------- Encryption ----------------
        foreach (var test in tests)
        {
            string output = Encryption.TextEncryption(test.Key);
            Console.WriteLine($"Input: \"{test.Key}\"\nExpected: \"{test.Value}\"\nOutput:   \"{output}\"\n");
            Debug.Assert(output == test.Value);
        }

        Console.WriteLine("All tests passed!");


        string[] input = Console.ReadLine().Split(' ');
        int l = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        string[] elements = Console.ReadLine().Split(' ');
        List<int> s = new List<int>();

        for (int i = 0; i < l; i++)
        {
            s.Add(int.Parse(elements[i]));
        }

        NonDivisibleSubsetSolver subsetSolver = new NonDivisibleSubsetSolver(k, s);
        Console.WriteLine(subsetSolver.GetMaxSubsetSize());
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


/// <summary>
/// Given an increasing sequenc of integers and the value of d
/// count the number of beautiful triplets in the sequence.
/// </summary>


public class Professor
{
    public string AngryProfessor(int k, List<int> a)
    {
        int onTime = 0;
        foreach (int arrival in a)
        {
            if (arrival <= 0) onTime++;
            if (onTime >= k) return "No";
        }
        return "Yes";
    }
}


/// <summary>
/// Multithreaded matrix multiplication
/// </summary>


public class MatrixMultiplier
{
    public static int[,] Multiply(int[,] A, int[,] B)
    {
        int N = A.GetLength(0);
        int M = A.GetLength(1);
        int P = B.GetLength(1);
        int[,] C = new int[N, P];

        List<Task> tasks = new List<Task>();

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < P; j++)
            {
                int row = i, col = j;
                tasks.Add(Task.Run(() =>
                {
                    int sum = 0;
                    for (int k = 0; k < M; k++)
                        sum += A[row, k] * B[k, col];
                    C[row, col] = sum;
                }));
            }
        }

        Task.WaitAll(tasks.ToArray());
        return C;
    }
}


/// <summary>
/// returns the minimal cost to convert a 3x3 matrix into a magic square
/// </summary>


public class MagicSquare
{
    public static int FormingMagicSquare(int[][] s)
    {
        int[][][] magicSquares = new int[][][]
        {
        new int[][] { new[] {8,1,6}, new[] {3,5,7}, new[] {4,9,2} },
        new int[][] { new[] {6,1,8}, new[] {7,5,3}, new[] {2,9,4} },
        new int[][] { new[] {4,9,2}, new[] {3,5,7}, new[] {8,1,6} },
        new int[][] { new[] {2,9,4}, new[] {7,5,3}, new[] {6,1,8} },
        new int[][] { new[] {8,3,4}, new[] {1,5,9}, new[] {6,7,2} },
        new int[][] { new[] {4,3,8}, new[] {9,5,1}, new[] {2,7,6} },
        new int[][] { new[] {6,7,2}, new[] {1,5,9}, new[] {8,3,4} },
        new int[][] { new[] {2,7,6}, new[] {9,5,1}, new[] {4,3,8} }
        };

        int minCost = int.MaxValue;

        foreach (var magic in magicSquares)
        {
            int cost = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    cost += Math.Abs(s[i][j] - magic[i][j]);
            minCost = Math.Min(minCost, cost);
        }

        return minCost;
    }
}


/// <summary>
/// determines the player's rank after each new score using dense ranking.
/// removes duplicates from leaderboard, then compares each player score
/// from lowest to highest using reverse scan.
/// </summary>


public class Leaderboard
{
    public static List <int> CLimbingLeaderboard(List<int> ranked, List<int> player)
    {
        List<int> result = new List<int>();
        List<int> unique = new List<int>();
        unique.Add(ranked[0]);
        for (int i = 1; i < ranked.Count; i++)
        {
            if (ranked[i] != ranked[i - 1])
                unique.Add(ranked[i]);
        }

        int index = unique.Count - 1;

        foreach (int score in player)
        {
            while (index >= 0 && score >= unique[index])
                index--;
            result.Add(index + 2);
        }

        return result;
    }
}


/// <summary>
/// This class calculates how many squares a queen can attack on an 
/// n × n chessboard, considering obstacles that block her movement in any of the 
/// 8 directions (up, down, left, right, and diagonals). It loops through each direction and
/// counts how far the queen can move until she hits the board edge or an obstacle.
/// </summary>


public class QueensAttack
{
    public static int QueensAttackChess(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        HashSet<string> obs = new HashSet<string>();
        foreach (var o in obstacles)
            obs.Add($"{o[0]},{o[1]}");

        int[,] directions = {
        {-1,  0}, // up
        { 1,  0}, // down
        { 0, -1}, // left
        { 0,  1}, // right
        {-1, -1}, // up-left
        {-1,  1}, // up-right
        { 1, -1}, // down-left
        { 1,  1}  // down-right
    };

        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            int r = r_q + directions[i, 0];
            int c = c_q + directions[i, 1];
            while (r >= 1 && r <= n && c >= 1 && c <= n && !obs.Contains($"{r},{c}"))
            {
                count++;
                r += directions[i, 0];
                c += directions[i, 1];
            }
        }
        return count;
    }
}


/// <summary>
/// removes spaces from the input.
/// computes rows and columns using the square root of the length.
/// fills a virtual grid row wise.
/// reads column wise to build the encrypted message.


public class Encryption
{
    public static string TextEncryption (string s)
    {
        s.Replace(" ", "");
        int len = s.Length;

        int rows = (int)Math.Floor(Math.Sqrt(len));
        int cols = (int)Math.Ceiling(Math.Sqrt(len));
        if (rows * cols < len) rows++;

        List<string> result = new List<string>();
        for (int c = 0; c < cols; c++)
        {
            string word = "";
            for (int r = 0; r < rows; r++)
            {
                int idx = r * cols + c;
                if (idx < len)
                    word += s[idx];
            }
            result.Add(word);
        }

        return string.Join(" ", result);
    }
}


/// <summary>
/// given a list of distinct integers and a divisor k,
/// find the size of the largest subset such that no two
/// numbers in the subset add up to a multiple of k.
/// </summary>


class NonDivisibleSubsetSolver
{
    private int k;
    private List<int> elements;

    public NonDivisibleSubsetSolver(int divisor, List<int> s)
    {
        k = divisor;
        elements = s;
    }

    public int GetMaxSubsetSize()
    {
        int[] remainderCount = new int[k];

        foreach (int num in elements)
        {
            remainderCount[num % k]++;
        }

        int result = Math.Min(remainderCount[0], 1);

        for (int r = 1; r <= k / 2; r++)
        {
            if (r == k - r)
            {
                result += 1; // k even
            }
            else
            {
                result += Math.Max(remainderCount[r], remainderCount[k - r]);
            }
        }

        return result;
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