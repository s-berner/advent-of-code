namespace AdventOfCode2022.Day02
{
    public class Task2 : IAdventOfCodeTask
    {
        public void Solve(string[] input)
        {
            Console.WriteLine("Day 02, Task 2 solution:");
            var rounds = InputParser.Parse2(input);

            int finalScore = 0;
            foreach (List<RPSMove> round in rounds)
            {
                var opponentMove = round[0];
                var myMove = round[1];

                finalScore += RPSGame.CalculateScore(opponentMove, myMove);
            }

            Console.WriteLine($"Final score would be: {finalScore}");
        }
    }
}