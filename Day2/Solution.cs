namespace aoc_2024.Day2
{
    public class Solution
    {
        public static void Solve(string[] input)
        {
            int total = 0;

            foreach (var line in input)
            {
                string[] parts = line.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);
                List<int> numbers = [.. Array.ConvertAll(parts, int.Parse)];

                // Calculate the number of safe reports
                bool isValid = IsValid(numbers);

                if (isValid)
                {
                    total++;
                }
            }

            Console.WriteLine(total);
        }

        static bool IsValid(List<int> levels)
        {
            bool isIncreasing = levels[1] > levels[0];
            bool skippedALevel = false;

            for (int i = 1; i < levels.Count; i++)
            {
                int diff = levels[i] - levels[i - 1];

                // Any two adjacent levels differ by at least one and at most three.
                if (Math.Abs(diff) > 3 || diff == 0)
                {
                    if (skippedALevel)
                    {
                        return false;
                    }

                    skippedALevel = true;
                    continue;
                }

                // The levels are either all increasing or all decreasing.
                if ((isIncreasing && diff < 0) || (!isIncreasing && diff > 0))
                {
                    if (skippedALevel)
                    {
                        return false;
                    }

                    skippedALevel = true;
                }
            }

            return true;
        }
    }
}
