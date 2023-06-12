namespace AdventOfCode2022.Day08
{
    public class Task1 : IAdventOfCodeTask
    {
        public void Solve(string[] input)
        {
            var parsedInput = InputParser.Parse(input);

            var treesVisibleFromOutside = CountTreesVisibleFromOutside(parsedInput);

            Console.WriteLine($"Trees visible from outside: { treesVisibleFromOutside }");
        }

        private int CountTreesVisibleFromOutside(List<List<int>> treeGrid)
        {
            int edgeOverlap = 4;
            var treesVisibleFromOutside = (treeGrid.Count + treeGrid[0].Count) * 2 - edgeOverlap;

            for (int i = 1; i < treeGrid.Count - 1; i++)
            {
                for (int j = 1; j < treeGrid[0].Count - 1; j++)
                {
                    var currentTree = treeGrid[i][j];
                    var treesToTheLeft = GetTreesToTheLeft(treeGrid[i], j);
                    var treesToTheRight = GetTreesToTheRight(treeGrid[i], j + 1);
                    var treesAbove = GetTreesAbove(treeGrid, i, j);
                    var treesBelow = GetTreesBelow(treeGrid, i + 1, j);

                    if (treesToTheLeft.All(tree => tree < currentTree) ||
                        treesToTheRight.All(tree => tree < currentTree) ||
                        treesAbove.All(tree => tree < currentTree) ||
                        treesBelow.All(tree => tree < currentTree))
                    {
                        treesVisibleFromOutside++;
                    }
                }
            }

            return treesVisibleFromOutside;
        }

        public static List<int> GetTreesToTheLeft(List<int> row, int index)
        {
            return row.Take(index).ToList();
        }

        public static List<int> GetTreesToTheRight(List<int> row, int index)
        {
            return row.Skip(index).ToList();
        }

        public static List<int> GetTreesAbove(List<List<int>> grid, int rowIndex, int colIndex)
        {
            return grid.Take(rowIndex).Select(row => row[colIndex]).ToList();
        }

        public static List<int> GetTreesBelow(List<List<int>> grid, int rowIndex, int colIndex)
        {
            return grid.Skip(rowIndex).Select(row => row[colIndex]).ToList();
        }
    }
}