namespace AdventOfCode2022
{
    public class InputReader
    {
        public static string[] ReadInput(string day, string mode)
        {
            string prefix = mode == "d" ? "demo" : "puzzle";
            string path = $"Day{day.PadLeft(2, '0')}\\{prefix}-input.txt";
            string fullPath = Path.GetFullPath(path);

            if (!File.Exists(fullPath))
            {
                Console.WriteLine($"Input file not found: {fullPath}");
                return Array.Empty<string>();
            }

            string[] input = File.ReadAllLines(fullPath);

            return input;

        }

    }
}