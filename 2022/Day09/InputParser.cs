namespace AdventOfCode2022.Day09;

public class InputParser
{
    public static List<ElfBridgeMove> Parse(string[] input)
    {
        List<ElfBridgeMove> moves = new();

        foreach (string line in input)
        {
            moves.Add(ElfBridgeMove.ParseMoveLine(line));
        }

        return moves;
    }
}
