namespace AdventOfCode2022.Day10;

public record Cycle
{
    public int Tick { get; init; }
    public int X { get; init; }

    public override string ToString()
    {
        return $"Tick: { Tick }, X: { X } with SignalStrength of: { GetSignalStrength() }";
    }

    public int GetSignalStrength()
    {
        return X * Tick;
    }
}