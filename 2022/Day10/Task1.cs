namespace AdventOfCode2022.Day10;

public class Task1 : IAdventOfCodeTask
{
    public void Solve(string[] input)
    {
        Console.WriteLine("Day 10, Task 1 solution:");

        var commands = InputParser.Parse(input);

        var cycles = SignalProcessor.ProcessCommands(commands);

        int sum = cycles
            .Skip(19)
            .Where((cycle, index) => index % 40 == 0)
            .Sum(cycle => cycle.GetSignalStrength());

        Console.WriteLine($"Sum of the interesting signal strengths { sum }");
    }
}
