namespace AdventOfCode2022.Day10;

public class InputParser
{
    public static Queue<CPUCommand> Parse(string[] input)
    {
        Queue<CPUCommand> commands = new();

        foreach (string line in input)
        {
            CPUCommand parsedLine = ParseLine(line);
            commands.Enqueue(parsedLine);
        }

        return commands;
    }

    private static CPUCommand ParseLine(string line)
    {
        var split = line.Split(' ');

        return new CPUCommand
        {
            Type = ParseInstruction(split[0]),
            Value = split.Length > 1 ? int.Parse(split[1]) : null
        };
    }

    private static CommandType ParseInstruction(string input)
    {
        return input switch
        {
            "noop" => CommandType.Noop,
            "addx" => CommandType.AddX,
            _ => CommandType.Default
        };
    }
}
