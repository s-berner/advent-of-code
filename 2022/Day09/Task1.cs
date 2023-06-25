using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day09;

public class Task1 : IAdventOfCodeTask
{
    private ElfPoint HeadPosition { get; set; } = new(0, 0);
    private ElfPoint TailPosition { get; set; } = new(0, 0);
    private HashSet<ElfPoint> TailVisitedTiles { get; set; } = new (
        new ElfPointEqualityComparer());

    public Task1()
    {
        TailVisitedTiles.Add((TailPosition.Clone() as ElfPoint)!);
    }

    public void Solve(string[] input)
    {
        Console.WriteLine("Day 9, Task 1 solution:");

        var moves = InputParser.Parse(input);

        ProcessMoves(moves);

        Console.WriteLine($"The number of tiles the tail visited at least once is: { TailVisitedTiles.Count }");
    }

    private void ProcessMoves(List<ElfBridgeMove> moves)
    {
        foreach (var move in moves)
        {
            ProcessMove(move);
        }
    }

    private void ProcessMove(ElfBridgeMove move)
    {
        for (int i = 0; i < move.Steps; i++)
        {
            MoveHead(move.Direction);

            if (!TailPosition.IsAdjacentTo(HeadPosition) &&
                !(TailPosition.X == HeadPosition.X &&
                TailPosition.Y == HeadPosition.Y))
            {
                PullTail();
            }
        }
    }

    private void MoveHead(Direction dir)
    {
        MoveElfPoint(HeadPosition, dir);
    }

    private static void MoveElfPoint(ElfPoint point, Direction dir)
    {
        switch (dir)
        {
            case Direction.Left:
                point.X--;
                break;
            case Direction.Right:
                point.X++;
                break;
            case Direction.Up:
                point.Y++;
                break;
            case Direction.Down:
                point.Y--;
                break;
            case Direction.UpLeft:
                point.X--;
                point.Y++;
                break;
            case Direction.UpRight:
                point.X++;
                point.Y++;
                break;
            case Direction.DownLeft:
                point.X--;
                point.Y--;
                break;
            case Direction.DownRight:
                point.X++;
                point.Y--;
                break;
        }
    }

    private void PullTail()
    {
        var direction = GetDirectionToHead();

        MoveElfPoint(TailPosition, direction);

        TailVisitedTiles.Add((TailPosition.Clone() as ElfPoint)!);
    }

    private Direction GetDirectionToHead()
    {
        if (HeadPosition.X == TailPosition.X)
        {
            return HeadPosition.Y > TailPosition.Y ? Direction.Up : Direction.Down;
        }

        if (HeadPosition.Y == TailPosition.Y)
        {
            return HeadPosition.X > TailPosition.X ? Direction.Right : Direction.Left;
        }

        if (HeadPosition.X > TailPosition.X)
        {
            return HeadPosition.Y > TailPosition.Y ? Direction.UpRight : Direction.DownRight;
        }

        if (HeadPosition.X < TailPosition.X)
        {
            return HeadPosition.Y > TailPosition.Y ? Direction.UpLeft: Direction.DownLeft;
        }

        return Direction.Unknown;
    }
}
