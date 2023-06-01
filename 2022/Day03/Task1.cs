namespace AdventOfCode2022.Day03
{
    public class Task1 : IAdventOfCodeTask
    {
        private Dictionary<char, int> CharToValueMap = new Dictionary<char, int>();

        public Task1()
        {
            CharToValueMap = Enumerable.Range('a', 26)
                .Concat(Enumerable.Range('A', 26))
                .Select((c, i) => new { Char = (char)c, Value = i + 1 })
                .ToDictionary(x => x.Char, x => x.Value);
        }

        public void Solve(string[] input)
        {
            var backpacks = InputParser.ParseWithSplitBackpacks(input);

            List<char> commonItems = backpacks
                .SelectMany(line => line[0].Intersect(line[1]))
                .ToList();

            var result = commonItems.Sum(c => CharToValueMap[c]);

            Console.WriteLine($"Item Priority sum: {result}");
        }
    }
}