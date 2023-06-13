namespace AdventOfCode2022.Day07;

public class ElfDirectory
{
    public string Name { get; set; }
    public ElfDirectory Parent { get; set; }
    private readonly List<ElfFile> _files = new();
    private readonly List<ElfDirectory> _children = new();

    public ElfDirectory(string name, ElfDirectory parent)
    {
        Name = name;
        Parent = parent;
        parent?._children.Add(this);
    }

    public static bool IsParsable(string line)
    {
        return line.StartsWith("dir");
    }

    public void AddFile(ElfFile file)
    {
        _files.Add(file);
    }

    public int Size()
    {
        int size = 0;
        foreach (var file in _files)
        {
            size += file.Size;
        }

        foreach (var child in _children)
        {
            size += child.Size();
        }

        return size;
    }

    public ElfDirectory? FindChild(string name)
    {
        foreach (ElfDirectory child in _children)
        {
            if (child.Name == name)
            {
                return child;
            }
        }

        return null;
    }

    internal static ElfDirectory Parse(ElfDirectory parent, string line)
    {
        string[] parts = line.Split(' ');
        string name = parts[1];

        return new ElfDirectory(name, parent);
    }

    public List<ElfDirectory> Children()
    {
        return _children.ToList();
    }
}
