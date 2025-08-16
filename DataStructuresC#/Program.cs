using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

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

        // ---------------- Ball Organizer ----------------
        sol.TestBallOrganizer();

        // ---------------- Bigger is Greate ----------------
        sol.TestBiggerIsGreater();

        // ---------------- Lambda Sort ----------------
        sol.TestLambdaSort();

        // ---------------- Bounded Blocking Queue ----------------
        sol.BoundedBlocking();

        // ---------------- Test LINQ Filter ----------------
        sol.TestLINQFilter();


        // ---------------- Dijkstra Demo ----------------
        sol.DijkstraDemo();

        // ---------------- Read Write Lock ----------------
        sol.ReadWriteLockDemo();
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
/// LINQ filtering practice problem
/// </summary>


public class Employee
{
    public string Name;
    public string Department;
    public int Salary;
}


public class LINQFilter
{
    public static List<string> GetHighPaidEngineers(List<Employee> employees)
    {
        return employees
            .Where(e => e.Department == "Engineering" && e.Salary >= 100000)
            .Select(e => e.Name)
            .ToList();
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


public class NonDivisibleSubsetSolver
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


/// <summary>
/// given a list of people’s names and ages, sorts them by:
/// age ascending**, and if ages are equal
/// name lexicographically ascending**
/// </summary>

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}


public class LambdaSort
{
    public static void SortPeople(List<Person> people)
    {
        var sorted = people
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Name)
            .ToList();

        foreach (var person in sorted)
            Console.WriteLine($"{person.Name} - {person.Age}");
    }
}


/// <summary>
/// Checks if it's possible to sort containers so that each type of ball is in its own container.
/// </summary>


public class BallOrganizer
{
    public static string CheckPossibility(int[][] containers)
    {
        int n = containers.Length;
        long[] containerCap = new long[n];
        long[] typeCount = new long[n];

        // O(n^2): Compute row and column sums
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                containerCap[i] += containers[i][j];
                typeCount[j] += containers[i][j];
            }

        Array.Sort(containerCap);
        Array.Sort(typeCount);

        return containerCap.SequenceEqual(typeCount) ? "Possible" : "Impossible";
    }

}


/// <summary>
/// finds the next lexicographically greater permutation of the given word.
/// if no greater word is possible, returns "no answer".
/// </summary>


public class BiggerIsGreaterSolver
{
    public static string BiggerIsGreater(string w)
    {
        char[] chars = w.ToCharArray();
        int i = chars.Length - 2;

        // Step 1: Find pivot
        while (i >= 0 && chars[i] >= chars[i + 1])
            i--;

        if (i == -1)
            return "no answer";

        // Step 2: Find successor
        int j = chars.Length - 1;
        while (chars[j] <= chars[i])
            j--;

        // Step 3: Swap and Step 4: Reverse
        Swap(chars, i, j);
        Array.Reverse(chars, i + 1, chars.Length - i - 1);

        return new string(chars);

    }

    private static void Swap(char[] arr, int i, int j)
    {
        char tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }
}


/// <summary>
/// find all words from the list that can be formed by sequentially adjacent letters on the board. 
/// a letter cell is not reused.
/// </summary>


public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new();
    public string Word = null;
}


public class WordSearch
{
    private TrieNode BuildTrie(string[] words)
    {
        TrieNode root = new();
        foreach (var word in words)
        {
            var node = root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                    node.Children[ch] = new TrieNode();
                node = node.Children[ch];
            }
            node.Word = word;
        }
        return root;
    }

    public IList<string> FindWords(char[][] board, string[] words)
    {
        var result = new List<string>();
        TrieNode root = BuildTrie(words);

        int rows = board.Length;
        int cols = board[0].Length;

        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                DFS(board, r, c, root, result);

        return result;
    }

    private void DFS(char[][] board, int r, int c, TrieNode node, List<string> result)
    {
        char ch = board[r][c];

        if (!node.Children.ContainsKey(ch)) return;

        TrieNode nextNode = node.Children[ch];
        if (nextNode.Word != null)
        {
            result.Add(nextNode.Word);
            nextNode.Word = null; // prevent duplicates
        }

        board[r][c] = '#'; // mark visited

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < 4; i++)
        {
            int nr = r + dx[i], nc = c + dy[i];
            if (nr >= 0 && nr < board.Length && nc >= 0 && nc < board[0].Length && board[nr][nc] != '#')
            {
                DFS(board, nr, nc, nextNode, result);
            }
        }

        board[r][c] = ch; // unmark
    }
}


/// <summary>
/// this program implements an LRU (Least Recently Used) cache that stores a fixed number of key–value pairs.
/// keep track of the most recently accessed items so that when the cache is full, it removes the least recently used item first
/// </summary>

public class LRUCache
{
    private readonly int _cap;
    // most recent at head
    private readonly LinkedList<(int key, int val)> _list = new();
    // key -> node
    private readonly Dictionary<int, LinkedListNode<(int key, int val)>> _pos = new();

