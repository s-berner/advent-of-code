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

            string day = args[0].ToLower();
            string task = args[1].ToLower();
            string mode = args[2].ToLower();

            string path = $"AdventOfCode2022.Day{day.PadLeft(2, '0')}.Task{task}";
            Type? type = Type.GetType(path);

            if (type == null)
            {
                Console.WriteLine($"No solution found for Day {day}, Task {task}.");
                return;
            }

            dynamic? solution = Activator.CreateInstance(type);

            if (solution == null)
            {
                Console.WriteLine($"Failed to create instance of {type.FullName}.");
                return;
            }

            if (!(solution is IAdventOfCodeTask))
            {
                Console.WriteLine($"{type.FullName} does not implement IAdventOfCodeTask.");
                return;
            }

            string[] input = InputReader.ReadInput(day, mode);

            solution.Solve(input);

            Console.WriteLine("Program finished.");
        }
    }
}