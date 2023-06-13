namespace AdventOfCode2022.Day10;

public class CPUCommand
{
    public CommandType Type { get; set; } = CommandType.Default;
    public int? Value { get; set; }
}