    public LRUCache(int capacity) => _cap = capacity;

    public int Get(int key)
    {
        if (!_pos.TryGetValue(key, out var node)) return -1;
        _list.Remove(node);
        _list.AddFirst(node);
        return node.Value.val;
    }

    public void Put(int key, int value)
    {
        if (_pos.TryGetValue(key, out var node))
        {
            node.Value = (key, value);
            _list.Remove(node);
            _list.AddFirst(node);
            return;
        }

        if (_list.Count == _cap)
        {
            var lru = _list.Last!;
            _pos.Remove(lru.Value.key);
            _list.RemoveLast();
        }

        var newNode = new LinkedListNode<(int key, int val)>((key, value));
        _list.AddFirst(newNode);
        _pos[key] = newNode;
    }
}


public static class LruTests
{
    public static void Run()
    {
        var lru = new LRUCache(2);
        lru.Put(1, 1);
        lru.Put(2, 2);
        Debug.Assert(lru.Get(1) == 1); // use 1
        lru.Put(3, 3);                 // evicts 2
        Debug.Assert(lru.Get(2) == -1);
        lru.Put(4, 4);                 // evicts 1
        Debug.Assert(lru.Get(1) == -1);
        Debug.Assert(lru.Get(3) == 3);
        Debug.Assert(lru.Get(4) == 4);
        Console.WriteLine("C# LRU tests passed");
    }
}
/// <summary>
/// a thread-safe queue with a fixed capacity
/// that supports multiple producers and consumers.
/// </summary>

public class BoundedBlockingQueue<T>
{
    private readonly int _cap;
    private readonly Queue<T> _q = new();
    private readonly SemaphoreSlim _slots; // counts free slots
    private readonly SemaphoreSlim _items; // counts available items
    private readonly object _lock = new();

    public BoundedBlockingQueue(int capacity)
    {
        if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        _cap = capacity;
        _slots = new SemaphoreSlim(capacity, capacity);
        _items = new SemaphoreSlim(0, capacity);
    }

    // Synchronous
    public void Enqueue(T item)
    {
        _slots.Wait(); // wait for a free slot
        lock (_lock) _q.Enqueue(item);
        _items.Release(); // signal item available
    }

    public T Dequeue()
    {
        _items.Wait(); // wait for an item
        T item;
        lock (_lock) item = _q.Dequeue();
        _slots.Release(); // signal a free slot
        return item;
    }

    // Async-friendly versions (optional but great for real services)
    public async Task EnqueueAsync(T item, CancellationToken ct = default)
    {
        await _slots.WaitAsync(ct).ConfigureAwait(false);
        lock (_lock) _q.Enqueue(item);
        _items.Release();
    }

    public async Task<T> DequeueAsync(CancellationToken ct = default)
    {
        await _items.WaitAsync(ct).ConfigureAwait(false);
        T item;
        lock (_lock) item = _q.Dequeue();
        _slots.Release();
        return item;
    }
}



public class Graph
{
    private readonly int _n;
    private readonly bool _directed;
    private readonly List<(int to, int w)>[] _g;

    public Graph(int n, bool directed = true)
    {
        _n = n;
        _directed = directed;
        _g = new List<(int to, int w)>[n];
        for (int i = 0; i < n; i++) _g[i] = new List<(int, int)>();
    }

    public void AddEdge(int u, int v, int w)
    {
        _g[u].Add((v, w));
        if (!_directed) _g[v].Add((u, w));
    }

    // Returns (dist, parent). dist[i] = long.MaxValue/4 if unreachable.
    public (long[] dist, int[] parent) Dijkstra(int source)
    {
        long INF = long.MaxValue / 4;
        var dist = new long[_n];
        var parent = new int[_n];
        Array.Fill(dist, INF);
        Array.Fill(parent, -1);

        var pq = new PriorityQueue<int, long>(); // node with priority=distance

        dist[source] = 0;
        pq.Enqueue(source, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int u, out long d);
            if (d != dist[u]) continue; // stale

            foreach (var (to, w) in _g[u])
            {
                long nd = d + w;
                if (nd < dist[to])
                {
                    dist[to] = nd;
                    parent[to] = u;
                    pq.Enqueue(to, nd);
                }
            }
        }
        return (dist, parent);
    }

    public static IList<int> BuildPath(int target, int[] parent)
    {
        var path = new List<int>();
        for (int v = target; v != -1; v = parent[v]) path.Add(v);
        path.Reverse();
        return path;
    }
}



public class ReadWriteLock
{
    private readonly object _lock = new();
    private int _readersActive = 0;
    private int _writersWaiting = 0;
    private bool _writerActive = false;

    public void LockRead()
    {
        lock (_lock)
        {
            while (_writerActive || _writersWaiting > 0)
                Monitor.Wait(_lock);
            _readersActive++;
        }
    }

