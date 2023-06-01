namespace AdventOfCode2022.Day03
{
    public class Task2 : IAdventOfCodeTask
    {
        private Dictionary<char, int> CharToValueMap = new Dictionary<char, int>();

        public Task2()
        {
            CharToValueMap = Enumerable.Range('a', 26)
                .Concat(Enumerable.Range('A', 26))
                .Select((c, i) => new { Char = (char)c, Value = i + 1 })
                .ToDictionary(x => x.Char, x => x.Value);
        }

        public void Solve(string[] input)
        {
            var backpacks = InputParser.Parse(input);
            var groupedBackpacks = SplitBackpacksIntoGroupsOfThree(backpacks);

            List<char> commonItems = groupedBackpacks
                .Select(GetGroupCommonItem)
                .ToList();

            var result = commonItems.Sum(c => CharToValueMap[c]);

            Console.WriteLine($"Item Priority sum: {result}");
        }

        private char GetGroupCommonItem(List<string> group)
        {
            var smallestBackpack = group.OrderBy(s => s.Length).First();
            return smallestBackpack.FirstOrDefault(c => group.All(b => b.Contains(c)));
        }

        private List<List<string>> SplitBackpacksIntoGroupsOfThree(List<string> backpacks)
        {
            return backpacks
                .Select((b, i) => new { Backpack = b, Index = i })
                .GroupBy(x => x.Index / 3)
                .Select(g => g.Select(x => x.Backpack).ToList())
                .ToList();
        }
    }
}