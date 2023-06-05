using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day05
{
    public class InputParser
    {
        private static int MaxWidth { get; set; }
        private static int MaxHeight { get; set; }

        public class ParserResponse
        {
            public List<List<char>> CargoGrid { get; set; } = new List<List<char>>();
            public List<Instruction> Instructions { get; set; } = new List<Instruction>();
        }

        public class Instruction
        {
            public int Amount { get; set; }
            public int From { get; set; }
            public int To { get; set; }
        }

        public static ParserResponse Parse(string[] input)
        {
            var inputAsString = string.Join("\n", input);
            var inputSegments = inputAsString.Split("\n\n");

            var cargoSegment = inputSegments[0];
            var instructionSegment = inputSegments[1].Split("\n").ToList();

            var cargoGrid = ParseCargo(cargoSegment);
            var instructions = ParseInstructions(instructionSegment);

            return new ParserResponse
            {
                CargoGrid = cargoGrid,
                Instructions = instructions.Select(i => new Instruction
                {
                    Amount = i.Amount,
                    From = i.From,
                    To = i.To
                }).ToList()
            };
        }

        private static List<List<char>> ParseCargo(string input)
        {
            var cargoArray = input.Split("\n").Reverse().ToList();

            MaxWidth = cargoArray.Max(x => x.Length);
            MaxHeight = cargoArray.Count;

            var result = Enumerable.Range(0, MaxHeight)
                .Select(_ => Enumerable.Repeat(' ', MaxWidth).ToList())
                .ToList();

            var gridIdentifiers = GetRelevantColumns(cargoArray[0]);

            return ExtractColumns(cargoArray.ToList(), gridIdentifiers);
        }

        private static List<List<char>> ExtractColumns(List<string> input, List<int> columns)
        {
            var result = new List<List<char>>();
            foreach (var column in columns)
            {
                var columnChars = input
                    .Where(row => row.Length > column)
                    .Select(row => row[column])
                    .Skip(1)
                    .Reverse()
                    .SkipWhile(c => c == ' ')
                    .Reverse()
                    .ToList();

                result.Add(columnChars);
            }

            return result;
        }

        private static List<int> GetRelevantColumns(string input)
        {
            var result = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetterOrDigit(input[i]))
                {
                    continue;
                }

                result.Add(i);
            }

            return result;
        }

        private static List<Instruction> ParseInstructions(List<string> input)
        {
            var pattern = @"move (\d+) from (\d+) to (\d+)";
            var result = new List<Instruction>();
            foreach (var instruction in input)
            {
                var matchedInstructions = Regex.Match(instruction, pattern);

                if (!matchedInstructions.Success)
                {
                    continue;
                }

                result.Add(new Instruction
                {
                    Amount = int.Parse(matchedInstructions.Groups[1].Value),
                    From = int.Parse(matchedInstructions.Groups[2].Value),
                    To = int.Parse(matchedInstructions.Groups[3].Value)
                });
            }

            return result;
        }
    }
}