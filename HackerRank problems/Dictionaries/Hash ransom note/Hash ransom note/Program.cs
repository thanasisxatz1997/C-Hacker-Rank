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
     * Complete the 'checkMagazine' function below.
     *
     * The function accepts following parameters:
     *  1. STRING_ARRAY magazine
     *  2. STRING_ARRAY note
     */

    public static void checkMagazine(int m, int n, List<string> magazine, List<string> note)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        for (int i = 0; i < m; i++)
        {
            if (!dict.ContainsKey(magazine[i]))
            {
                dict.Add(magazine[i], 1);
            }
            else
            {
                int num = dict[magazine[i]];
                dict[magazine[i]] = num + 1;
            }
        }
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (dict.ContainsKey(note[i]))
            {
                count++;
                dict[note[i]] = dict[note[i]] - 1;
                if (dict[note[i]] == 0)
                {
                    dict.Remove(note[i]);
                }
            }
        }
        if (count >= n)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        List<string> magazine = Console.ReadLine().TrimEnd().Split(' ').ToList();

        List<string> note = Console.ReadLine().TrimEnd().Split(' ').ToList();

        Result.checkMagazine(m, n, magazine, note);
    }
}
