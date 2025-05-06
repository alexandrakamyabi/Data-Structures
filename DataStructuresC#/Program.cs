using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

class CaesarCipherProgram
{

    static string CaesarCipher(string s, int k)
    {
        k = k % 26;
        char[] resut = new char[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];


            if (char.IsLower(c))
            {
                resut[i] = (char)((c - 'a' + k) % 26 + 'a');

            }
            else if (char.IsUpper(c))
            {
                resut[i] = (char)((c - 'A' + k) % 26 + 'A');
            }

            else
            {
                resut[i] = c;
            }

        }

        return new string(resut);
    }

}

public class TreeNode
{


    public char value;

    public TreeNode Left;

    public TreeNode Right;

    public TreeNode(char value)
    {

        value = value;

        Left = Right = null;
    }
}
public class Solution
{

    public static TreeNode FindLCA(TreeNode root, TreeNode p, TreeNode q)
    {

        if (root == null || root == p || root == q)
            return root;

        TreeNode left = FindLCA(root.Left, p, q);

        TreeNode right = FindLCA(root.Right, p, q);


        if (left != null && right != null)
            return root;

        return left ?? right;
    }
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

            if (windowSize % 2 == 0)


            {

                double median = (window[mid - 1] + window[mid]) / 2.0;

                medians.Add(median);



            }

            else
            {

                medians.Add(window[mid]);

            }


        }
        return medians;
    }

    public void MergeSortedArrays(int[] A, int m, int[] b, int n)
    {

        int i = m - 1;

        int j = n - 1;

        int k = m + n - 1;


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