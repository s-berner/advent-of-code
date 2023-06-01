namespace AdventOfCode2022.Day04
{
    public class InputParser
    {
        public static List<List<(int, int)>> Parse(string[] input)
        {
            return input
                .Select(line => line.Split(',').Select(pair => (int.Parse(pair.Split('-')[0]), int.Parse(pair.Split('-')[1]))).ToList())
                .ToList();
        }
    }
}