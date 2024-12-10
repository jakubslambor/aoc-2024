using System;
using System.Collections.Generic;

namespace Day1
{
    public class Solution
    {
        public static void Solve(string[] input)
        {
            int total = 0;

            List<int> firstParts = new List<int>();
            List<int> secondParts = new List<int>();

            foreach (var line in input)
            {
                // Split the input by whitespace
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                firstParts.Add(int.Parse(parts[0]));
                secondParts.Add(int.Parse(parts[1]));
            }

            firstParts.Sort();
            secondParts.Sort();

            foreach (var (part, index) in firstParts.Select((value, i) => (value, i)))
            {
                int secondPart = secondParts[index];
                total += Math.Abs(part - secondPart);
            }

            Console.WriteLine(total);
        }
    }
}
