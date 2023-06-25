using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2022.Common;

public class ElfPointEqualityComparer : IEqualityComparer<ElfPoint>
{
    public bool Equals(ElfPoint? x, ElfPoint? y)
    {
        if (x is null || y is null)
        {
            return false;
        }

        return x.X == y.X && x.Y == y.Y;
    }

    public int GetHashCode([DisallowNull] ElfPoint obj)
    {
        return obj.X.GetHashCode() ^ obj.Y.GetHashCode();
    }
}
