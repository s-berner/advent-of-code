namespace AdventOfCode2022.Day07
{
    public class FileSystemNode
    {
        public string Name { get; } = string.Empty;
        public bool IsFile { get; } = false;
        public int Size { get; private set; } = 0;
        public string Parent { get; } = string.Empty;

        public FileSystemNode(string name, bool isFile, string parent, int? size)
        {
            Name = name;
            IsFile = isFile;
            Parent = parent;
            Size = size ?? 0;
        }

        public void SetSize(int size)
        {
            Size = size;
        }

        public override string ToString()
        {
            return $"{ Name } ({ (IsFile ? "File" : "Directory") }) Parent { Parent } - { Size } bytes";
        }
    }
}