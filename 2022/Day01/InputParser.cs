namespace AdventOfCode2022.Day01
{
    public class InputParser
    {

        public static List<int> Parse(string[] input)
        {
            var groupedByElves = PrepareInput(input);

            List<int> calorieSums = groupedByElves.Select(group => CalculateCalorieSum(group)).ToList();

            return calorieSums;
        }

        private static List<List<string>> PrepareInput(string[] input)
        {
            var preparedInput = new List<List<string>>();
            var currentGroup = new List<string>();

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    preparedInput.Add(currentGroup);
                    currentGroup = new List<string>();
                    continue;
                }

                currentGroup.Add(line);
            }

            preparedInput.Add(currentGroup);

            return preparedInput;
        }

        private static int CalculateCalorieSum(List<string> group)
        {
            var calorieSum = 0;

            foreach (var line in group)
            {
                calorieSum += int.Parse(line);
            }

            return calorieSum;
        }
    }
}