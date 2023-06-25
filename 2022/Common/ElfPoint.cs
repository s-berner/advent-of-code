namespace AdventOfCode2022.Common;

public class ElfPoint : ICloneable
{
    public int X { get; set; }
    public int Y { get; set; }

    public ElfPoint(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int DistanceTo(ElfPoint other)
    {
        return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    }

    public bool IsAdjacentTo(ElfPoint other)
    {
        int[,] adjacentOffset = { {0, 1}, {1, 0}, {0, -1}, {-1, 0}, {-1, 1}, {1, -1}, {1, 1}, {-1, -1} };

        for (int i = 0; i < adjacentOffset.GetLength(0); i++)
        {
            if (X + adjacentOffset[i, 0] == other.X && Y + adjacentOffset[i, 1] == other.Y)
            {
                return true;
            }
        }

        return false;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}