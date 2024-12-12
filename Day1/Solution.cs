namespace aoc_2024.Day1
{
    public class Solution
    {
        public static void Solve(string[] input)
        {
            int total = 0;

            List<int> firstParts = [];
            List<int> secondParts = [];

            foreach (var line in input)
            {
                // Split the input by whitespace
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                firstParts.Add(int.Parse(parts[0]));
                secondParts.Add(int.Parse(parts[1]));
            }

            foreach (var (part, index) in firstParts.Select((value, i) => (value, i)))
            {
                int sum = 0;

                for (int i = 0; i < secondParts.Count; i++)
                {
                    if (secondParts[i] == part)
                    {
                        sum++;
                    }
                }

                total += sum * part;
            }

            Console.WriteLine(total);
        }
    }
}
