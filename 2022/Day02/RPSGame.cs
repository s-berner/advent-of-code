namespace AdventOfCode2022.Day02
{
    public class RPSGame
    {
        public static int CalculateScore(RPSMove opponentMove, RPSMove myMove)
        {
            var result = CalculateResult(opponentMove, myMove);
            return (int)result + (int)myMove;
        }

        private static RPSResult CalculateResult(RPSMove opponentMove, RPSMove myMove)
        {
            if (opponentMove == myMove)
            {
                return RPSResult.DRAW;
            }

            switch (opponentMove)
            {
                case RPSMove.ROCK:
                    return myMove == RPSMove.PAPER ? RPSResult.WIN : RPSResult.LOSS;
                case RPSMove.PAPER:
                    return myMove == RPSMove.SCISSORS ? RPSResult.WIN : RPSResult.LOSS;
                case RPSMove.SCISSORS:
                    return myMove == RPSMove.ROCK ? RPSResult.WIN : RPSResult.LOSS;
            }

            return RPSResult.LOSS;
        }
    }
}