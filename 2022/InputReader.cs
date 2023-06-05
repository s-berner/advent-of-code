namespace AdventOfCode2022
{
    public class InputReader
    {
        /// <summary>
        /// Reads the input file for the given day and input type.
        /// </summary>
        /// <param name="day">The day to read input for.</param>
        /// <param name="inputType">The input type to read.</param>
        /// <returns>The input file as an array of strings.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the input file is not found.</exception>
        public static string[] ReadInput(string day, string inputType)
        {
            string prefix = inputType == "d" ? "demo" : "puzzle";
            string path = $"Day{ day.PadLeft(2, '0') }\\{ prefix }-input.txt";
            string fullPath = Path.GetFullPath(path);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"Input file not found at { fullPath }.");
            }

            string[] input = File.ReadAllLines(fullPath);

            return input;
        }
    }
}