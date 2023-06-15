namespace AdventOfCode2022.Day05
{
    public class Task2 : IAdventOfCodeTask
    {
        public void Solve(string[] input)
        {
            Console.WriteLine("Day 05, Task 2 solution:");
            var parserOutput = InputParser.Parse(input);
            var cargoGrid = parserOutput.CargoGrid;
            var instructions = parserOutput.Instructions;

            foreach (var instruction in instructions)
            {
                cargoGrid = ExecuteInstruction(cargoGrid, instruction);
            }

            var result = new List<string>();
            for (int i = 0; i < cargoGrid.Count; i++)
            {
                var row = cargoGrid[i];
                result.Add(row.Last().ToString());
            }

            Console.WriteLine($"The message i will give to the elves is: { string.Join("", result) }");
        }

        private static List<List<char>> ExecuteInstruction(List<List<char>> cargoGrid, InputParser.Instruction instruction)
        {
            var from = instruction.From - 1;
            var to = instruction.To - 1;
            var amount = instruction.Amount;

            var boxesToMove = cargoGrid[from].TakeLast(amount).ToList();
            cargoGrid[from].RemoveRange(cargoGrid[from].Count - amount, amount);
            cargoGrid[to].AddRange(boxesToMove);

            return cargoGrid;
        }
    }
}