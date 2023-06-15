using System.Text;

namespace AdventOfCode2022.Day10;

public class Task2 : IAdventOfCodeTask
{
    private const int CRTWidth = 40;
    private const int CRTHeight = 6;

    public void Solve(string[] input)
    {
        Console.WriteLine("Day 10, Task 2 solution:\n");

        var commands = InputParser.Parse(input);

        var cycles = SignalProcessor.ProcessCommands(commands);
        var screen = SignalProcessor.DrawCRTScreen(cycles, CRTWidth, CRTHeight);

        PrintResult(screen);
    }

    private static void PrintResult(char[,] screen)
    {
        StringBuilder sb = new();

        sb.AppendLine("The screen looks like this:");

        var height = screen.GetLength(0);
        var width = screen.GetLength(1);

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                sb.Append(screen[i, j]);
            }

            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString());
    }
}