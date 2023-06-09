namespace AdventOfCode2022.Day07
{
    public class InputParser
    {
        private static List<string> CurrentPath { get; set; } = new List<string>();
        private static List<FileSystemNode> Nodes { get; set; } = new List<FileSystemNode>();

        public static List<FileSystemNode> Parse(string[] input)
        {
            foreach (var line  in input)
            {
                if (line.StartsWith('$'))
                {
                    ParseCommand(line);

                }

                ParseFileOrDirectory(line);
            }

            return Nodes;
        }

        private static void ParseCommand(string line)
        {
            var args = line.Split(' ');
            var commandName = args[1];

            switch (commandName)
            {
                case "cd":
                    HandleChangeDirectory(args[2]);
                    break;
                case "ls":
                    // ls doesn't do anything in this task
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(commandName), commandName, null);
            }
        }

        private static void HandleChangeDirectory(string name)
        {
            switch (name)
            {
                case "..":
                    CurrentPath.RemoveAt(CurrentPath.Count - 1);
                    break;
                case "/":
                    CurrentPath.Clear();
                    break;
                default:
                    CurrentPath.Add(name);
                    break;
            }
        }

        private static void ParseFileOrDirectory(string line)
        {
            var args = line.Split(' ');

            bool nodeAlreadyExists = Nodes.Any(node => node.Name == args[1] && node.Parent == GetParent());

            if (nodeAlreadyExists)
            {
                return;
            }

            if (args[0] == "dir")
            {
                var name = args[1];
                var isFile = false;
                var size = 0;
                var parent = GetParent();
                var node = new FileSystemNode(name, isFile, parent, size);
                Nodes.Add(node);
            }

            if (args[0].All(char.IsDigit))
            {
                var name = args[1];
                var isFile = true;
                var size = int.Parse(args[0]);
                var parent = GetParent();
                var node = new FileSystemNode(name, isFile, parent, size);
                Nodes.Add(node);
            }
        }

        private static string GetParent()
        {
            if (CurrentPath.Count == 0)
            {
                return "/";
            }

            return CurrentPath.Last();
        }
    }
}