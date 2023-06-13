namespace AdventOfCode2022.Day07;

public class ElfFile
{
    public string Name { get; set;}
    public int Size { get; set;}

    public ElfFile(string name, int size)
    {
        Name = name;
        Size = size;
    }

    public static bool IsParsable(string line)
    {
        return int.TryParse(line.Split(' ')[0], out _);
    }

    internal static ElfFile Parse(string line)
    {
        string[] parts = line.Split(' ');
        string name = parts[1];
        int size = int.Parse(parts[0]);

        return new ElfFile(name, size);
    }
}
