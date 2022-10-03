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
     * Complete the 'minimumBribes' function below.
     *
     * The function accepts INTEGER_ARRAY q as parameter.
     */

    public static void minimumBribes(int n, List<int> q)
    {
        bool chaotic = false;
        int pos = 0;
        int bribes = 0;

        int end = n;
        while (end > 0)
        {
            int max = q[0];
            for (int i = 0; i < end; i++)
            {
                if (q[i] > max)
                {
                    max = q[i];
                }
            }
            for (int j = 0; j < end; j++)
            {
                if (q[j] == max)
                {
                    pos = j;
                }
            }
            int hops = 0;

            while ((pos < end - 1) && (q[pos] > q[pos + 1]))
            {

                int temp = q[pos];
                q[pos] = q[pos + 1];
                q[pos + 1] = temp;
                pos++;
                hops++;
                if (hops > 2)
                {
                    chaotic = true;
                    break;
                }
            }
            if (chaotic == true)
            {
                break;
            }
            else
            {
                bribes = bribes + hops;
            }
            end = end - 1;
        }

        if (chaotic == true)
        {
            Console.WriteLine("Too chaotic");
        }
        else
        {
            Console.WriteLine(bribes);

        }
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

            Result.minimumBribes(n, q);
        }
    }
}
