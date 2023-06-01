namespace AdventOfCode2022.Day02
{
    public class InputParser
    {
        public static List<List<RPSMove>> Parse1(string[] input)
        {
            var result = new List<List<RPSMove>>();
            foreach (var line in input)
            {
                char[] moves = line.Replace(" ", "").ToCharArray();
                var movesList = new List<RPSMove>();
                foreach (char move in moves)
                {
                    movesList.Add(CharToRPSMove(move));
                }

                result.Add(movesList);
            }

            return result;
        }

        public static List<List<RPSMove>> Parse2(string[] input)
        {
            var result = new List<List<RPSMove>>();
            for (int i = 0; i < input.Length; i++)
            {
                char[] moves = input[i].Replace(" ", "").ToCharArray();

                var movesList = new List<RPSMove>();
                for (int j = 0; j < moves.Length; j++)
                {
                    char c = moves[j];
                    if (IsMove(c))
                    {
                        movesList.Add(CharToRPSMove(c));
                        continue;
                    }

                    var opponentMove = CharToRPSMove(moves[0]);
                    var myMove = DetermineMyMove(opponentMove, CharToRPSResult(c));

                    movesList.Add(myMove);
                }

                result.Add(movesList);
            }

            return result;
        }

        private static bool IsMove(char c)
        {
            return c == 'A' || c == 'B' || c == 'C';
        }

        private static RPSMove DetermineMyMove(RPSMove opponentMove, RPSResult expectedResult)
        {
            if (expectedResult == RPSResult.DRAW)
            {
                return opponentMove;
            }

            switch (opponentMove)
            {
                case RPSMove.ROCK:
                    return expectedResult == RPSResult.WIN ? RPSMove.PAPER : RPSMove.SCISSORS;
                case RPSMove.PAPER:
                    return expectedResult == RPSResult.WIN ? RPSMove.SCISSORS : RPSMove.ROCK;
                case RPSMove.SCISSORS:
                    return expectedResult == RPSResult.WIN ? RPSMove.ROCK : RPSMove.PAPER;
                default:
                    throw new ArgumentException("Invalid opponent move");
            }
        }

        private static RPSMove CharToRPSMove(char c)
        {
            switch (c)
            {
                case 'A':
                case 'X':
                    return RPSMove.ROCK;
                case 'B':
                case 'Y':
                    return RPSMove.PAPER;
                case 'C':
                case 'Z':
                    return RPSMove.SCISSORS;
                default:
                    throw new ArgumentException("Invalid move");
            }
        }

        private static RPSResult CharToRPSResult(char c)
        {
            switch (c)
            {
                case 'X':
                    return RPSResult.LOSS;
                case 'Y':
                    return RPSResult.DRAW;
                case 'Z':
                    return RPSResult.WIN;
                default:
                    throw new ArgumentException("Invalid result");
            }
        }
    }
}