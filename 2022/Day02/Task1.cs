namespace AdventOfCode2022.Day02
{
    public class Task1
    {
        public void Solve(string[] input)
        {
            Console.WriteLine("Day 02, Task 1 solution:");
            var rounds = InputParser.Parse1(input);

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