namespace AdventOfCode2022.Day07;

public class Task1 : IAdventOfCodeTask
{
    private const int MaxSizeToMarkForDeletion = 100_000;

    public void Solve(string[] input)
    {
        Console.WriteLine("Day 7, Task 1 solution:");

        ElfDirectory root = InputParser.BuildElfFileSystem(input);
        List<ElfDirectory> directories = FindAlLDirectories(root);

        int sum = 0;
        foreach (var directory in directories)
        {
            int size = directory.Size();
            if (size <= MaxSizeToMarkForDeletion)
            {
                sum += size;
                Console.WriteLine($"Directory { directory.Name } is marked for deletion. Size: { size }");
            }
        }

        Console.WriteLine($"Sum of all files in all directories: { sum }");
    }

    private List<ElfDirectory> FindAlLDirectories(ElfDirectory toSearch)
    {
        List<ElfDirectory> allDirectories = new()
        {
            toSearch
        };

        foreach (ElfDirectory child in toSearch.Children())
        {
            allDirectories.AddRange(FindAlLDirectories(child));
        }

        return allDirectories;
    }
}