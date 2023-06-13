namespace AdventOfCode2022.Day07;

public class InputParser
{
    public static ElfDirectory BuildElfFileSystem(string[] input)
    {
        ElfDirectory root = new ("/", null!);
        ElfDirectory currentDir = root;

        foreach (string line in input)
        {
            if (ElfFile.IsParsable(line))
            {
                currentDir = HandleFileLine(currentDir, line);
            }

            if (ElfDirectory.IsParsable(line))
            {
                currentDir = HandleDirectoryLine(currentDir, line);
            }

            if (line.StartsWith("$ cd"))
            {
                currentDir = HandleChangeDirectory(currentDir, line);
            }
        }

        return root;
    }

    private static ElfDirectory HandleDirectoryLine(ElfDirectory currentDir, string line)
    {
        ElfDirectory.Parse(currentDir, line);

        return currentDir;
    }

    private static ElfDirectory HandleFileLine(ElfDirectory currentDir, string line)
    {
        ElfFile file = ElfFile.Parse(line);
        currentDir.AddFile(file);

        return currentDir;
    }

    private static ElfDirectory HandleChangeDirectory(ElfDirectory currentDir, string line)
    {
        string childName = line.Split(' ')[2];

        return childName switch
        {
            ".." => currentDir.Parent,
            "/" => currentDir,
            _ => currentDir.FindChild(childName)!
        };
    }
}