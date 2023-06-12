namespace AdventOfCode2022.Day08
{
    public class Task2 : IAdventOfCodeTask
    {
        public void Solve(string[] input)
        {
            Console.WriteLine("Day 08, Task 2 solution:");

            var treeGrid = InputParser.Parse(input);

            int highestScenicScore = GetBestScenicScore(treeGrid);

            Console.WriteLine($"The best scenic score is { highestScenicScore }");
        }

        private int GetBestScenicScore(List<List<int>> treeGrid)
        {
            var best = 0;

            for (int r = 1; r < treeGrid.Count; r++)
            {
                var row = treeGrid[r];

                for (int c = 1; c < row.Count; c++)
                {
                    var score = GetScenicScoreForTree(treeGrid, r, c);

                    best = Math.Max(best, score);
                }
            }

            return best;
        }

        private int GetScenicScoreForTree(List<List<int>> treeGrid, int treeRow, int treeCol)
        {
            var tree = treeGrid[treeRow][treeCol];

            var eastScore = GetScoreInDirection(treeGrid, treeRow, treeCol, 0, 1);

            var westScore = GetScoreInDirection(treeGrid, treeRow, treeCol, 0, -1);

            var northScore = GetScoreInDirection(treeGrid, treeRow, treeCol, -1, 0);

            var southScore = GetScoreInDirection(treeGrid, treeRow, treeCol, 1, 0);

            return eastScore * westScore * southScore * northScore;
        }

        private int GetScoreInDirection(List<List<int>> treeGrid, int treeRow, int treeCol, int rowDirection, int colDirection)
        {
            var score = 0;

            var rowIndex = treeRow + rowDirection;
            var colIndex = treeCol + colDirection;

            while (rowIndex >= 0 && rowIndex < treeGrid.Count && colIndex >= 0 && colIndex < treeGrid[rowIndex].Count)
            {
                score++;

                if (treeGrid[rowIndex][colIndex] >= treeGrid[treeRow][treeCol])
                {
                    break;
                }

                rowIndex += rowDirection;
                colIndex += colDirection;
            }

            return score;
        }
    }
}