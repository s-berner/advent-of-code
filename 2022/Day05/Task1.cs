namespace AdventOfCode2022.Day05
{
    public class Task1 : IAdventOfCodeTask
    {
        public void Solve(string[] input)
        {
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

        private List<List<char>> ExecuteInstruction(List<List<char>> cargoGrid, InputParser.Instruction instruction)
        {
            var from = instruction.From - 1;
            var to = instruction.To - 1;
            var amount = instruction.Amount;

            for (int i = 0; i < amount; i++)
            {
                var boxToMove = cargoGrid[from].TakeLast(1).Single();
                cargoGrid[from].RemoveAt(cargoGrid[from].Count - 1);
                cargoGrid[to].Add(boxToMove);
            }

            return cargoGrid;
        }
    }
}