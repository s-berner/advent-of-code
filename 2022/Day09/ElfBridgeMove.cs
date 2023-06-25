using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day09;

public class ElfBridgeMove
{
    public Direction Direction { get; init; }
    public int Steps { get; init; }

    public ElfBridgeMove(int steps, Direction direction)
    {
        Steps = steps;
        Direction = direction;
    }

    public static ElfBridgeMove ParseMoveLine(string input)
    {
        var split = input.Split(' ');
        var direction = split[0];
        var steps = int.Parse(split[1]);

        return new ElfBridgeMove(steps, direction switch
        {
            "U" => Direction.Up,
            "R" => Direction.Right,
            "D" => Direction.Down,
            "L" => Direction.Left,
            _ => Direction.Unknown
        });
    }
}
