using System.Text;

namespace AdventOfCode2022
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: dotnet run -- <Day> <Task> <(D)emo/(P)uzzle>");
                return;
            }

            var (day, task, inputType) = (args[0].ToLower(), args[1].ToLower(), args[2].ToLower());

            string path = $"AdventOfCode2022.Day{ day.PadLeft(2, '0') }.Task{ task }";
            Type? type = Type.GetType(path);

            if (type == null)
            {
                Console.WriteLine($"No solution found for Day { day }, Task { task }.");
                return;
            }

            dynamic? solution = Activator.CreateInstance(type);

            if (solution == null)
            {
                Console.WriteLine($"Failed to create instance of { type.FullName }.");
                return;
            }

            if (!(solution is IAdventOfCodeTask))
            {
                Console.WriteLine($"{ type.FullName } does not implement IAdventOfCodeTask.");
                return;
            }

            try
            {
                string[] input = InputReader.ReadInput(day, inputType);

                solution.Solve(input);

                Console.WriteLine("Program finished.");
            }
            catch (FileNotFoundException)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Input file not found for Day { day }, Task { task }.");
                sb.AppendLine("Make sure the input file is named correctly and placed in the correct folder.");
                sb.AppendLine("The input file should be named either puzzle-input.txt or demo-input.txt.");

                Console.WriteLine(sb.ToString());
            }
        }
    }
}