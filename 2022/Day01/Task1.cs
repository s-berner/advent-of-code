namespace AdventOfCode2022.Day01
{
    public class Task1
    {
        public void Solve(string[] input)
        {
            Console.WriteLine("Day 01, Task 1 solution:");
            List<int> calorieSums = InputParser.Parse(input);
            int maxCalorieSum = calorieSums.Max();

            Console.WriteLine($"The highest calorie sum is {maxCalorieSum}.");
        }
    }
}