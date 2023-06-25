using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day09;

public class Task2 : IAdventOfCodeTask
{
    private readonly LinkedList<ElfPoint> ElfBridgeRope = new();
    private HashSet<ElfPoint> RopeTailVisited { get; set; } = new (
        new ElfPointEqualityComparer());



    public Task2()
    {
        for (int i = 0; i < 10; i++)
        {
            ElfBridgeRope.AddLast(new ElfPoint(0, 0));
        }

        RopeTailVisited.Add(ElfBridgeRope.First!.Value);
    }

    public void Solve(string[] input)
    {
        Console.WriteLine("Day 9, Task 2 is temporarily shelved.");
        /* Console.WriteLine("Day 9, Task 2 solution:");

        var moves = InputParser.Parse(input);
        moves.ForEach(ProcessMove);

       var result = RopeTailVisited.Count;

       Console.WriteLine($"The Rope Visited { result } Point/s at least once"); */
    }

    private void ProcessMove(ElfBridgeMove move)
    {
        for (int i = 0; i < move.Steps; i++)
        {
            var current = ElfBridgeRope.First;

            if (current == null)
            {
                return;
            }

            MoveElfPoint(current.Value, move.Direction);

            current = current?.Next;
            while(current != null)
            {
                var currentPosition = current.Value;
                var previousPosition = current.Previous!.Value;

                if (!currentPosition.IsAdjacentTo(previousPosition) &&
                    currentPosition != previousPosition)
                {
                    MoveRopeBody(currentPosition, previousPosition);
                }

                if (current.Next == null)
                {
                    RopeTailVisited.Add(currentPosition);
                }

                current = current?.Next;
            }
        }
    }

    private static ElfPoint MoveElfPoint(ElfPoint point, Direction dir)
    {
        return dir switch
        {
            Direction.Left => new ElfPoint(point.X - 1, point.Y),
            Direction.Right => new ElfPoint(point.X + 1, point.Y),
            Direction.Up => new ElfPoint(point.X, point.Y + 1),
            Direction.Down => new ElfPoint(point.X, point.Y - 1),
            Direction.UpLeft => new ElfPoint(point.X - 1, point.Y + 1),
            Direction.UpRight => new ElfPoint(point.X + 1, point.Y + 1),
            Direction.DownLeft => new ElfPoint(point.X - 1, point.Y - 1),
            Direction.DownRight => new ElfPoint(point.X + 1, point.Y - 1),
            _ => point
        };
    }

    private static void MoveRopeBody(ElfPoint point, ElfPoint previous)
    {
        var direction = GetDirectionToPrevious(point, previous);

        MoveElfPoint(point, direction);
    }

    private static Direction GetDirectionToPrevious(ElfPoint point, ElfPoint previous)
    {
        if (previous.X == point.X)
        {
            return previous.Y > point.Y
                ? Direction.Up
                : Direction.Down;
        }

        if (previous.Y == point.Y)
        {
            return previous.X > point.X
                ? Direction.Right
                : Direction.Left;
        }

        if (previous.X > point.X)
        {
            return previous.Y > point.Y
                ? Direction.UpRight
                : Direction.DownRight;
        }

        if (previous.X < point.X)
        {
            return previous.Y > point.Y
                ? Direction.UpLeft
                : Direction.DownLeft;
        }

        return Direction.Unknown;
    }
}
