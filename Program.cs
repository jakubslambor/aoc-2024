class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please specify a day to run (e.g., 'dotnet run -- 1').");
            return;
        }

        if (!int.TryParse(args[0], out int day) || day < 1)
        {
            Console.WriteLine("Invalid day specified. Please provide a positive integer.");
            return;
        }

        string inputFileName = $"Day{day}/input.txt";
        if (!File.Exists(inputFileName))
        {
            Console.WriteLine($"Input file for Day {day} not found at '{inputFileName}'.");
            return;
        }

        string[] input = File.ReadAllLines(inputFileName);
        switch (day)
        {
            case 1:
                aoc_2024.Day1.Solution.Solve(input);
                break;
            case 2:
                aoc_2024.Day2.Solution.Solve(input);
                break;
            case 3:
                aoc_2024.Day3.Solution.Solve(input);
                break;
            // Add more cases for additional days
            default:
                Console.WriteLine($"Solution for Day {day} is not implemented yet.");
                break;
        }
    }
}