    public void UnlockRead()
    {
        lock (_lock)
        {
            _readersActive--;
            if (_readersActive == 0)
                Monitor.Pulse(_lock); // wake writer
        }
    }

    public void LockWrite()
    {
        lock (_lock)
        {
            _writersWaiting++;
            try
            {
                while (_writerActive || _readersActive > 0)
                    Monitor.Wait(_lock);
                _writerActive = true;
            }
            finally
            {
                _writersWaiting--;
            }
        }
    }

    public void UnlockWrite()
    {
        lock (_lock)
        {
            _writerActive = false;
            // Prefer writers first to avoid writer starvation
            if (_writersWaiting > 0) Monitor.Pulse(_lock);
            else Monitor.PulseAll(_lock); // wake readers
        }
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
    public void TestBallOrganizer()
    {
        int q = int.Parse(Console.ReadLine());

        for (int t = 0; t < q; t++)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] containers = new int[n][];

            for (int i = 0; i < n; i++)
                containers[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(BallOrganizer.CheckPossibility(containers));
        }

    }
    public void TestBiggerIsGreater()
    {
        int T = int.Parse(Console.ReadLine());
        for (int t = 0; t < T; t++)
        {
            string w = Console.ReadLine();
            Console.WriteLine(BiggerIsGreaterSolver.BiggerIsGreater(w));
        }
    }
    public void TestLambdaSort()
    {
        var people = new List<Person>
        {
            new Person { Name = "Alice", Age = 30 },
            new Person { Name = "Bob", Age = 25 },
            new Person { Name = "Charlie", Age = 30 },
            new Person { Name = "David", Age = 25 }
        };

        LambdaSort.SortPeople(people);
    }

    public void TestLINQFilter()
    {
        var employees = new List<Employee>
        {
            new Employee { Name = "Alice", Department = "Engineering", Salary = 120000 },
            new Employee { Name = "Bob", Department = "HR", Salary = 95000 },
            new Employee { Name = "Charlie", Department = "Engineering", Salary = 99000 },
            new Employee { Name = "David", Department = "Engineering", Salary = 110000 }
        };

        var result = LINQFilter.GetHighPaidEngineers(employees);
        Console.WriteLine(string.Join(", ", result));  // Output: Alice, David
    }

    public async Task BoundedBlocking()
    {
        var q = new BoundedBlockingQueue<int>(3);

        var producers = new[]
        {
            Task.Run(async () => { for (int i=0;i<5;i++) await q.EnqueueAsync(100+i); }),
            Task.Run(async () => { for (int i=0;i<5;i++) await q.EnqueueAsync(200+i); }),
        };

        var consumers = new[]
        {
            Task.Run(async () => { for (int i=0;i<5;i++) Console.WriteLine($"C1 got {await q.DequeueAsync()}"); }),
            Task.Run(async () => { for (int i=0;i<5;i++) Console.WriteLine($"C2 got {await q.DequeueAsync()}"); }),
        };

        await Task.WhenAll(producers);
        await Task.WhenAll(consumers);
    }
    public void DijkstraDemo()
    {
        var g = new Graph(5, directed: true);
        g.AddEdge(0, 1, 2);
        g.AddEdge(0, 2, 5);
        g.AddEdge(1, 2, 1);
        g.AddEdge(1, 3, 2);
        g.AddEdge(2, 3, 1);
        g.AddEdge(3, 4, 3);
    
        var (dist, parent) = g.Dijkstra(0);
        Console.WriteLine($"dist[4] = {dist[4]}"); // 7
        Console.WriteLine("path: " + string.Join(" ", Graph.BuildPath(4, parent))); // 0 1 2 3 4
    }

    public void ReadWriteLockDemo()
    {
        var rw = new ReadWriteLock();
        int shared = 0;

        Task[] readers = new Task[3];
        for (int i = 0; i < readers.Length; i++)
        {
            int id = i + 1;
            readers[i] = Task.Run(() =>
            {
                for (int k = 0; k < 5; k++)
                {
                    rw.LockRead();
                    Console.WriteLine($"R{id} read {shared}");
                    rw.UnlockRead();
                    Thread.Sleep(10);
                }
            });
        }

        Task writer1 = Task.Run(() =>
        {
            for (int k = 0; k < 5; k++)
            {
                rw.LockWrite();
                shared += 1;
                Console.WriteLine($"W1 wrote {shared}");
                rw.UnlockWrite();
                Thread.Sleep(25);
            }
        });

        Task writer2 = Task.Run(() =>
        {
            for (int k = 0; k < 5; k++)
            {
                rw.LockWrite();
                shared += 1;
                Console.WriteLine($"W2 wrote {shared}");
                rw.UnlockWrite();
                Thread.Sleep(25);
            }
        });

        Task.WaitAll(readers);
        Task.WaitAll(writer1, writer2);
    }

}