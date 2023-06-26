using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day11;

public partial class InputParser
{
    public static Queue<Monkey> Parse(string[] input, bool task2 = false)
    {
        var monkeys = new Queue<Monkey>();
        Monkey currentMonkey = null!;

        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (line.StartsWith("Monkey"))
            {
                currentMonkey = new Monkey(int.Parse(
                    GenerateDigitsRegexPattern().Match(line).Value));
                monkeys.Enqueue(currentMonkey);
            }
            else if (line.StartsWith("  Starting items:"))
            {
                currentMonkey?.ParseItemLine(line);
            }
            else if (line.StartsWith("  Operation:"))
            {
                currentMonkey?.ParseOperationLine(line, task2);
            }
            else if (line.StartsWith("  Test:"))
            {
                currentMonkey?.ParseTestLine(line);
            }
            else if (line.StartsWith("    If"))
            {
                currentMonkey?.ParseIfLine(line);
            }
        }

        return monkeys;
    }

    [GeneratedRegex("\\d+")]
    private static partial Regex GenerateDigitsRegexPattern();
}