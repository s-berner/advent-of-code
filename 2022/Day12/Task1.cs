using System.Data.Common;
using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day12;

public class Task1 : IAdventOfCodeTask
{
    private readonly int[,] directions = new int[,]
    {
        { 0, 1 },
        { 1, 0 },
        { 0, -1 },
        { -1, 0 }
    };

    public void Solve(string[] input)
    {
        Console.WriteLine("Day 12, Task 1 solution:");

        var map = InputParser.Parse(input);

        var start = GetStart(map);
        var end = GetEnd(map);

        if (start == null || end == null)
        {
            Console.WriteLine("Start or end not found");
            return;
        }

        ElfPointEqualityComparer comparer = new();
        HashSet<ElfPoint> visited = new(comparer);
        LinkedList<(int, ElfPoint)> path = new();

        LinkedListNode<(int, ElfPoint)> startNode = new((0, start));
        Step(map, startNode, end, visited, path);

        Console.WriteLine($"Shortest path: { path.Count }");
    }

    private bool Step(
        ElfHeightMap[,] map,
        LinkedListNode<(int, ElfPoint)> currentNode,
        ElfPoint endPoint,
        HashSet<ElfPoint> visited,
        LinkedList<(int, ElfPoint)> path)
    {
        var currentPoint = currentNode.Value.Item2;

        if (currentPoint.X < 0 || currentPoint.X >= map.GetLength(0))
        {
            return false;
        }

        if (currentPoint.Y < 0 || currentPoint.Y >= map.GetLength(1))
        {
            return false;
        }

        if (visited.Contains(currentPoint))
        {
            return false;
        }

        // if the
        // if ()
        // {

        // }

        if (currentPoint.X == endPoint.X && currentPoint.Y == endPoint.Y)
        {
            LinkedListNode<(int, ElfPoint)> endNode = new((currentNode.Value.Item1 + 1, endPoint));
            path.AddLast(endNode);
            return true;
        }

        //recursion
        // pre
        path.Add(currentPoint);
        visited.Add(currentPoint);


        // recurse
        for (int i = 0; i < directions.GetLength(0); i++)
        {
            var x = currentPoint.X + directions[i, 0];
            var y = currentPoint.Y + directions[i, 1];
            ElfPoint nextPoint = new(x, y);

            if (Step(map, nextPoint, endPoint, visited, path))
            {
                return true;
            }
        }


        // post
        path.Remove(currentPoint);

        return false;
    }

    private static ElfPoint? GetEnd(ElfHeightMap[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == ElfHeightMap.End)
                {
                    var point = new ElfPoint(i, j);
                    return point;
                }
            }
        }

        return null;
    }

    private static ElfPoint? GetStart(ElfHeightMap[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == ElfHeightMap.Start)
                {
                    var point = new ElfPoint(i, j);
                    return point;
                }
            }
        }

        return null;
    }
}
