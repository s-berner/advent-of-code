namespace AdventOfCode2022.Day07
{
    public class Task1 : IAdventOfCodeTask
    {
        private const int MaxSize = 100000;

        public void Solve(string[] input)
        {
            var nodes = InputParser.Parse(input);

            var directories = nodes.Where(node => !node.IsFile).ToList();

            CalculateDirectorySizes(directories, nodes);

            foreach (var directory in directories)
            {
                Console.WriteLine(directory.ToString());
            }

            var qualifyingDirectories = directories.Where(directory => directory.Size <= MaxSize).ToList();

            var totalSize = qualifyingDirectories.Sum(directory => directory.Size);

            // var sb = new System.Text.StringBuilder();

            // sb.AppendLine($"By deleting the following directories, we can save { totalSize } bytes.");

            // foreach (var directory in qualifyingDirectories)
            // {
            //     sb.AppendLine(directory.ToString());
            // }

            // Console.WriteLine(sb.ToString());

            Console.WriteLine("Task not completed yet.");
        }

        private void CalculateDirectorySizes(List<FileSystemNode> directories, List<FileSystemNode> nodes)
        {
            foreach (var directory in directories)
            {
                directory.SetSize(CalculateDirectorySize(directory, nodes, new HashSet<string>()));
            }
        }

        private int CalculateDirectorySize(FileSystemNode directory, List<FileSystemNode> nodes, HashSet<string> visitedDirectories)
        {
            var size = 0;

            foreach (var node in nodes)
            {
                if (node.Parent != directory.Name)
                {
                    continue;
                }

                if (visitedDirectories.Contains(node.Parent + node.Name))
                {
                    // Directory has already been visited, return 0 to avoid infinite recursion
                    return 0;
                }

                var test = node.Parent + node.Name;
                visitedDirectories.Add(test);

                size += node.IsFile ? node.Size : CalculateDirectorySize(node, nodes, visitedDirectories);
            }

            return size;
        }
    }
}