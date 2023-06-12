namespace AdventOfCode2022.Day08
{
    public class InputParser
    {
        public static List<List<int>> Parse(string[] input)
        {
            return input.Select(line => line.Select(c => int.Parse(c.ToString())).ToList()).ToList();
        }
    }
}