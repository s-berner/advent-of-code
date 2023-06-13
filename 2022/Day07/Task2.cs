using System.Text;

namespace AdventOfCode2022.Day07;

public class Task2 : IAdventOfCodeTask
{
    private const int TotalDiskSize = 70_000_000;
    private const int SpaceNeededToUpdate = 30_000_000;

    public void Solve(string[] input)
    {
        Console.WriteLine("Day 7, Task 2 solution:");

        var root = InputParser.BuildElfFileSystem(input);
        var directories = FindAlLDirectories(root);

        int spaceNeeded = CalculateSpaceNeeded(root.Size());
        var directoriesWithEnoughSpace = directories.Where(d => d.Size() >= spaceNeeded);
        var smallestDirectory = directoriesWithEnoughSpace.OrderBy(d => d.Size()).First();

        PrintDirectories(directoriesWithEnoughSpace);
        Console.WriteLine($"Smallest directory with enough space: { smallestDirectory.Name } - { smallestDirectory.Size() }");
    }

    private int CalculateSpaceNeeded(int spaceUsed)
    {
        return SpaceNeededToUpdate - (TotalDiskSize - spaceUsed);
    }

    private void PrintDirectories(IEnumerable<ElfDirectory> directories)
    {
        StringBuilder sb = new();

        sb.AppendLine("The following directories would free enough space:");

        foreach (ElfDirectory directory in directories)
        {
            sb.AppendLine($"・ { directory.Name } - { directory.Size() }");
        }

        Console.WriteLine(sb.ToString());
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
