using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'luckBalance' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. 2D_INTEGER_ARRAY contests
     */

    public static int luckBalance(int n, int k, List<List<int>> contests)
    {
        int[] maxarr = new int[k];
        for (int i = 0; i < k; i++)
        {
            maxarr[i] = 0;
        }
        int luck = 0;
        for (int i = 0; i < n; i++)
        {
            if (contests[i][1] == 0)
            {
                luck = luck + contests[i][0];
            }
            else
            {
                bool foundmax = false;
                for (int j = 0; j < k; j++)
                {
                    if (contests[i][0] > maxarr[j])
                    {
                        luck = luck - maxarr[k - 1];
                        for (int l = k - 2; l >= j; l--)
                        {
                            maxarr[l + 1] = maxarr[l];
                        }
                        maxarr[j] = contests[i][0];
                        foundmax = true;
                        break;
                    }
                }
                if (foundmax == false)
                {
                    luck = luck - contests[i][0];
                }
            }
        }
        for (int i = 0; i < k; i++)
        {
            luck = luck + maxarr[i];
        }
        return luck;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> contests = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            contests.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(contestsTemp => Convert.ToInt32(contestsTemp)).ToList());
        }

        int result = Result.luckBalance(n, k, contests);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
