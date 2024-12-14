using System.Text.RegularExpressions;

namespace aoc_2024.Day3
{
    public class Solution
    {
        public static void Solve(string[] input)
        {
            int sum = 0;

            string pattern = @"mul\(\d+,\d+\)";
            string doPattern = @"do\(\)";
            string dontPattern = @"don't\(\)";

            Regex regex = new(pattern);
            Regex doRegex = new(doPattern);
            Regex dontRegex = new(dontPattern);

            string line = string.Join("", input);

            MatchCollection matches = regex.Matches(line);
            MatchCollection doMatches = doRegex.Matches(line);
            MatchCollection dontMatches = dontRegex.Matches(line);

            int[] doIndexes = doMatches.Cast<Match>().Select(m => m.Index).Prepend(0).ToArray();
            int[] dontIndexes = dontMatches.Cast<Match>().Select(m => m.Index).ToArray();

            foreach (Match match in matches)
            {
                if (DoesCount(match.Index, doIndexes, dontIndexes))
                {
                    string[] numbers = match.Value.Trim('m', 'u', 'l', '(', ')').Split(',');
                    int a = int.Parse(numbers[0]);
                    int b = int.Parse(numbers[1]);

                    sum += a * b;
                }
            }

            Console.WriteLine(sum);
        }

        static bool DoesCount(int index, int[] doMatches, int[] dontMatches)
        {
            int? nextSmallerDo = FindNextSmallerNumber(doMatches, index);
            int? nextSmallerDont = FindNextSmallerNumber(dontMatches, index);

            return nextSmallerDont == null || nextSmallerDo > nextSmallerDont;
        }

        static int? FindNextSmallerNumber(int[] array, int target)
        {
            // Filter numbers smaller than the target and find the maximum
            int? nextSmaller = null;

            foreach (int num in array)
            {
                if (num < target)
                {
                    if (nextSmaller == null || num > nextSmaller)
                    {
                        nextSmaller = num;
                    }
                }
            }

            return nextSmaller;
        }
    }
}
