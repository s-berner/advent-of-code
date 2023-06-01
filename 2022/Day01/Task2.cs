namespace AdventOfCode2022.Day01
{
    public class Task2 : IAdventOfCodeTask
    {
        public void Solve(string[] input)
        {
            Console.WriteLine("Day 01, Task 2 solution:");

            List<int> calorieSums = InputParser.Parse(input)
                .OrderByDescending(sum => sum)
                .ToList();

            int topThreeCaloriesSum = 0;
            for (int i = 0; i < 3; i++)
            {
                topThreeCaloriesSum += calorieSums[i];
            }

            Console.WriteLine($"The top three elves carry {topThreeCaloriesSum} calories.");
        }
    }
}