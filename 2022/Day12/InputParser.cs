namespace AdventOfCode2022.Day12;

public class InputParser
{
    public static ElfHeightMap[,] Parse(string[] input)
    {
        var height = input.Length;
        var width = input[0].Length;

        ElfHeightMap[,] map = new ElfHeightMap[height, width];

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j  < input[0].Length; j ++)
            {
                map[i, j] = ParseChar(input[i][j]);
            }
        }

        return map;
    }

    private static ElfHeightMap ParseChar(char c)
    {
        return c switch
        {
            'S' => ElfHeightMap.Start,
            'E' => ElfHeightMap.End,
            _ => (ElfHeightMap)(c - 'a'),
        };
    }
}
