namespace AdventOfCode2022.Day03
{
    public class InputParser
    {
        public static List<List<string>> ParseWithSplitBackpacks(string[] input)
        {
            return input
                .Select(line => new List<string> { line.Substring(0, line.Length / 2), line.Substring(line.Length / 2) })
                .ToList();
        }

        public static List<string> Parse(string[] input)
        {
            return input.ToList();
        }
    }
}